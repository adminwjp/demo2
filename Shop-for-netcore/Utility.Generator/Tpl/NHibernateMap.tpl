namespace {.namespace}
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using {.class_namespace};

    public class {.class_map}:NHibernate.Mapping.ByCode.Conformist.ClassMapping<{.class}>
    {
        public {.class_map}()
        {
            Set();
        }
        public {.class_map}(string tableName)
        {
            Table(tableName);
            Lazy(false);
            //Id(x => x.Id, map =>{});
            Set();
        }
        protected virtual void Set(){
{.string_code}
        }
    }
}