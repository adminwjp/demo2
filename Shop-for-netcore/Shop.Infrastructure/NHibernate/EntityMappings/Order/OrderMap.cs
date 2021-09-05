namespace Shop.NHibernate.EntityMappings
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Shop.Domain.Entities;

    public class OrderMap:EntityMap<Order,long>
    {
        public OrderMap():base("t_order"){
           //Id(x => x.Id);
            Id(x => x.Id).Column("id");
            Map(x => x.CartId).Column("cart_id");
            Map(x => x.ProductIds).Column("product_ids").Length(1000);
             Map(x => x.OrderDetailsIds).Column("order_details_ids").Length(1000);
            Map(x => x.Status).Column("status");
            Map(x => x.Score).Column("score");
            Map(x => x.Ptotal).Column("ptotal");
            Map(x => x.UpdateAmount).Column("update_amount");
            Map(x => x.ExpressCompanyName).Column("express_company_name").Length(50);
            Map(x => x.PayType).Column("pay_type");
            Map(x => x.Rebate).Column("rebate");
            Map(x => x.Carry).Column("carry");
            Map(x => x.LowStocks).Column("low_stocks").Length(50);
            Map(x => x.RefundStatus).Column("refund_status").Length(50);
            Map(x => x.Fee).Column("fee");
            Map(x => x.OtherRequirement).Column("other_requirement").Length(50);
            Map(x => x.Paystatus).Column("paystatus").Length(50);
            Map(x => x.Remark).Column("remark").Length(50);
            Map(x => x.ClosedComment).Column("closed_comment");
            Map(x => x.ExpressNo).Column("express_no").Length(50);
            Map(x => x.ExpressName).Column("express_name").Length(50);
            Map(x => x.Quantity).Column("quantity");
            Map(x => x.ConfirmSendProductRemark).Column("confirm_send_product_remark").Length(50);
            Map(x => x.ExpressCode).Column("express_code").Length(50);
            Map(x => x.Account).Column("account").Length(50);
            Map(x => x.UserId).Column("user_id");
            Map(x => x.Amount).Column("amount");

           //Id(x => x.Id).Not.Nullable().Length(36);//主键
           // Map(x => x.CreationTime).Nullable();
           // Map(x => x.ModificationTime).Nullable();
           // Map(x => x.DeletionTime).Nullable();
           // Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}