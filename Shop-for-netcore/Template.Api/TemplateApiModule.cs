namespace Template.Api
{
    using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Configuration.Startup;
using Abp.Domain.Entities;
using Abp.Modules;
using Abp.NHibernate;
using Abp.NHibernate.Filters;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Configuration;
using System.Data.Common;
    using System.IO;
    using System.Reflection;
    using Template.Api.Repositories;
    using Utility;
    using Utility.IO;

    [DependsOn(typeof(AbpNHibernateModule),typeof(AbpAspNetCoreModule))]
    public class TemplateApiModule: AbpModule
    {
         private static ISessionFactory sessinFactory = null;
        //初始化
        private static void InitiallizeSessionFactory()
        {
            try
            {
                NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
                configuration = configuration.Configure("hibernate.cfg.xml");

                // 工厂初始化， 链接数据库等 /  此处会爆发各种bug 注意mysql。dll版本 
                //sessinFactory = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(db => db.Server("localhost").Database("Shop").Username("root").Password("wjp930514.")))
                //    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ShopModule>()).BuildSessionFactory();
                //error 过不 去 什么 玩意 难道 下载源码 调试 ?
                //string connStr = "Database=Shop;Data Source=localhost;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
                //sessinFactory = Fluently.Configure().Database(new MySQLConfigurationV1().Raw("dialect", "NHibernate.Dialect.MySQL5Dialect").ConnectionString(connStr).ShowSql()
                //    .FormatSql().Raw("hbm2ddl.auto", "update").Raw("connection.driver_class", "NHibernate.Driver.MySqlDataDriver"))
                //    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                //    .BuildSessionFactory();
               
                configuration = Fluently.Configure(configuration)
                 .Mappings(m => {
                     m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                     m.FluentMappings.Add(typeof(SoftDeleteFilter));//这个是关键的
                 })
                 .BuildConfiguration();
                //configuration.FilterDefinitions.Clear();
                //foreach (var item in configuration.ClassMappings)
                //{
                //    item.FilterMap.Clear();
                //}
                sessinFactory = configuration.BuildSessionFactory();//pass

                //pass
                var mapper = new ModelMapper();
                //mapper.AddMappings(new Type[] { typeof(OrderMappV1) });
                var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
               
                configuration.AddMapping(domainMapping);
                sessinFactory = configuration.BuildSessionFactory();

            }
            catch (Exception e)
            {

            }

        }
        // private static ISessionFactory SessionFactory
        // {
        //     get
        //     {
        //         if (sessinFactory == null)
        //             InitiallizeSessionFactory();
        //         return sessinFactory;
        //     }
        // }
        // public static ISession OpenSession()
        // {
        //     return SessionFactory.OpenSession();
        // }



        public override void PreInitialize()
        {
            //InitiallizeSessionFactory();
            //AbpBootstrapper 启动模型 AbpModuleManager 模块 启动 类 
            //core 也 支持 ConfigurationManager (支持 netstandard)? 
            //NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
            //configuration = configuration.Configure("hibernate.cfg.xml");
            //hbm 集合关联(查询)支持 但 map  FluentNHibernate 异常
            var connStr = "";
            NHibernate.Cfg.Configuration configuration = null;
            if (ConfigHelper.OrmFlag!= OrmFlag.None)
            {
                configuration = (NHibernate.Cfg.Configuration)Configuration.Modules.AbpNHibernate().FluentConfiguration.GetType().GetProperty("Configuration",
            BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Configuration.Modules.AbpNHibernate().FluentConfiguration);
                //configuration = configuration.Configure("hibernate.cfg.xml");
                 connStr = ConfigurationManager.AppSettings["Default"]; // web.config 获取不到 

            }

            connStr = connStr ?? "Data Source=d:\\template.db;";//"Database=Shop;Data Source=localhost;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
            Console.WriteLine(connStr);
           var config = Utility.Nhibernate.NhibernateHelper
                .UseNhibernate(Configuration.Modules.AbpNHibernate().
                FluentConfiguration, Utility.ConfigHelper.DbFlag, connStr);
            //Configuration.Modules.AbpNHibernate().FluentConfiguration
            //     .Database(
            //         //MySQLConfiguration
            //         SQLiteConfiguration
            //     .Standard.ConnectionString(connStr).ShowSql().
            //     FormatSql().Raw("hbm2ddl.auto", "update"))
            if (ConfigHelper.OrmFlag == OrmFlag.Map)
            {
                config.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
          ;
            }
          

            // .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false, IocManager.Resolve<DbConnection>(), Console.Out));

            if (ConfigHelper.OrmFlag == OrmFlag.Xml) { 
                foreach (var item in Directory.GetFiles("Config/hbm", "*.hbm.xml"))
            {
                configuration.AddXmlFile(item);
            }
            SchemaExport export = new SchemaExport(configuration);
            FileHelper.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "sql/" + Utility.ConfigHelper.DbFlag.ToString()));
            export.SetOutputFile(Path.Combine(Directory.GetCurrentDirectory(), "sql/" + Utility.ConfigHelper.DbFlag.ToString() + "/sql.sql")); //设置输出目录
                                                                                                                                               // export.Drop(true, true);//设置生成表结构存在性判断,并删除
            export.Create(false, false);//设置是否生成脚本,是否导出来
            }
            Configuration.Modules.AbpAspNetCore().DefaultResponseCacheAttributeForAppServices = new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None };

            Configuration.IocManager.Resolve<IAbpAspNetCoreConfiguration>().EndpointConfiguration.Add(endpoints =>
            {
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        public override void Initialize()
        {
            IocManager.Register(typeof(IBaseRepository<>),typeof(TemplateRepositoryBase<>));
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
           // Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(GetType().Assembly, "app");
        }
    }
}