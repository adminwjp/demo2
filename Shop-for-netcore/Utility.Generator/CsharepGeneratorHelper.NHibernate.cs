using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utility.IO;
using Utility.Helpers;

namespace Utility.Generator
{
    public partial class CsharepGeneratorHelper
    {
        public static readonly Dictionary<Type, string> NHibernateMapStringCodes = new Dictionary<Type, string>(100);
        public static readonly Dictionary<string, string> ValidateStringCodes = new Dictionary<string, string>(10000);
        public static string NHibernateMapPath = "tpl/NHibernateMap.tpl";
        public static string DtoPath = "tpl/Dto.tpl";
        public static string ServicePath = "tpl/Service.tpl";
        public static string ControllerPath = "tpl/Controller.tpl";
        public static NHibernateMapResolver NHibernateMap = new NHibernateMapResolver();
        public class NHibernateMapResolver : MapResolver
        {
            public override void Many(PropertyModel pro, StringBuilder builder)
            {
                //List Set Bag
                builder.Append("            List(x => x." + pro.PropertyName + ", map =>{ map.Cascade(NHibernate.Mapping.ByCode.Cascade.All);map.Access(NHibernate.Mapping.ByCode.Accessor.None); } )");
            }
            public override void Sing(PropertyModel pro, StringBuilder builder)
            {
                builder.Append("            OneToOne(x => x." + pro.PropertyName + ", map => { map.Cascade(NHibernate.Mapping.ByCode.Cascade.None);map.Access(NHibernate.Mapping.ByCode.Accessor.None); map.ForeignKey(\""+
                     pro.ColumnName +"_id\"); })");
            }
            public override void Id(PropertyModel pro, StringBuilder builder)
            {
                builder.Append("            Id(x => x."+pro.PropertyName +", map =>{ map.Column(\"" +pro.ColumnName+"\"); });\r\n");
            }
            public override bool OtherToSkip(List<PropertyModel> temps, PropertyModel pro, StringBuilder builder)
            {
                bool fk = false;
                if (pro.PropertyName.EndsWith("Id"))
                {
                    if (pro.PropertyName == "Id")
                    {
                        Id(pro, builder);
                        return true;
                    }
                    else
                    {
                        var end = pro.PropertyName.TrimEnd("Id".ToArray());
                        if (temps.Exists(it => it.PropertyName == end))
                        {
                            fk = true;
                        }
                    }
                }
                builder.Append("           "+ (fk ? "//" : "") + " Property(x => x."+ pro.PropertyName + ", map =>{ ");
                builder.Append($"map.Column(\"{pro.ColumnName}\");");
                if (pro.Property.PropertyType == typeof(string))
                {
                    builder.Append($" map.Length({pro.Length});");
                }
                builder.Append(" } )");
                return false;
            }
            public override void UpdateTpl(string tpl, KeyValuePair<Type, ClassModel> it, StringBuilder builder)
            {
                var name = TableResolver.GetName(it.Key.Name);
                string code = tpl.Replace("{.namespace}", NameSpace)
                .Replace("{.class_namespace}", it.Key.Namespace)
                .Replace("{.table_name}", TableResolver.GetTableName(name))
                .Replace("{.class}", it.Key.Name)
                .Replace("{.class_map}", name + "Map")
                .Replace("{.string_code}", builder.ToString());
                builder.Clear();
                if (NHibernateMapStringCodes.ContainsKey(it.Key))
                {
                    NHibernateMapStringCodes[it.Key] = code;
                }
                else
                {
                    NHibernateMapStringCodes.Add(it.Key, code);
                }
            }
          
            public override void EntityToMap()
            {
                EntityToMap(NHibernateMapPath);
            }
            public override void EntityToMapStringCode(string path)
            {
                EntityToStrinfCode(NHibernateMapStringCodes, "Map.cs", path);
            }
        }

        public static void EntityToDto()
        {
            EntityToDto(DtoPath, EntityToAbpDto);
        }

 

