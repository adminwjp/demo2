namespace Shop.NHibernate.EntityMappings
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Shop.Domain.Entities;

    public class OrderLogMap:EntityMap<OrderLog,long>
    {
        public OrderLogMap():base("t_order_log"){
           //Id(x => x.Id);
            Id(x => x.Id).Column("id");
            Map(x => x.OrderId).Column("order_id").Length(50);
            Map(x => x.Content).Column("content").Length(50);
            Map(x => x.Data).Column("data").Length(1000);
            Map(x => x.UserId).Column("user_id");
            Map(x => x.AccountType).Column("account_type").Length(50);
            Map(x => x.Account).Column("account").Length(50);

           //Id(x => x.Id).Not.Nullable().Length(36);//主键
           // Map(x => x.CreationTime).Nullable();
           // Map(x => x.ModificationTime).Nullable();
           // Map(x => x.DeletionTime).Nullable();
           // Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}