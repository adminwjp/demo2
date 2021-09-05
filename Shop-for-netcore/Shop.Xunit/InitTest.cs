using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Abp;
using Abp.Dependency;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Services;
using Shop.Application.Services.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Castle.Windsor.MsDependencyInjection;
using Xunit.Abstractions;
using System.Reflection;
using Shop.Domain.Entities;
using Utility.Generator;
using System.ComponentModel.DataAnnotations.Schema;
//using x=Xunit;
using System.IO;
using Utility.IO;
using System.Text.RegularExpressions;
using Utility.Json;
using System.Text;
using Abp.AutoMapper;
using System.Diagnostics;
using Utility.Net.Http;

namespace Shop.Xunit
{
    //生成模板 需要 一步步来
    //https://www.cnblogs.com/gangle/p/9369671.html
    public class InitTest
    {
        public class Test
        {
            public string Name { get; set; }
        }
        public class Test11: Test
        {
            public string Name1 { get; set; }
        }
        //[Fact]
        public void TestJson()
        {
            var json = JsonHelper.ToJson(new Test11() { Name="aa",Name1="aa1"});
            var test = JsonHelper.ToObject<Test>(json);
            Debug.Assert(test != null);
        }
        public static string path = "E:/work/shop/Shop-for-netcore";
        public static AbpBootstrapper abpBootstrapper;
        public static IServiceCollection services;
        public static IServiceProvider serviceProvider;
        ITestOutputHelper tempOutput;

        static string TargetFramework = "<TargetFramework>6.0</TargetFramework>";
       public  static string TemplateApi = "http://127.0.0.1:5000";
        static readonly object objLock = new object();
        static InitTest()
        {
            Init();
        }
        //== setup
        public InitTest(ITestOutputHelper tempOutput)
        {
            this.tempOutput = tempOutput;
           // Console.SetOut(tempOutput);
           
        }
        //[Fact]
        public void EntityToTemplate() { 
            CsharepGeneratorHelper.ParseEntity(typeof(Student).Assembly, new List<string>() { "Shop.Domain.Entities" });
            CsharepGeneratorHelper.AbpNhibernateMap.EntityToMap();
            if (CsharepGeneratorHelper.ClassModels.Count > 0)
            {
                List<dynamic> tabs = new List<dynamic>();
                foreach (var tab in CsharepGeneratorHelper.ClassModels)
                {
                    List<dynamic> cols = new List<dynamic>();
                    foreach (var pro in tab.Value.Properties)
                    {
                        var t=CsharepGeneratorHelper.Types.ContainsKey(pro.Property.PropertyType) ? CsharepGeneratorHelper.Types[pro.Property.PropertyType] : null;
                        cols.Add(new { CloumName = pro.ColumnName, PropertyName=pro.PropertyName, CsharepPropertyType= t });
                    }
                    tabs.Add(new { ClassName = tab.Value.ClassName, TablemName = tab.Value.TableName, ColumnModels = cols });
                }
                var db = new { TableModels =tabs, ProgramName ="Shop", Name = "Shop" };
                var str=HttpHelper.PostJson(TemplateApi + "/api/v1/admin/database/insert", JsonHelper.ToJson(db, JsonHelper.JsonSerializerSettings));
            }
        }
        //  [Fact]
        public void EntityToAbpNHibernate()
        {
            CsharepGeneratorHelper.NameSpace = "Shop.NHibernate.EntityMappings";
            CsharepGeneratorHelper.ParseEntity(typeof(Student).Assembly, new List<string>() { "Shop.Domain.Entities" },it=> { return typeof(Student) == it || typeof(Class) == it; });

            CsharepGeneratorHelper.AbpNhibernateMap.EntityToMap();
            CsharepGeneratorHelper.AbpNhibernateMap.EntityToMapStringCode(path+"/Shop.NHibernate/EntityMappings");
        }
        // [Fact]
        public void UpdateTargetFramework()
        {
            var dirs = Directory.GetDirectories(path);
            var temps = new List<string>();
            foreach (var item in dirs)
            {
                //tempOutput.WriteLine(item);
                //if (item == ".vs" || item.Equals(".vscode")
                 //   ||item.Equals("Lib"))
                    if (item.EndsWith(".vs") || item.EndsWith(".vscode")
                   || item.EndsWith("Lib"))
                    {
                    continue;
                }
                var str = item.Replace("\\", "/");
                temps.Add(str);
            }
            //return;
            tempOutput.WriteLine(temps.Count.ToString());
            foreach (var item in temps)
            {
               // string s = $"{path}/{item}/{item}.csproj";
                string s = $"{item}/{item.Split('/').LastOrDefault()}.csproj";
                string str = FileHelper.ReadFile(s);
                var tar=Regex.Replace(str, "<TargetFramework>(.*?)</TargetFramework>",it=> { return TargetFramework; });
               // tempOutput.WriteLine(tar);
                FileHelper.WriteFile(s, tar); ;
            }
        }

