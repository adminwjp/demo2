namespace Shop.Domain.Entities
{
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    //优惠券
    public class Coupon
    {
        
    }

    public class SellerCoupon:IEntity<long>
    {
        public virtual long Id { get; set; }
        //1,2,3 该商品支持优惠券
        public virtual string ProductIds { get; set; }
        

        //1,2,3 该商品分类支持优惠券
        public virtual string CatagoryIds { get; set; }
        //seller seller_id
        public virtual long? UserId { get; set; }

        public virtual bool IsTransient()
        {
            return true;
        }
    }

    public enum CouponFlag { 
        Cos,
        Product,
        ProductFullReduction,
    }

    public class SellerCouponSettsing : IEntity<long>
    {
        public virtual long Id { get; set; }

        public virtual decimal? CosFee { get; set; }

        public virtual decimal? CouponFee { get; set; }

        public virtual CouponFlag Flag { get; set; }


        //seller seller_id
        public virtual long? UserId { get; set; }

        public virtual bool IsTransient()
        {
            return true;
        }
    }
}