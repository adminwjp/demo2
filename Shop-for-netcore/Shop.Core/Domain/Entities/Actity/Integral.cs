namespace Shop.Domain.Entities
{
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    
    //积分
    public class Integral
    {
         public virtual bool IsTransient(){
            return true;
        }
    }

    
    public class BuyerIntegral:IEntity<long>
    {
        public virtual long Id { get; set; }
        public virtual long? SingnId { get; set; }
        public virtual int Score { get; set; }
        public virtual bool IsTransient()
        {
            return true;
        }
    }
    public enum IntegralFlag
    {
        Sign,
        Prize

    }

    public class SellerIntegralSetting : IEntity<long>
    {
        public virtual long Id { get; set; }
        public virtual IntegralFlag Flag { get; set; }
        public virtual long? StartDate { get; set; }
        public virtual long? EndDate { get; set; }
        public virtual int CosIntegral { get; set; }

        public virtual bool IsTransient()
        {
            return true;
        }
    }
    public class BuyerPrizeLog : IEntity<long>
    {
        public virtual long Id { get; set; }
        public virtual long? SellerIntegralSettingId { get; set; }

        public virtual int CosIntegral { get; set; }
        //buyer buyer_id
        public virtual long? UserId { get; set; }
        public virtual bool IsTransient()
        {
            return true;
        }
    }
    public class SellerPrize : IEntity<long>
    {
        public virtual long Id { get; set; }
        public virtual long? StartDate { get; set; }
        public virtual long? EndDate { get; set; }
        public virtual int CosIntegral { get; set; }
        //seller seller_id
        public virtual long? UserId { get; set; }
        public virtual long? SellerPrizeSettingId { get; set; }

        public virtual bool IsTransient()
        {
            return true;
        }
    }
    public class SellerPrizeSetting : IEntity<long>
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        //seller seller_id
        public virtual long? UserId { get; set; }


        public virtual bool IsTransient()
        {
            return true;
        }
    }
}