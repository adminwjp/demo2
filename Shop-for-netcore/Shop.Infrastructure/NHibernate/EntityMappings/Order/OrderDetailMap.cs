namespace Shop.NHibernate.EntityMappings
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Shop.Domain.Entities;

    public class OrderDetailMap:EntityMap<OrderDetail,long>
    {
        public OrderDetailMap():base("t_order_detail"){
           //Id(x => x.Id);
            Id(x => x.Id).Column("id");
            Map(x => x.ProductId).Column("product_id");
            Map(x => x.Fee).Column("fee");
            Map(x => x.IsComment).Column("is_comment").Length(50);
            Map(x => x.SellerId).Column("seller_id");
            Map(x => x.UserId).Column("user_id");
            Map(x => x.ProductName).Column("product_name").Length(50);
            Map(x => x.GiftId).Column("gift_id").Length(50);
            Map(x => x.OrderId).Column("order_id");
            Map(x => x.Orders).Column("orders");
            Map(x => x.SpecInfo).Column("spec_info").Length(50);
            Map(x => x.Score).Column("score");
            Map(x => x.Number).Column("number");
            Map(x => x.LowStocks).Column("low_stocks").Length(50);
            Map(x => x.Price).Column("price");
            Map(x => x.Total).Column("total");

           //Id(x => x.Id).Not.Nullable().Length(36);//主键
           // Map(x => x.CreationTime).Nullable();
           // Map(x => x.ModificationTime).Nullable();
           // Map(x => x.DeletionTime).Nullable();
           // Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}