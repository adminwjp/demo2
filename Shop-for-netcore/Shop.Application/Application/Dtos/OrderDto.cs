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

    [AutoMap(typeof(Order))]
    public  class CreateOrderInput
     {
        private Int64 id;
        private Int64? cartId;
        private string status;
        private Int32 score;
        private Decimal? ptotal;
        private Decimal updateAmount;
        private string expressCompanyName;
        private Int32 payType;
        private Decimal? rebate;
        private Int32 carry;
        private string lowStocks;
        private string refundStatus;
        private Decimal? fee;
        private string otherRequirement;
        private string paystatus;
        private string remark;
        private string closedComment;
        private string expressNo;
        private string expressName;
        private Int32 quantity;
        private string confirmSendProductRemark;
        private string expressCode;
        private string account;
        private Int64? buyerId;
        private Decimal? amount;
        protected virtual void OnPropertyChanged( string propertyName = null){}
        public virtual Int64 Id
        {
            get { return this.id; }
            set { this.id = value; if (id > 0) { OnPropertyChanged("Id"); } }
        }
        public virtual Int64? CartId
        {
            get{    return this.cartId;}
            set{    this.cartId=value; if(cartId.HasValue&&cartId.Value>0){ OnPropertyChanged("CartId"); }}
        }
        [Required(ErrorMessageResourceName ="order_status", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_status_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Status
        {
            get{    return this.status;}
            set{    this.status=value; if(!string.IsNullOrEmpty(status)){ OnPropertyChanged("Status"); }}
        }
        public virtual Int32 Score
        {
            get{    return this.score;}
            set{    this.score=value; if(score>0){ OnPropertyChanged("Score"); }}
        }
        public virtual Decimal? Ptotal
        {
            get{    return this.ptotal;}
            set{    this.ptotal=value; if(ptotal.HasValue&&ptotal.Value>0){ OnPropertyChanged("Ptotal"); }}
        }
        public virtual Decimal UpdateAmount
        {
            get{    return this.updateAmount;}
            set{    this.updateAmount=value; if(updateAmount>0){ OnPropertyChanged("UpdateAmount"); }}
        }
        [Required(ErrorMessageResourceName ="order_express_company_name", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_express_company_name_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ExpressCompanyName
        {
            get{    return this.expressCompanyName;}
            set{    this.expressCompanyName=value; if(!string.IsNullOrEmpty(expressCompanyName)){ OnPropertyChanged("ExpressCompanyName"); }}
        }
        public virtual Int32 PayType
        {
            get{    return this.payType;}
            set{    this.payType=value; if(payType>0){ OnPropertyChanged("PayType"); }}
        }
        public virtual Decimal? Rebate
        {
            get{    return this.rebate;}
            set{    this.rebate=value; if(rebate.HasValue&&rebate.Value>0){ OnPropertyChanged("Rebate"); }}
        }
        public virtual Int32 Carry
        {
            get{    return this.carry;}
            set{    this.carry=value; if(carry>0){ OnPropertyChanged("Carry"); }}
        }
        [Required(ErrorMessageResourceName ="order_low_stocks", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_low_stocks_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string LowStocks
        {
            get{    return this.lowStocks;}
            set{    this.lowStocks=value; if(!string.IsNullOrEmpty(lowStocks)){ OnPropertyChanged("LowStocks"); }}
        }
        [Required(ErrorMessageResourceName ="order_refund_status", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_refund_status_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string RefundStatus
        {
            get{    return this.refundStatus;}
            set{    this.refundStatus=value; if(!string.IsNullOrEmpty(refundStatus)){ OnPropertyChanged("RefundStatus"); }}
        }
        public virtual Decimal? Fee
        {
            get{    return this.fee;}
            set{    this.fee=value; if(fee.HasValue&&fee.Value>0){ OnPropertyChanged("Fee"); }}
        }
        [Required(ErrorMessageResourceName ="order_other_requirement", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_other_requirement_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string OtherRequirement
        {
            get{    return this.otherRequirement;}
            set{    this.otherRequirement=value; if(!string.IsNullOrEmpty(otherRequirement)){ OnPropertyChanged("OtherRequirement"); }}
        }
        [Required(ErrorMessageResourceName ="order_paystatus", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_paystatus_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Paystatus
        {
            get{    return this.paystatus;}
            set{    this.paystatus=value; if(!string.IsNullOrEmpty(paystatus)){ OnPropertyChanged("Paystatus"); }}
        }
        [Required(ErrorMessageResourceName ="order_remark", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_remark_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Remark
        {
            get{    return this.remark;}
            set{    this.remark=value; if(!string.IsNullOrEmpty(remark)){ OnPropertyChanged("Remark"); }}
        }
        [Required(ErrorMessageResourceName ="order_closed_comment", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_closed_comment_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ClosedComment
        {
            get{    return this.closedComment;}
            set{    this.closedComment=value; if(!string.IsNullOrEmpty(closedComment)){ OnPropertyChanged("ClosedComment"); }}
        }
        [Required(ErrorMessageResourceName ="order_express_no", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_express_no_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ExpressNo
        {
            get{    return this.expressNo;}
            set{    this.expressNo=value; if(!string.IsNullOrEmpty(expressNo)){ OnPropertyChanged("ExpressNo"); }}
        }
        [Required(ErrorMessageResourceName ="order_express_name", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_express_name_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ExpressName
        {
            get{    return this.expressName;}
            set{    this.expressName=value; if(!string.IsNullOrEmpty(expressName)){ OnPropertyChanged("ExpressName"); }}
        }
        public virtual Int32 Quantity
        {
            get{    return this.quantity;}
            set{    this.quantity=value; if(quantity>0){ OnPropertyChanged("Quantity"); }}
        }
        [Required(ErrorMessageResourceName ="order_confirm_send_product_remark", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_confirm_send_product_remark_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ConfirmSendProductRemark
        {
            get{    return this.confirmSendProductRemark;}
            set{    this.confirmSendProductRemark=value; if(!string.IsNullOrEmpty(confirmSendProductRemark)){ OnPropertyChanged("ConfirmSendProductRemark"); }}
        }
        [Required(ErrorMessageResourceName ="order_express_code", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_express_code_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ExpressCode
        {
            get{    return this.expressCode;}
            set{    this.expressCode=value; if(!string.IsNullOrEmpty(expressCode)){ OnPropertyChanged("ExpressCode"); }}
        }
        [Required(ErrorMessageResourceName ="order_account", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_account_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Account
        {
            get{    return this.account;}
            set{    this.account=value; if(!string.IsNullOrEmpty(account)){ OnPropertyChanged("Account"); }}
        }
        public virtual Int64? BuyerId
        {
            get{    return this.buyerId;}
            set{    this.buyerId=value; if(buyerId.HasValue&&buyerId.Value>0){ OnPropertyChanged("BuyerId"); }}
        }
        public virtual Decimal? Amount
        {
            get{    return this.amount;}
            set{    this.amount=value; if(amount.HasValue&&amount.Value>0){ OnPropertyChanged("Amount"); }}
        }

    }
    [AutoMap(typeof(Order))]
    public  class UpdateOrderInput : CreateOrderInput,IEntityDto<long>
     {

    }
    [AutoMap(typeof(Order))]
    public  class QueryOrderInput   : CreateOrderInput
     {

    }
    [AutoMap(typeof(Order))]
    public  class QueryOrderOutput : CreateOrderInput,IEntityDto<long>
     {

    }


}