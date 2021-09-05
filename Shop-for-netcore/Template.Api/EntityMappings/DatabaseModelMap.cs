#if Abp_NHibernate
namespace Template.Api.EntityMappings
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Template.Api.Models;

    public class DatabaseMap:EntityMap<DatabaseModel,long?>
    {
        public DatabaseMap():base("t_database"){
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("name").Length(50);
            Map(x => x.ProgramName).Column("program_name").Length(50);
            Map(x => x.Remark).Column("remark").Length(50);
            HasMany(x => x.TableModels).AsSet().ForeignKeyConstraintName("fk_database_id").KeyColumn("database_id")
                .Inverse()//.LazyLoad()//.Fetch.Join()
                                     //.Cascade.All()
									 .Cascade.None();
									 //.NotFound.Ignore();
               //.Fetch.Join();
            //Id(x => x.Id).Not.Nullable().Length(36);//主键
            // Map(x => x.CreationTime).Nullable();
            // Map(x => x.ModificationTime).Nullable();
            // Map(x => x.DeletionTime).Nullable();
            // Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}
#endif