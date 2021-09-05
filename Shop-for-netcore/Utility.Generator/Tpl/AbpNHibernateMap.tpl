namespace {.namespace}
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using {.class_namespace};

    public class {.class_map}:EntityMap<{.class},long?>
    {
        public {.class_map}():base("{.table_name}"){
           //Id(x => x.Id);
{.string_code}
           //Id(x => x.Id).Not.Nullable().Length(36);//主键
           // Map(x => x.CreationTime).Nullable();
           // Map(x => x.ModificationTime).Nullable();
           // Map(x => x.DeletionTime).Nullable();
           // Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}