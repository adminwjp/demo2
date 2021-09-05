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

    [AutoMap(typeof(OrderPay))]
    public  class CreateOrderPayInput
     {
        private Int64 id;
        private string orderId;
        private DateTime confirmDate;
        private string tradeNo;
        private string remark;
        private string payMethod;
        private Decimal? payAmount;
        private string confirmUser;
        private string payStatus;
        protected virtual void OnPropertyChanged( string propertyName = null){}
        public virtual Int64 Id
        {
            get { return this.id; }
            set { this.id = value; if (id > 0) { OnPropertyChanged("Id"); } }
        }
        [Required(ErrorMessageResourceName ="order_pay_order_id", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_pay_order_id_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string OrderId
        {
            get{    return this.orderId;}
            set{    this.orderId=value; if(!string.IsNullOrEmpty(orderId)){ OnPropertyChanged("OrderId"); }}
        }
        public virtual DateTime ConfirmDate
        {
            get{    return this.confirmDate;}
            set{    this.confirmDate=value; if(confirmDate==default(DateTime)){ OnPropertyChanged("ConfirmDate"); }}
        }
        [Required(ErrorMessageResourceName ="order_pay_trade_no", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_pay_trade_no_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string TradeNo
        {
            get{    return this.tradeNo;}
            set{    this.tradeNo=value; if(!string.IsNullOrEmpty(tradeNo)){ OnPropertyChanged("TradeNo"); }}
        }
        [Required(ErrorMessageResourceName ="order_pay_remark", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_pay_remark_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Remark
        {
            get{    return this.remark;}
            set{    this.remark=value; if(!string.IsNullOrEmpty(remark)){ OnPropertyChanged("Remark"); }}
        }
        [Required(ErrorMessageResourceName ="order_pay_pay_method", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_pay_pay_method_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string PayMethod
        {
            get{    return this.payMethod;}
            set{    this.payMethod=value; if(!string.IsNullOrEmpty(payMethod)){ OnPropertyChanged("PayMethod"); }}
        }
        public virtual Decimal? PayAmount
        {
            get{    return this.payAmount;}
            set{    this.payAmount=value; if(payAmount.HasValue&&payAmount.Value>0){ OnPropertyChanged("PayAmount"); }}
        }
        [Required(ErrorMessageResourceName ="order_pay_confirm_user", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_pay_confirm_user_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ConfirmUser
        {
            get{    return this.confirmUser;}
            set{    this.confirmUser=value; if(!string.IsNullOrEmpty(confirmUser)){ OnPropertyChanged("ConfirmUser"); }}
        }
        [Required(ErrorMessageResourceName ="order_pay_pay_status", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_pay_pay_status_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string PayStatus
        {
            get{    return this.payStatus;}
            set{    this.payStatus=value; if(!string.IsNullOrEmpty(payStatus)){ OnPropertyChanged("PayStatus"); }}
        }

    }
    [AutoMap(typeof(OrderPay))]
    public  class UpdateOrderPayInput : CreateOrderPayInput,IEntityDto<long>
     {

    }
    [AutoMap(typeof(OrderPay))]
    public  class QueryOrderPayInput   : CreateOrderPayInput
     {

    }
    [AutoMap(typeof(OrderPay))]
    public  class QueryOrderPayOutput : CreateOrderPayInput,IEntityDto<long>
     {

    }


}