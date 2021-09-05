namespace Shop.Domain.Entities
{
    
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    
    //满减送
    public class FullReduction
    {
     
    }
    public class BuyerFullReduction:IEntity<long>
    {
        public virtual long Id { get; set; }

        public virtual decimal? Total { get; set; }

        public virtual decimal? CouponFee { get; set; }

        //seller seller_id
        public virtual long? UserId { get; set; }

        public virtual bool IsTransient(){
            return true;
        }
    }
}