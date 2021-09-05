namespace Shop.Domain.Entities
{
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Abp.Authorization.Users;
    using Abp.Authorization.Roles;

  
    public class User: User<User>
    {

    }
    public abstract class User<T> : AbpUser<T>, IEntity<Int64>, IHasDeletionTime
        where T:User<T>
    {
       // public virtual long? Id {get;set;}

  
        public virtual String Realname { get; set; }
        public virtual String Headimgurl { get; set; }
        public virtual String OpenId { get; set; }
        public virtual String ImQq { get; set; }


        public virtual String AuthAppId { get; set; }
        public virtual String Language { get; set; }
        public virtual String City { get; set; }
        public virtual String Province { get; set; }
        public virtual String Country { get; set; }
        public virtual int Subscribe { get; set; }
        public virtual long SubscribeTime { get; set; }
        public virtual long Groupid { get; set; }
        public virtual String Remark { get; set; }
        public virtual long AccessIp { get; set; }
        public virtual String RefreshToken { get; set; }
        public virtual long TokenExpiresIn { get; set; }
        public virtual long LastLoginDate { get; set; }
        public virtual string Unionid { get; set; }
        public virtual int Score { get; set; }
        //Buyer -1 0 Î´»Ø¸´ 1 »Ø¸´
        public virtual int IsReceiver { get; set; }


        public virtual String Account {get;set;}
        public virtual String Phone {get;set;}
        public virtual String Email {get;set;}
        public virtual String Pwd {get;set;}
        //public virtual String Name {get;set;}
        public virtual  int Age {get;set;}
        public virtual String Sex {get;set;}
        [StringLength(100)]
        public virtual String  Address {get;set;}
        public virtual long Bir {get;set;}
        public virtual String Postcode {get;set;}
        public virtual float Balance {get;set;}
        public virtual  long LoginIp {get;set;}
        public virtual long RegisterIp {get;set;}
        public virtual   bool IsLoginPc {get;set;}
        public virtual   int PcFlag {get;set;}
        public virtual  bool IsLoginApp {get;set;}
        public virtual  int AppFlag {get;set;}
        public virtual  bool IsLoginWxProgram {get;set;}
        public virtual  bool IsLoginBrower {get;set;}
        public virtual  long RegDate {get;set;}
        public virtual  long LoginDate {get;set;}

       // public virtual DateTime? DeletionTime { get; set; }
        //public virtual bool IsDeleted { get; set; }

        //public virtual bool IsTransient(){
        //    return true;
        //}
    }

    public class Seller: User<Seller>
    {
        public virtual int UserLevel { get; set; }
        public virtual long StartDate { get; set; }
        public virtual long EndDate { get; set; }
        public virtual int VersionNo { get; set; }
        public virtual int LoginFailureCount { get; set; }
    }

    public class Agent : IEntity<Int64?>
    {
        public virtual long? Id { get; set; }
        public virtual long? SellerId { get; set; }
        public virtual long? BuyerId { get; set; }
        public virtual long? ParentId { get; set; }
        public virtual string AgentName { get; set; }
        public virtual string AgentPhone { get; set; }
        public virtual string Password { get; set; }
        public virtual string AgentAddr { get; set; }
        public virtual long? ExpireDate { get; set; }
        public virtual long? AuditDate { get; set; }
        public virtual int Status { get; set; }
        public virtual bool IsTransient()
        {
            return true;
        }
    }
    public class Manufacturer : User<Manufacturer>
    {

    }
    public class AgentRank : IEntity<Int64?>
    {
        public virtual long? Id { get; set; }
        public virtual long? SellerId { get; set; }
        public virtual string RankName { get; set; }
        public virtual long RankWeight { get; set; }
        public virtual decimal FirstRate { get; set; }
        public virtual decimal SecondRate { get; set; }
        public virtual decimal ThirdRate { get; set; }
        public virtual long? RewardValue { get; set; }
        public virtual long? GetCashTime { get; set; }
        public virtual long? GetCashLimit { get; set; }
        public virtual long ChildrenCount { get; set; }
        public virtual decimal TotalCommission { get; set; }
        public virtual int Status { get; set; }
        public virtual bool IsTransient()
        {
            return true;
        }
    }

    public class AgentCommission : IEntity<Int64?>
    {
        public virtual long? Id { get; set; }
        public virtual long? AgentId { get; set; }
        public virtual long? OrderId { get; set; }
        public virtual decimal CommissionValue { get; set; }
        public virtual bool IsTransient()
        {
            return true;
        }
    }

    public class AgentAduitLog : IEntity<Int64?>
    {
        public virtual long? Id { get; set; }
        public virtual long? AgentId { get; set; }
        public virtual int AduitOpter { get; set; }
        public virtual string Content { get; set; }
        public virtual int Status { get; set; }
        public virtual bool IsTransient()
        {
            return true;
        }
    }

    public class BuyerRecharge : IEntity<Int64?>
    {
        public virtual long? Id { get; set; }
        public virtual long? BuyerId { get; set; }
        public virtual string Recharge { get; set; }
        public virtual string OutTradeId { get; set; }
        public virtual string TransactionId { get; set; }
        public virtual int Status { get; set; }
        public virtual bool IsTransient()
        {
            return true;
        }
    }

    public class SocilWay : IEntity<Int64?>
    {
        public virtual long? Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool Enable { get; set; }
        public virtual long? UserId { get; set; }
        public virtual bool IsTransient()
        {
            return true;
        }
    }

    public abstract class BaseFriend : IEntity<Int64?>
    {
        public virtual long? Id { get; set; }
        public virtual bool IsBuyer { get; set; }
        public virtual int Status { get; set; }
        public virtual long AddDate { get; set; }
        public virtual long AgreeDate { get; set; }
        public virtual long? BuyerId { get; set; }
        public virtual long? SellerId { get; set; }
        public virtual bool IsTransient()
        {
            return true;
        }
    }
    public  class BuyerFriend: BaseFriend
    {

    }

    public class SellerFriend : BaseFriend
    {

    }
    public class AgentFriend : BaseFriend
    {
        public virtual long? AgentId { get; set; }
    }

    public class ManufacturerFriend : AgentFriend
    {
        public virtual long? ManufacturerId { get; set; }
    }
    public abstract class BaseReport
    {
        public virtual long? Id { get; set; }
        public virtual long? UserId { get; set; }
        public virtual bool IsBuyer { get; set; }
        public virtual long? ProductId { get; set; }
        public virtual long? StroeId { get; set; }
        public virtual  string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual int Aduit { get; set; }
        public virtual long? ReportDate { get; set; }
        public virtual long? UpdateDate { get; set; }
    }
    public abstract class BuyerReport: BaseReport
    {

    }

    public abstract class SellerReport : BaseReport
    {

    }
    public abstract class AgentReport : BaseReport
    {

    }
    public   class ManufacturerReport : BaseReport
    {

    }
}