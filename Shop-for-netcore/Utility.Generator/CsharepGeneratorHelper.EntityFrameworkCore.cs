namespace Utility.Generator
{   
    using System;
     using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Utility.Helpers;
    using Utility.IO;
    using System.Linq;

    public partial class CsharepGeneratorHelper
    {
        public static string EntityFrameworkCoreMapPath = "tpl/EntityFrameworkCoreMap.tpl";
        public static Dictionary<Type, String> EntityFrameworkCoreMapStringCodes = new Dictionary<Type, string>(100);
        public static EntityFrameworkCoreMapResolver EntityFrameworkCoreMap = new EntityFrameworkCoreMapResolver();
        public class EntityFrameworkCoreMapResolver : MapResolver
        {
            public override void Many(PropertyModel pro, StringBuilder builder)
            {
                builder.Append($"            builder.HasMany(x => x.{pro.PropertyName})");
            }
            public override void Sing(PropertyModel pro, StringBuilder builder)
            {
                //需要手动 编辑修改
                builder.Append($"            builder.HasOne(x => x.{pro.PropertyName}).WithOne(\"{pro.ColumnName}_id\")");
            }

            public override void EntityToMap()
            {
                base.EntityToMap(EntityFrameworkCoreMapPath);
            }
            public override bool OtherToSkip(List<PropertyModel> temps, PropertyModel pro, StringBuilder builder)
            {
                bool fk = false;
                if (pro.PropertyName.EndsWith("Id"))
                {
                    if (pro.PropertyName == "Id")
                    {
                        builder.Append($"            builder.HasKey(it => it.{pro.PropertyName}).HasName(\"{pro.ColumnName}\");//.HasAnnotation(\"MySql: ValueGenerationStrategy\", MySqlValueGenerationStrategy.IdentityColumn);\r\n");
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
                builder.Append($"           {(fk ? "//" : "")}builder.Property(x => x.{pro.PropertyName})");
                builder.Append($".HasColumnName(\"{pro.ColumnName}\")");
                if (pro.Property.PropertyType == typeof(string))
                {
                    builder.Append($".HasMaxLength({pro.Length})");
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
                if (EntityFrameworkCoreMapStringCodes.ContainsKey(it.Key))
                {
                    EntityFrameworkCoreMapStringCodes[it.Key] = code;
                }
                else
                {
                    EntityFrameworkCoreMapStringCodes.Add(it.Key, code);
                }
            }

            public override void EntityToMapStringCode(string path)
            {
                EntityToStrinfCode(EntityFrameworkCoreMapStringCodes, "Map.cs", path);
            }
        }
        public static List<Type> GetTypes(Assembly assembly)
        {
            if (assembly == null)
            {
                return null;
            }
            List<Type> types = new List<Type>();
            foreach (var module in assembly.GetModules())
            {
                types.AddRange(module.GetTypes());
            }
            return types;
        }
    }
}