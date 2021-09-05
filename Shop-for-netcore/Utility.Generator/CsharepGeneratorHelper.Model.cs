using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Generator
{
    public partial class CsharepGeneratorHelper
    {
        public static Dictionary<Type, ClassModel> ClassModels = new Dictionary<Type, ClassModel>(100);
        public class ClassModel
        {
            public virtual string TableName { get; set; }
            public virtual string ClassName { get; set; }
            public virtual Type ClassType { get; set; }
            public virtual List<PropertyModel> Properties { get; set; }
        }

        public class PropertyModel
        {
            public virtual PropertyInfo Property { get; set; }
            public virtual string PropertyName { get; set; }
            public virtual string ColumnName { get; set; }
            public virtual long Length { get; set; }
            public virtual string PropertyType { get; set; }
        }

        public static void EntityToModel()
        {
            if (Classes.Count > 0)
            {
                foreach (var it in Classes)
                {
                    if (it.Value.Count > 0)
                    {
                        //UserModel UserEntity UserEntry UserInfo ... -> User
                        var className = TableResolver.GetName(it.Key.Name);
                        var table = TableResolver.GetTableName(className);
                        ClassModel classModel = new ClassModel() { TableName = table, 
                            ClassName = it.Key.Name,
                            ClassType = it.Key, Properties = new List<PropertyModel>() };
                        if (ClassModels.ContainsKey(it.Key))
                        {
                            ClassModels[it.Key] = classModel;
                        }
                        else
                        {
                            ClassModels.Add(it.Key, classModel) ;
                        }
                        foreach (var pro in it.Value)
                        {
                            //string type = pro.PropertyType.Name;
                            PropertyModel propertyModel = new PropertyModel() { 
                                Property=pro,PropertyName=pro.Name,//PropertyType=pro.PropertyType.Name,
                                ColumnName=ColumnResolver.GetColumnName(pro.Name),Length=50
                            };
                            classModel.Properties.Add(propertyModel);
                        }
                    }
                }
            }
        }
    }
}
