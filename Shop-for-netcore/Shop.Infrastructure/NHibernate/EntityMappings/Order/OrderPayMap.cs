namespace Shop.NHibernate.EntityMappings
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Shop.Domain.Entities;

    public class OrderPayMap:EntityMap<OrderPay,long>
    {
        public OrderPayMap():base("t_order_pay"){
           //Id(x => x.Id);
            Id(x => x.Id).Column("id");
            Map(x => x.OrderId).Column("order_id");
            Version(x => x.ConfirmDate).Column("confirm_date");
            Map(x => x.TradeNo).Column("trade_no").Length(50);
            Map(x => x.Remark).Column("remark").Length(50);
            Map(x => x.PayMethod).Column("pay_method").Length(50);
            Map(x => x.PayAmount).Column("pay_amount");
            Map(x => x.ConfirmUser).Column("confirm_user");
            Map(x => x.SellerId).Column("seller_id");
            Map(x => x.UserId).Column("user_id");
            Map(x => x.PayStatus).Column("pay_status");

           //Id(x => x.Id).Not.Nullable().Length(36);//主键
           // Map(x => x.CreationTime).Nullable();
           // Map(x => x.ModificationTime).Nullable();
           // Map(x => x.DeletionTime).Nullable();
           // Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}