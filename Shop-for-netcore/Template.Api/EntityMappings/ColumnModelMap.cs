#if Abp_NHibernate
namespace Template.Api.EntityMappings
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Template.Api.Models;

    public class ColumnMap:EntityMap<ColumnModel,long?>
    {
        public ColumnMap():base("t_column"){
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.CloumName).Column("cloum_name").Length(50);
            Map(x => x.PropertyName).Column("property_name").Length(50);
            Map(x => x.Remark).Column("remark").Length(50);
            Map(x => x.CsharepPropertyType).Column("csharep_property_type").Length(50);
            Map(x => x.Title).Column("title").Length(50);
           // Map(x => x.TableId).Column("table_id");
            References(x => x.Table).ForeignKey("fk_table_id").Column("table_id")//.Cascade.None()
			.NotFound.Ignore();

           //Id(x => x.Id).Not.Nullable().Length(36);//主键
           // Map(x => x.CreationTime).Nullable();
           // Map(x => x.ModificationTime).Nullable();
           // Map(x => x.DeletionTime).Nullable();
           // Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}
#endif