        public static void Init()
        {
            if (abpBootstrapper == null)
            {
                lock (objLock)
                {
                    if (abpBootstrapper == null)
                    {
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        abpBootstrapper = AbpBootstrapper.Create<ShopApplicationModule>();
                        //Castle.MicroKernel.ComponentNotFoundException : No component for supporting t
                        //he service Shop.Application.Services.ClassAppService was found
                        abpBootstrapper.Initialize();
                        services = new ServiceCollection();
                        services.AddSingleton(abpBootstrapper);
                        //这一步很 重要 
                        serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(abpBootstrapper.IocManager.IocContainer, services);
                        //serviceProvider=new DefaultServiceProviderFactory().CreateServiceProvider(services);

                      

                    }
                }
            }
        }
       // [Fact]
        public void InitData()
        {
            List<CreateClassInput> classInputs = new List<CreateClassInput>();
            for (var i = 0; i <= 10; i++)
            {
                classInputs.Add(new CreateClassInput()
                {
                    Name = (i > 9 ? ("G20210" + i) : ("G202100" + i))
                }
                 );
            }
            List<CreateStudentInput> students = new List<CreateStudentInput>();
            for (var i = 0; i <= 10; i++)
            {
                students.Add(new CreateStudentInput()
                {
                    StudentId = (i > 9 ? ("20210" + i) : ("202100" + i)),
                    Age = 20 + i,
                    Sex = "男",
                    Name = i.ToString()
                }
                 );
            }

            // Castle.MicroKernel.ComponentNotFoundException : No component for supporting t
            //he service System.IServiceProvider was found
            // ClassAppService classAppService=abpBootstrapper.IocManager.
            // IocContainer.Resolve<ClassAppService>();
            //  StudentAppService studentAppService=abpBootstrapper.IocManager.
            // IocContainer.Resolve<StudentAppService>();

            ClassAppService classAppService = serviceProvider.GetService<ClassAppService>();
            StudentAppService studentAppService = serviceProvider.GetService<StudentAppService>();

            classAppService.Insert(classInputs);
            studentAppService.Insert(students);
            tempOutput.WriteLine("add suc");
            var stus = studentAppService.Find(1, 10);
            if (stus != null)
            {
                tempOutput.WriteLine("query suc,has data");
                foreach (var it in stus)
                    Console.WriteLine(it.StudentId);
            }
            else
            {
                //throw new Exception("query suc,not has data");
                tempOutput.WriteLine("query suc,not has data");
            }
            // abpBootstrapper.IocManager.
            // IocContainer.Release(classAppService);
            //  abpBootstrapper.IocManager.
            // IocContainer.Release(studentAppService);
        }

