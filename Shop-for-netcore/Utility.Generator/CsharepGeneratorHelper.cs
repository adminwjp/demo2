namespace Utility.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Utility.Helpers;
    using Utility.IO;
    using System.Linq;
    using Utility.Pool;

    public partial class CsharepGeneratorHelper
    {
        public static string ResourcePath = "tpl/Resource.resx.tpl";
        public static string ResourceDesignerPath = "tpl/Resource.Designer.cs.tpl";
        public static string AbpNHibernateMapPath = "tpl/AbpNHibernateMap.tpl";
        public static string AbpDtoPath = "tpl/AbpDto.tpl";
        public static string AbpServicePath = "tpl/AbpService.tpl";
        public static string AbpControllerPath = "tpl/AbpController.tpl";

        public static IObjectPool<StringBuilder> StringPools = new ObjectPool<StringBuilder>(() => new StringBuilder(1000))
        {
            // MaxPoolSize=100,MinPoolSize=10                                                                           
        };
        public class TableNameResolver
        {
            public virtual string GetTableName(string name)
            {
                return $"t_{StringHelper.Parse(name, StringFormat.InitialLetterUpperCaseLower)}";
            }

            public virtual string GetName(string className)
            {
                return className.Replace("Model", "")
                     .Replace("Info", "").Replace("Entity", "");
            }

            public virtual string GetClassName(string name)
            {
                return $"{StringHelper.Parse(name.TrimStart("t_".ToCharArray()), StringFormat.InitialLetterLowerCaseUpper)}";
            }
        }

        public class ColumnNameResolver
        {
            public virtual long GetLength(PropertyInfo pro)
            {
                return ColumnLength;
            }
            public virtual string GetColumnName(string name)
            {
                return StringHelper.Parse(name, StringFormat.InitialLetterUpperCaseLower);
            }

            public virtual string GetPropertyName(string name)
            {
                return StringHelper.Parse(name, StringFormat.InitialLetterLowerCaseUpper);
            }
        }

        public class MapResolver {
            public static readonly MapResolver Empty = new MapResolver();
            public virtual bool IsList(PropertyInfo pro)
            {
                //pro.PropertyType.IsAssignableFrom(typeof(IList<>)) not match
                //typeof(IList<>).IsAssignableFrom(typeof(pro.PropertyType)) not match
                return TypeHelper.IsList(pro.PropertyType) || TypeHelper.IsSet(pro.PropertyType) || TypeHelper.IsICollection(pro.PropertyType, TypeHelper.CollectionType);
            }

            public virtual void Many(PropertyModel pro, StringBuilder builder)
            {

            }

            public virtual Type GetType(Type type)
            {
                if (type.IsEnum)
                {
                    return typeof(int);
                }
                return type;
            }

            public virtual bool Sing(PropertyModel pro)
            {
                return TypeClasses.Contains(pro.Property.PropertyType);
            }

            public virtual void Sing(PropertyModel pro, StringBuilder builder)
            {

            }

            public virtual void Id(PropertyModel pro, StringBuilder builder)
            {
               
            }
            public virtual bool OtherToSkip(List<PropertyModel> temps, PropertyModel pro, StringBuilder builder)
            {
                return false;
            }
            public virtual void UpdateTpl(string tpl, KeyValuePair<Type, ClassModel> it, StringBuilder builder)
            {

            }
            public virtual void EntityToMap()
            {

            }
            public virtual void EntityToMap(string path) {
                if (ClassModels.Count > 0)
                {
                    StringBuilder builder = StringPools.Get();
                    String tpl = FileHelper.ReadFile(path);
                    foreach (KeyValuePair<Type, ClassModel> it in ClassModels)
                    {
                        if (it.Value.Properties.Count == 0)
                        {
                            continue;
                        }
                        string cla = it.Key.Name;
                        var temps = it.Value.Properties.ToArray().ToList();
                        foreach (var pro in it.Value.Properties)
                        {
                            if (IsList(pro.Property))
                            {
                                Many(pro, builder);
                            }
                            else if (TypeClasses.Contains(pro.Property.PropertyType))
                            {
                                Sing(pro, builder);
                            }
                            else
                            {
                                if (OtherToSkip(temps, pro, builder))
                                {
                                    continue;
                                }
                            }
                            builder.Append(";\r\n");
                        }
                        UpdateTpl(tpl, it, builder);
                    }
                    StringPools.Release(builder);
                }
            }

            public virtual void EntityToMapStringCode(string path)
            {

            }

        }

        public class AbpNhibernateMapResolver : MapResolver
        {
            public override void Many(PropertyModel pro, StringBuilder builder)
            {
                // .ForeignKeyCascadeOnDelete().Cascade.All() .Cascade.All()
                //builder.Append($"            HasMany(x => x.{pro.PropertyName}).Cascade.All()");
                builder.Append($"            HasMany(x => x.{pro.PropertyName}).Inverse().LazyLoad().Cascade.All().NotFound.Ignore()");
            }

            public override void Sing(PropertyModel pro, StringBuilder builder)
            {
                builder.Append($"            References(x => x.{pro.PropertyName}).ForeignKey(\"fk_{pro.ColumnName}_id\").Column(\"{pro.ColumnName}_id\").Cascade.All().NotFound.Ignore()");
                //References HasOne 外键关联不了
                //builder.Append($"            References(x => x.{pro.PropertyName}).ForeignKey(\"{pro.ColumnName}_id\").Cascade.None().Access.None().NotFound.Ignore()");
            }
            public override void Id(PropertyModel pro, StringBuilder builder)
            {
                builder.Append("            Id(x => x."+pro.PropertyName+").Column(\""+pro.ColumnName+"\");\r\n");
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
                builder.Append($"           {(fk ? "//" : "")} Map(x => x.{pro.PropertyName})");
                builder.Append($".Column(\"{ColumnResolver.GetColumnName(pro.PropertyName)}\")");
                if (pro.Property.PropertyType == typeof(string))
                {
                    builder.Append($".Length({(pro.Length)})");
                }
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
                if (AbpNHibernateMapStringCodes.ContainsKey(it.Key))
                {
                    AbpNHibernateMapStringCodes[it.Key] = code;
                }
                else
                {
                    AbpNHibernateMapStringCodes.Add(it.Key, code);
                }
            }
            public override void EntityToMap()
            {
                base.EntityToMap(AbpNHibernateMapPath);
            }
            public override void EntityToMapStringCode(string path)
            {
                EntityToStrinfCode(AbpNHibernateMapStringCodes, "Map.cs", path);
            }
        }

        public static ColumnNameResolver ColumnResolver = new ColumnNameResolver();
        public static TableNameResolver TableResolver = new TableNameResolver();
        public static readonly Dictionary<Type, string> IfTypes = new Dictionary<Type, string>(1000);
        public static readonly Dictionary<Type, string> Types = new Dictionary<Type, string>(1000);
        public static readonly Dictionary<Type, List<PropertyInfo>> Classes = new Dictionary<Type, List<PropertyInfo>>(100);
        public static readonly Dictionary<Type, string> DtoStringCodes = new Dictionary<Type, string>(100);
        public static readonly Dictionary<Type, string> ServiceStringCodes = new Dictionary<Type, string>(100);
        public static readonly Dictionary<Type, string> ControllerStringCodes = new Dictionary<Type, string>(100);


        public static readonly Dictionary<Type, string> PropertyTypes = new Dictionary<Type, string>(1000);
        public static readonly object ObjLock = new Object();
        public static List<Type> TypeClasses = new List<Type>(100);
        public static int ColumnLength = 50;
        public static string NameSpace { get; set; }
        public static string ModelNameSpace { get; set; }

        public static AbpNhibernateMapResolver AbpNhibernateMap = new AbpNhibernateMapResolver();
        public static Dictionary<Type, String> AbpNHibernateMapStringCodes = new Dictionary<Type, string>(100);
        static bool isRegister = false;

        public static void Register()
        {
            if (!isRegister)
            {
                lock (ObjLock)
                {
                    if (!isRegister)
                    {
                        InitType();
                        isRegister = true;
                    }
                }
            }
        }

        public static void InitType()
        {
            initIfValueType(typeof(sbyte), typeof(sbyte?));
            initIfValueType(typeof(byte), typeof(byte?));

            initIfValueType(typeof(short), typeof(short?));
            initIfValueType(typeof(ushort), typeof(ushort?));

            initIfValueType(typeof(uint), typeof(uint?));
            initIfValueType(typeof(int), typeof(int?));

            initIfValueType(typeof(ulong), typeof(ulong?));
            initIfValueType(typeof(long), typeof(long?));

            IfTypes.Add(typeof(bool), "if(@name){ @code }\r\n");
            IfTypes.Add(typeof(bool?), "if(@name.HasValue&&@name){ @code }\r\n");
            initValueType(typeof(bool), typeof(bool?));

            //initIfValueType(typeof(DateTime), typeof(DateTime?));
            IfTypes.Add(typeof(DateTime), "if(@name==default(DateTime)){ @code }\r\n");
            IfTypes.Add(typeof(DateTime?), "if(@name.HasValue&&@name!=default(DateTime)){ @code }\r\n");
            initValueType(typeof(DateTime), typeof(DateTime?));

            IfTypes.Add(typeof(char), "if(@name==default(char)){\r@code\r\n}\r\n");
            IfTypes.Add(typeof(char?), "if(@name.HasValue&&@name!=default(char)){ @code }\r\n");
            initValueType(typeof(char), typeof(char?));

            initIfValueType(typeof(float), typeof(float?));
            initIfValueType(typeof(double), typeof(double?));
            initIfValueType(typeof(decimal), typeof(decimal?));

            IfTypes.Add(typeof(string), "if(!string.IsNullOrEmpty(@name)){ @code }\r\n");
            Types.Add(typeof(string), "string");

            IfTypes.Add(typeof(Nullable), "if(@name!=null){ @code }\r\n");
            IfTypes.Add(typeof(List<>), "if(@name!=null||@name.Count>0){ @code }\r\n");

           


        }



        public static void initIfValueType(Type type, Type nullType)
        {
            IfTypes.Add(type, "if(@name>0){ @code }\r\n");
            IfTypes.Add(nullType, "if(@name.HasValue&&@name.Value>0){ @code }\r\n");

            initValueType(type, nullType);
        }
        public static void initValueType(Type type, Type nullType)
        {
            Types.Add(type, type.Name);
            Types.Add(nullType, nullType.GenericTypeArguments[0].Name + "?");
        }


        public static void ParseEntity(Assembly asssembly, List<string> namepSpaces,Func<Type,bool> skip=null)
        {
            if (asssembly != null)
            {
                foreach (var module in asssembly.Modules)
                {
                    foreach (var type in module.GetTypes())
                    {

                        if (type.IsAbstract || type.IsEnum||type.IsInterface||type.IsGenericType)
                        {
                            continue;
                        }
                        if (skip != null&& skip(type))
                        {
                            continue;
                        }
                        if (namepSpaces.Contains(type.Namespace))
                        {
                            if (Classes.ContainsKey(type))
                            {
                                var list = Classes[type];
                                list.Clear();
                                list.AddRange(type.GetProperties());
                            }
                            else
                            {
                                TypeClasses.Add(type);
                                var list = new List<PropertyInfo>(100);
                                Classes.Add(type, list);
                                list.AddRange(type.GetProperties());
                            }
                        }
                    }
                }
            }
            EntityToModel();
        }

        public static void ParseEntity(List<Type> types)
        {
            foreach (var type in types)
            {
                if (type.IsAbstract || type.IsEnum || type.IsInterface || type.IsGenericType)
                {
                    continue;
                }
                if (Classes.ContainsKey(type))
                {
                    var list = Classes[type];
                    list.Clear();
                    list.AddRange(type.GetProperties());
                }
                else
                {
                    TypeClasses.Add(type);
                    var list = new List<PropertyInfo>(100);
                    Classes.Add(type, list);
                    list.AddRange(type.GetProperties());
                }
            }
            EntityToModel();
        }

        //自动动生成 手动处理 
        public static void EntityToAbpDto()
        {
            EntityToDto(AbpDtoPath, EntityToAbpDto);
        }

        public static string EntityToAbpDto(KeyValuePair<Type, List<PropertyInfo>> it, string tpl, string tp, string cla, string code)
        {
            //string create = tp.Replace("{.class}", it.Key.Name).Replace("{.class_dto}", "Create" + cla + "Input").Replace("{.string_code}", code);
            //string update = tp.Replace("{.class}", it.Key.Name).Replace("{.class_dto}", "Update" + cla + "Input : IEntityDto<long?>").Replace("{.string_code}", code);
            //string input = tp.Replace("{.class}", it.Key.Name).Replace("{.class_dto}", "Query" + cla + "Input").Replace("{.string_code}", code);
            //string output = tp.Replace("{.class}", it.Key.Name).Replace("{.class_dto}", "Query" + cla + "Output : IEntityDto<long?>").Replace("{.string_code}", code);
            string name = TableResolver.GetName(it.Key.Name);
            string create = tp.Replace("{.class}", name).Replace("{.class_dto}", "Create" + cla + "Input").Replace("{.string_code}", code);
            string update = tp.Replace("{.class}", name).Replace("{.class_dto}", "Update" + cla + "Input : Create" + cla + "Input,IEntityDto<long?>").Replace("{.string_code}", "");
            string input = tp.Replace("{.class}", name).Replace("{.class_dto}", "Query" + cla + "Input   : Create" + cla + "Input").Replace("{.string_code}", "");
            string output = tp.Replace("{.class}", name).Replace("{.class_dto}", "Query" + cla + "Output : Create" + cla + "Input,IEntityDto<long?>").Replace("{.string_code}", "");
            var dtoCode = tpl.Replace("{.namespace}", NameSpace).Replace("{.class_namespace}", it.Key.Namespace).Replace("{.string_code}",
                  create + update + input + output);
            return dtoCode;
        }
        public static void EntityToAbpDtoStrinfCode(string path)
        {
            EntityToStrinfCode(DtoStringCodes, "Dto.cs", path);
        }

        public static void EntityToStrinfCode(Dictionary<Type,string> StringCodes,string sufix, string path)
        {
            if (StringCodes.Count > 0)
            {
                FileHelper.CreateDirectory(path);
                foreach (var it in StringCodes)
                {
                    FileHelper.WriteFile($"{path}/{TableResolver.GetName(it.Key.Name)}{sufix}", it.Value);
                }
            }
        }

        public static void EntityToAbpService(string repositoryNameSpace)
        {
            EntityToService(AbpServicePath,repositoryNameSpace);
        }
        public static void EntityToAbpServiceStrinfCode(string path)
        {
            EntityToStrinfCode(ServiceStringCodes, "AppService.cs", path);
        }
        public static void EntityToAbpController(string dtoNameSpace, string repositoryNameSpace, string serviceNameSpace)
        {
            EntityToController(AbpControllerPath,repositoryNameSpace,serviceNameSpace);
        }
        public static void EntityToAbpControllerStrinfCode(string path)
        {
            EntityToStrinfCode(ControllerStringCodes, "Controller.cs", path);
        }

        public static void EntityToResource(string path)
        {
            if (CsharepGeneratorHelper.ValidateStringCodes.Count > 0)
            {
                StringBuilder builder = new StringBuilder(10000);
                StringBuilder builder1 = new StringBuilder(10000);
                foreach (var item in CsharepGeneratorHelper.ValidateStringCodes)
                {
                    builder.Append("        /// <summary>   查找类似 11 的本地化字符串。</summary>\r\n");
                    builder.Append("        internal static string " + item.Key.Replace(".", "_") + " {\r\n");
                    builder.Append("            get {\r\n");
                    builder.Append("                return ResourceManager.GetString(\"" + item.Key + "\", resourceCulture);\r\n");
                    builder.Append("            }\r\n        }\r\n");

                    builder1.Append("  <data name=\"" + item.Key + "\" xml:space=\"preserve\">\r\n");
                    builder1.Append("    <value>" + item.Value + "</value>\r\n");
                    builder1.Append("  </data>\r\n");
                }
                string tp = FileHelper.ReadFile(ResourcePath);
                string code = tp.Replace("{.string_code}", builder1.ToString());
                FileHelper.WriteFile(path + "/Resource.resx", code);
                tp = FileHelper.ReadFile(ResourceDesignerPath);
                code = tp.Replace("{.string_code}", builder.ToString());
                FileHelper.WriteFile(path + "/Resource.Designer.cs", code);
                // FileHelper.WriteFile(path + "/Shop.Api/validate.json",JsonHelper.ToJson(CsharepGeneratorHelper.ValidateStringCodes));
            }


        }
    }
}