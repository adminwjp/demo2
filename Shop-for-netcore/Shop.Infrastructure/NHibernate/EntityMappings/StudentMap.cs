namespace Shop.NHibernate.EntityMappings
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Shop.Domain.Entities;

    public class StudentMap:EntityMap<Student,long>
    {
        public  StudentMap():base("t_student")
        {
            Id(x => x.Id);
            // Id(x => x.Id).Not.Nullable().Length(36);//主键
            Map(x => x.Name).Column("name");
            Map(x => x.Age).Column("age");
            References(x => x.Class).ForeignKey("fk_class_id").Column("class_id").Cascade.None();
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