        [Fact(Skip = "SetUp")]
        public void SetUp()
        {

        }
        [Fact]
        public void Test1()
        {

        }
        List<Type> InitEntity()
        {
            CsharepGeneratorHelper.Classes.Clear();
            Assembly assembly = typeof(Student).Assembly;
            var types = CsharepGeneratorHelper.GetTypes(assembly);
            var temp = new List<Type>(types.Count);
            foreach (var item in types)
            {
                if (item.IsAbstract || item.IsEnum)
                {
                    continue;
                }
                if (item.Namespace == typeof(Student).Namespace)
                {
                    var table = item.GetCustomAttribute<TableAttribute>();
                    if (table == null)
                    {
                        temp.Add(item);
                    }
                }
            }
            return temp;
        }
       //[Fact]
        public void EntityToEntityFrameworkCoreMap(){
            var temp = InitEntity();
            CsharepGeneratorHelper.NameSpace = "Shop.EntityFrameworkCore.EntityMappings";
            CsharepGeneratorHelper.ParseEntity(temp);
            CsharepGeneratorHelper.EntityFrameworkCoreMap.EntityToMap();
            CsharepGeneratorHelper.EntityFrameworkCoreMap.EntityToMapStringCode(path+"/Shop.Ef/EntityFrameworkCore/EntityMappings");
        }
     //[Fact]
        public void EntityToAbpDto()
        {
            CsharepGeneratorHelper.Register();
            var temp = InitEntity();
            CsharepGeneratorHelper.NameSpace = " Shop.Application.Services.Dtos";
            CsharepGeneratorHelper.ParseEntity(temp);
            CsharepGeneratorHelper.EntityToAbpDto();
            //Shop.Application/Application/Services/Dtos
              CsharepGeneratorHelper.EntityToAbpDtoStrinfCode(path + "/Shop.Application/Application/Dtos");
            
            CsharepGeneratorHelper.EntityToResource(path + "/Shop.Application");
        }
        //[Fact]
        public void EntityToResource()
        {
            CsharepGeneratorHelper.Register();
            var temp = InitEntity();
            CsharepGeneratorHelper.NameSpace = " Shop.Application.Services.Dtos";
            CsharepGeneratorHelper.ParseEntity(temp);
            CsharepGeneratorHelper.EntityToAbpDto();

            CsharepGeneratorHelper.EntityToResource(path + "/Shop.Application");
            // FileHelper.WriteFile(path + "/Shop.Api/validate.json",JsonHelper.ToJson(CsharepGeneratorHelper.ValidateStringCodes));
        }

        //[Fact]
        public void EntityToAppServiceAndAbpController()
        {
            var temp = InitEntity();
            CsharepGeneratorHelper.NameSpace = "Shop.Application.Services";
            CsharepGeneratorHelper.ParseEntity(temp);
            CsharepGeneratorHelper.EntityToAbpService("Shop.Domain.Repositories");
            //Shop.Application/Application/Services
            CsharepGeneratorHelper.EntityToAbpServiceStrinfCode(path + "/Shop.Application");

            CsharepGeneratorHelper.NameSpace = "Shop.Api.Controllers";
            //Shop.EntityFrameworkCore.Repositories  Shop.Domain.Repositories
            CsharepGeneratorHelper.EntityToAbpController("Shop.Application.Services.Dtos", "Shop.Domain.Repositories", "Shop.Application.Services");
            //Shop.Api/Controllers
            CsharepGeneratorHelper.EntityToAbpControllerStrinfCode(path + "/Shop.Api/Controllers1");
        }
       
        // [Fact]
        public void EntityToAbp()
        {
            EntityToEntityFrameworkCoreMap();
            EntityToAbpDto();
            EntityToAppServiceAndAbpController();
        }

        // [Fact]
        public void EntityToNHibernateMappAndDtoAndAppServiceAndWpfXmalAndLayuiHtml()
        {
           
        }

