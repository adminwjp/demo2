using System;
namespace  Shop.Application.Services.Dtos
{
    using EventCloud;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using Shop.Domain.Entities;
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;

    [AutoMap(typeof(OrderLog))]
    public  class CreateOrderLogInput
     {
        private Int64 id;
        private string orderId;
        private string content;
        private string accountType;
        private string account;
        protected virtual void OnPropertyChanged( string propertyName = null){}
        public virtual Int64 Id
        {
            get { return this.id; }
            set { this.id = value; if (id > 0) { OnPropertyChanged("Id"); } }
        }
        [Required(ErrorMessageResourceName ="order_log_order_id", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_log_order_id_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string OrderId
        {
            get{    return this.orderId;}
            set{    this.orderId=value; if(!string.IsNullOrEmpty(orderId)){ OnPropertyChanged("OrderId"); }}
        }
        [Required(ErrorMessageResourceName ="order_log_content", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_log_content_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Content
        {
            get{    return this.content;}
            set{    this.content=value; if(!string.IsNullOrEmpty(content)){ OnPropertyChanged("Content"); }}
        }
        [Required(ErrorMessageResourceName ="order_log_account_type", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_log_account_type_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string AccountType
        {
            get{    return this.accountType;}
            set{    this.accountType=value; if(!string.IsNullOrEmpty(accountType)){ OnPropertyChanged("AccountType"); }}
        }
        [Required(ErrorMessageResourceName ="order_log_account", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_log_account_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Account
        {
            get{    return this.account;}
            set{    this.account=value; if(!string.IsNullOrEmpty(account)){ OnPropertyChanged("Account"); }}
        }

    }
    [AutoMap(typeof(OrderLog))]
    public  class UpdateOrderLogInput : CreateOrderLogInput,IEntityDto<long>
     {

    }
    [AutoMap(typeof(OrderLog))]
    public  class QueryOrderLogInput   : CreateOrderLogInput
     {

    }
    [AutoMap(typeof(OrderLog))]
    public  class QueryOrderLogOutput : CreateOrderLogInput,IEntityDto<long>
     {

    }


}