        public static void EntityToDto(string path, Func<KeyValuePair<Type, List<PropertyInfo>>, string, string, string, string,string> func)
        {
            if (Classes.Count > 0)
            {

                StringBuilder builder = StringPools.Get();
                StringBuilder prfix = StringPools.Get();
                String tpl = FileHelper.ReadFile(path);
                foreach (KeyValuePair<Type, List<PropertyInfo>> it in Classes)
                {
                    if (it.Value.Count == 0)
                    {
                        continue;
                    }
                    string cla = it.Key.Name;
                    builder.Append("        protected virtual void OnPropertyChanged( string propertyName = null){}\r\n");
                    Console.WriteLine(it.Key + " " + it.Value.Count);
                    foreach (var pro in it.Value)
                    {
                        if (MapResolver.Empty.IsList(pro))
                        {
                            continue;
                        }
                        else if (TypeClasses.Contains(pro.PropertyType))
                        {
                            continue;
                        }
                        else
                        {
                            var name = StringHelper.Parse(pro.Name, StringFormat.InitialLetterLower);
                            prfix.Append("        private " + (pro.PropertyType.IsEnum ? pro.PropertyType.Name : Types[pro.PropertyType]) + " "
                            + name + ";\r\n");
                            Console.WriteLine(pro.PropertyType);
                            var val = "";
                            var pr = StringHelper.Parse(TableResolver.GetName(cla),StringFormat.InitialLetterUpperCaseLower);
                            var suf = StringHelper.Parse(pro.Name, StringFormat.InitialLetterUpperCaseLower);
                            // var s = $"{pr}.{suf}";ErrorMessageResourceName ErrorMessageResourceType not support
                            var s = $"{pr}_{suf}";
                            if (pro.PropertyType == typeof(string))
                            {
                                ValidateStringCodes.Add(s,$"{suf} is not null ");
                                ValidateStringCodes.Add(s + "_range", suf + " length {1} to  {2} chars ");
                                val = "        [Required(ErrorMessageResourceName =\""+ s + "\", ErrorMessageResourceType = typeof(Resource))]\r\n        [Range(2, 10, ErrorMessageResourceName = \"" + s+"_range" + "\", ErrorMessageResourceType = typeof(Resource))]\r\n";
                            }else if (TypeHelper.IsICollection(pro.PropertyType, typeof(Nullable<>)))
                            {
                                ValidateStringCodes.Add(s, $"{suf} is not null ");
                                val = "        [Required(ErrorMessageResourceName =\""+ s + "\", ErrorMessageResourceType = typeof(Resource))]\r\n";
                            }
                            builder.Append(val+"        public virtual " + (pro.PropertyType.IsEnum ? pro.PropertyType.Name : Types[pro.PropertyType]) + " "
                             + pro.Name + "\r\n        {\r\n            get{    return this." + name
                             + ";}\r\n            set{    this." + name
                             + "=value; " + IfTypes[MapResolver.Empty.GetType(pro.PropertyType)].Replace("@name", name)
                             .Replace("@code", "OnPropertyChanged(\"" + pro.Name + "\");").Replace("\r\n", "") + "}\r\n        }\r\n");

                        }

                    }
                    string code = prfix.ToString() + builder.ToString();
                    //类 字段 太多 
                    string tp = "    [AutoMap(typeof({.class}))]\r\n    public  class {.class_dto}\r\n     {\r\n{.string_code}\r\n    }\r\n";

                    var dtoCode = func(it,tpl, tp, cla, code);

                    if (DtoStringCodes.ContainsKey(it.Key))
                    {
                        DtoStringCodes[it.Key] = dtoCode;
                    }
                    else
                    {
                        DtoStringCodes.Add(it.Key, dtoCode);
                    }
                    prfix.Clear();
                    builder.Clear();
                }
                StringPools.Release(builder);
                StringPools.Release(prfix);
            }
        }

        public static void EntityToService(string repositoryNameSpace)
        {
            EntityToService(ServicePath,repositoryNameSpace);
        }
        public static void EntityToService(string path, string repositoryNameSpace)
        {
            if (Classes.Count > 0)
            {
                StringBuilder builder = StringPools.Get();
                string tpl = FileHelper.ReadFile(path);
                foreach (var it in Classes)
                {
                    if (it.Value.Count == 0)
                    {
                        continue;
                    }
                    string code = tpl.Replace("{.namespace}", NameSpace)
                    .Replace("{.class_namespace}", it.Key.Namespace)
                    .Replace("{.dto_namespace}", NameSpace + ".Dtos")
                    .Replace("{.class}", it.Key.Name)
                    .Replace("{.repository_namespace}", repositoryNameSpace);
                    builder.Clear();
                    if (ServiceStringCodes.ContainsKey(it.Key))
                    {
                        ServiceStringCodes[it.Key] = code;
                    }
                    else
                    {
                        ServiceStringCodes.Add(it.Key, code);
                    }
                }
            }
        }
        public static void EntityToServiceStrinfCode(string path)
        {
            EntityToStrinfCode(ServiceStringCodes, "AppService.cs", path);
        }

        public static void EntityToController(string dtoNameSpace, string repositoryNameSpace, string serviceNameSpace)
        {
            EntityToController(ControllerPath,dtoNameSpace,repositoryNameSpace,serviceNameSpace);
        }
        public static void EntityToController(string path,string dtoNameSpace, string repositoryNameSpace, string serviceNameSpace)
        {
            if (Classes.Count > 0)
            {
                StringBuilder builder = StringPools.Get();
                string tpl = FileHelper.ReadFile(path);
                foreach (var it in Classes)
                {
                    if (it.Value.Count == 0)
                    {
                        continue;
                    }
                    string code = tpl.Replace("{.namespace}", NameSpace)
                    .Replace("{.class_namespace}", it.Key.Namespace)
                    .Replace("{.dto_namespace}", dtoNameSpace)
                    .Replace("{.service_namespace}", serviceNameSpace)
                    .Replace("{.class}", it.Key.Name)
                    .Replace("{.repository_namespace}", repositoryNameSpace);
                    builder.Clear();
                    if (ControllerStringCodes.ContainsKey(it.Key))
                    {
                        ControllerStringCodes[it.Key] = code;
                    }
                    else
                    {
                        ControllerStringCodes.Add(it.Key, code);
                    }
                }
            }
        }
        public static void EntityToControllerStrinfCode(string path)
        {
            EntityToStrinfCode(ControllerStringCodes, "Controller.cs", path);
        }

    }
}