      // [Fact]
        public virtual void EntityToWpfViewModel()
        {
            Assembly assembly = typeof(Shop.Application.Services.BuyerIntegralAppService).Assembly;
            HashSet<string> names = new HashSet<string>(100);
            string tp = $"{path}/Utility.Generator/tpl/WpfViewModel.tpl";
            string tpl = FileHelper.ReadFile(tp);
            Dictionary<Type, string> codes = new Dictionary<Type, string>(10);
            foreach (var module in assembly.Modules)
            {
                foreach (var item in module.GetTypes())
                {
                    if (item.Namespace == "Shop.Application.Services.Dtos")
                    {
                        if (item.Name.StartsWith("Query"))
                        {
                            tempOutput.WriteLine("111");
                            if (item.Name.EndsWith("Input"))
                            {

                            }
                            else
                            {
                                var it = item.GetCustomAttribute<AutoMapAttribute>();
                                if (names.Contains(it.TargetTypes[0].Name))
                                {
                                    continue;
                                }
                                names.Add(it.TargetTypes[0].Name);
                                string code = tpl.Replace("{.namespace}", "Shop.Wpf.ViewModel")
                                .Replace("{.class}", it.TargetTypes[0].Name)
                                .Replace("{.class_dto}", item.Name)
                                .Replace("{.dto_namespace}", item.Namespace);
                                codes.Add(it.TargetTypes[0],code);
                            }
                        }
                    }
                }
            }
            if (codes.Count > 0)
            {
                foreach (var it in codes)
                {
                    FileHelper.WriteFile($"{path}/Shop.Wpf/ViewModel/{it.Key.Name}ViewModel.cs", it.Value);
                }
            }
        }
        //[Fact]
        public virtual void EntityToWpfConfig()
        {
            Assembly assembly = typeof(Shop.Application.Services.BuyerIntegralAppService).Assembly;
            HashSet<string> names = new HashSet<string>(100);
            string tp = $"{path}/Utility.Generator/tpl/WpfConfig.tpl";
            string tpl = FileHelper.ReadFile(tp);
            Dictionary<Type, string> codes = new Dictionary<Type, string>(10);
            foreach (var module in assembly.Modules)
            {
                foreach (var item in module.GetTypes())
                {
                    if (item.Namespace == "Shop.Application.Services.Dtos")
                    {
                        if (item.Name.StartsWith("Query"))
                        {
                            tempOutput.WriteLine("111");
                            if (item.Name.EndsWith("Input"))
                            {

                            }
                            else
                            {
                                var it = item.GetCustomAttribute<AutoMapAttribute>();
                                if (names.Contains(it.TargetTypes[0].Name))
                                {
                                    continue;
                                }
                                names.Add(it.TargetTypes[0].Name);
                                string code = tpl.Replace("{.class}", it.TargetTypes[0].Name);
                                codes.Add(it.TargetTypes[0], code);
                            }
                        }
                    }
                }
            }
            if (codes.Count > 0)
            {
                 tp = $"{path}/Utility.Generator/tpl/WpfConfigManager.tpl";
                tpl = FileHelper.ReadFile(tp);
                StringBuilder builder = new StringBuilder(10000);
                string methods = "";
                foreach (var it in codes)
                {
                   var str = "        private static void Bind"+ it.Key.Name + "Config()\r\n        {\r\n"+it.Value+ "        \r\n}\r\n";
                   builder.Append(str); 
                   methods+="                Bind" + it.Key.Name + "Config();\r\n";
                }
                var code = tpl.Replace("{.program}", "Shop")
                                .Replace("{.class}", "ShopConfigManager")
                                .Replace("{.string_code}", "        public static void BindShopConfig()        {\r\n" + methods + "        \r\n}\r\n"+builder.ToString());
                FileHelper.WriteFile($"{path}/Shop.Wpf/ShopConfigManager.cs", code);
            }
        }
        //[Fact]
        public virtual void EntityToWpfJson()
        {
            List<dynamic> datas = new List<dynamic>(100);
            Assembly assembly = typeof(Shop.Application.Services.BuyerIntegralAppService).Assembly;
            HashSet<string> names = new HashSet<string>(100);
            foreach (var module in assembly.Modules)
            {
                foreach (var item in module.GetTypes())
                {
                    if (item.Namespace== "Shop.Application.Services.Dtos" )
                    {
                        if(item.Name.StartsWith("Query"))
                        {
                            tempOutput.WriteLine("111");
                            if (item.Name.EndsWith("Input"))
                            {

                            }
                            else
                            {
                                var it = item.GetCustomAttribute<AutoMapAttribute>();
                                if (names.Contains(it.TargetTypes[0].Name))
                                {
                                    continue;
                                }
                                names.Add(it.TargetTypes[0].Name);
                                var input = GetPros(item);
                                datas.Add(new
                                {
                                    Flag = "Config." + item.Name.Replace("Query", "").Replace("Output", ""),
                                    Title = item.Name,
                                    Data = new List<dynamic>() {
                                        new {
                                             Lists=new List<dynamic>(){
                                                new {
                                                    Flag= 0,
                                                    Title= item.Name,
                                                    Width= 500,
                                                    Height= 250+50*input.Count, 
                                                    Columns = input
                                                }
                                             }
                                        }
                                    }
                                });
                            }
                        }
                    }
                }
            }
            var json=JsonHelper.ToJson(datas);
            FileHelper.WriteFile($"{path}/Shop.Wpf/Config/shop.json",json);
        }

        public List<dynamic> GetPros(Type type)
        {
            List<dynamic> ps = new List<dynamic>(10);
            foreach (var pro in type.GetProperties())
            {
                ps.Add(new
                {
                    Name= pro.Name,
                    Header=pro.Name,
                    ColumnType= 1
                });
            }
            return ps;
        }
    }
}
