namespace Shop.NHibernate.EntityMappings
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Shop.Domain.Entities;

    public class ClassMap:EntityMap<Class,long>
    {
        public  ClassMap():base("t_class"){
            Id(x => x.Id);
           // Id(x => x.Id).Not.Nullable().Length(36);//主键
		    Map(x => x.Name).Column("name");
            Map(x => x.CreationTime).Column("create_date");
            Map(x => x.LastModificationTime).Column("modify_date");
            Map(x => x.DeletionTime).Column("delete_date");
            Map(x => x.IsDeleted).Column("is_delete");
            //this.MapCreationTime();
            //this.MapLastModificationTime();
            //this.MapIsDeleted();
            //Map(x => x.DeletionTime).Nullable();
        }
    }
}