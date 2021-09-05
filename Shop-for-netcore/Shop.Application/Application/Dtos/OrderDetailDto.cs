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

    [AutoMap(typeof(OrderDetail))]
    public  class CreateOrderDetailInput
     {
        private Int64 id;
        private Int64? productID;
        private Decimal? fee;
        private string isComment;
        private Int64? sellerID;
        private string productName;
        private string giftID;
        private Int32 orderID;
        private string specInfo;
        private Int32 score;
        private Int32 number;
        private string lowStocks;
        private Decimal? price;
        private Decimal? total;
        protected virtual void OnPropertyChanged( string propertyName = null){}
        public virtual Int64 Id
        {
            get { return this.id; }
            set { this.id = value; if (id > 0) { OnPropertyChanged("Id"); } }
        }
        public virtual Int64? ProductID
        {
            get{    return this.productID;}
            set{    this.productID=value; if(productID.HasValue&&productID.Value>0){ OnPropertyChanged("ProductID"); }}
        }
        public virtual Decimal? Fee
        {
            get{    return this.fee;}
            set{    this.fee=value; if(fee.HasValue&&fee.Value>0){ OnPropertyChanged("Fee"); }}
        }
        [Required(ErrorMessageResourceName ="order_detail_is_comment", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_detail_is_comment_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string IsComment
        {
            get{    return this.isComment;}
            set{    this.isComment=value; if(!string.IsNullOrEmpty(isComment)){ OnPropertyChanged("IsComment"); }}
        }
        public virtual Int64? SellerID
        {
            get{    return this.sellerID;}
            set{    this.sellerID=value; if(sellerID.HasValue&&sellerID.Value>0){ OnPropertyChanged("SellerID"); }}
        }
        [Required(ErrorMessageResourceName ="order_detail_product_name", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_detail_product_name_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ProductName
        {
            get{    return this.productName;}
            set{    this.productName=value; if(!string.IsNullOrEmpty(productName)){ OnPropertyChanged("ProductName"); }}
        }
        [Required(ErrorMessageResourceName ="order_detail_gift_i_d", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_detail_gift_i_d_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string GiftID
        {
            get{    return this.giftID;}
            set{    this.giftID=value; if(!string.IsNullOrEmpty(giftID)){ OnPropertyChanged("GiftID"); }}
        }
        public virtual Int32 OrderID
        {
            get{    return this.orderID;}
            set{    this.orderID=value; if(orderID>0){ OnPropertyChanged("OrderID"); }}
        }
        [Required(ErrorMessageResourceName ="order_detail_spec_info", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_detail_spec_info_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string SpecInfo
        {
            get{    return this.specInfo;}
            set{    this.specInfo=value; if(!string.IsNullOrEmpty(specInfo)){ OnPropertyChanged("SpecInfo"); }}
        }
        public virtual Int32 Score
        {
            get{    return this.score;}
            set{    this.score=value; if(score>0){ OnPropertyChanged("Score"); }}
        }
        public virtual Int32 Number
        {
            get{    return this.number;}
            set{    this.number=value; if(number>0){ OnPropertyChanged("Number"); }}
        }
        [Required(ErrorMessageResourceName ="order_detail_low_stocks", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_detail_low_stocks_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string LowStocks
        {
            get{    return this.lowStocks;}
            set{    this.lowStocks=value; if(!string.IsNullOrEmpty(lowStocks)){ OnPropertyChanged("LowStocks"); }}
        }
        public virtual Decimal? Price
        {
            get{    return this.price;}
            set{    this.price=value; if(price.HasValue&&price.Value>0){ OnPropertyChanged("Price"); }}
        }
        public virtual Decimal? Total
        {
            get{    return this.total;}
            set{    this.total=value; if(total.HasValue&&total.Value>0){ OnPropertyChanged("Total"); }}
        }

    }
    [AutoMap(typeof(OrderDetail))]
    public  class UpdateOrderDetailInput : CreateOrderDetailInput,IEntityDto<long>
     {

    }
    [AutoMap(typeof(OrderDetail))]
    public  class QueryOrderDetailInput   : CreateOrderDetailInput
     {

    }
    [AutoMap(typeof(OrderDetail))]
    public  class QueryOrderDetailOutput : CreateOrderDetailInput,IEntityDto<long>
     {

    }


}