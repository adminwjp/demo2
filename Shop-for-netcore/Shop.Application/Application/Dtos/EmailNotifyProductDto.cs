using System;
namespace  Shop.Application.Services.Dtos
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using Shop.Domain.Entities;
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using EventCloud;

    [AutoMap(typeof(EmailNotifyProduct))]
    public  class CreateEmailNotifyProductInput
     {
        private Int64 id;
        private Char status;
        private DateTime notifydate;
        private string productName;
        private string receiveEmail;
        private string productID;
        private Int32 sendFailureCount;
        private string account;
        private Int64? sellerId;
        private Int64? buyerId;
        protected virtual void OnPropertyChanged( string propertyName = null){}
        public virtual Int64 Id
        {
            get { return this.id; }
            set { this.id = value; if (id > 0) { OnPropertyChanged("Id"); } }
        }
        public virtual Char Status
        {
            get{    return this.status;}
            set{    this.status=value; if(status==default(char)){OnPropertyChanged("Status");}}
        }
        public virtual DateTime Notifydate
        {
            get{    return this.notifydate;}
            set{    this.notifydate=value; if(notifydate==default(DateTime)){ OnPropertyChanged("Notifydate"); }}
        }
        [Required(ErrorMessageResourceName ="email_notify_product_product_name", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "email_notify_product_product_name_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ProductName
        {
            get{    return this.productName;}
            set{    this.productName=value; if(!string.IsNullOrEmpty(productName)){ OnPropertyChanged("ProductName"); }}
        }
        [Required(ErrorMessageResourceName ="email_notify_product_receive_email", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "email_notify_product_receive_email_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ReceiveEmail
        {
            get{    return this.receiveEmail;}
            set{    this.receiveEmail=value; if(!string.IsNullOrEmpty(receiveEmail)){ OnPropertyChanged("ReceiveEmail"); }}
        }
        [Required(ErrorMessageResourceName ="email_notify_product_product_i_d", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "email_notify_product_product_i_d_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ProductID
        {
            get{    return this.productID;}
            set{    this.productID=value; if(!string.IsNullOrEmpty(productID)){ OnPropertyChanged("ProductID"); }}
        }
        public virtual Int32 SendFailureCount
        {
            get{    return this.sendFailureCount;}
            set{    this.sendFailureCount=value; if(sendFailureCount>0){ OnPropertyChanged("SendFailureCount"); }}
        }
        [Required(ErrorMessageResourceName ="email_notify_product_account", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "email_notify_product_account_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Account
        {
            get{    return this.account;}
            set{    this.account=value; if(!string.IsNullOrEmpty(account)){ OnPropertyChanged("Account"); }}
        }
        public virtual Int64? SellerId
        {
            get{    return this.sellerId;}
            set{    this.sellerId=value; if(sellerId.HasValue&&sellerId.Value>0){ OnPropertyChanged("SellerId"); }}
        }
        public virtual Int64? BuyerId
        {
            get{    return this.buyerId;}
            set{    this.buyerId=value; if(buyerId.HasValue&&buyerId.Value>0){ OnPropertyChanged("BuyerId"); }}
        }

    }
    [AutoMap(typeof(EmailNotifyProduct))]
    public  class UpdateEmailNotifyProductInput : CreateEmailNotifyProductInput,IEntityDto<long>
     {

    }
    [AutoMap(typeof(EmailNotifyProduct))]
    public  class QueryEmailNotifyProductInput   : CreateEmailNotifyProductInput
     {

    }
    [AutoMap(typeof(EmailNotifyProduct))]
    public  class QueryEmailNotifyProductOutput : CreateEmailNotifyProductInput,IEntityDto<long>
     {

    }


}