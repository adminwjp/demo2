#if Abp_NHibernate
namespace Template.Api.EntityMappings
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Template.Api.Models;

    public class TableMap:EntityMap<TableModel,long?>
    {
        public TableMap():base("t_table"){
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.ClassName).Column("class_name").Length(50);
            Map(x => x.TablemName).Column("table_name").Length(50);
            Map(x => x.Remark).Column("remark").Length(50);
            Map(x => x.Title).Column("title").Length(50);
           // Map(x => x.DatabaseId).Column("database_id");
            References(x => x.Database).ForeignKey("fk_database_id").Column("database_id")//.Cascade.None()
			.NotFound.Ignore();
            //Cascade.All() ex HasManyToMany ReferencesAny
            HasMany(x => x.ColumnModels).AsSet().KeyColumn("fk_table_id").KeyColumn("table_id")
               .Inverse()//.LazyLoad()//.Fetch.Join()
                                    //.Cascade.All()
									 .Cascade.None();
									 //.NotFound.Ignore();
               // .Fetch.Join();//.ForeignKeyCascadeOnDelete().Cascade.None();

           //Id(x => x.Id).Not.Nullable().Length(36);//主键
           // Map(x => x.CreationTime).Nullable();
           // Map(x => x.ModificationTime).Nullable();
           // Map(x => x.DeletionTime).Nullable();
           // Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}
#endif