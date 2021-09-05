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
    [AutoMap(typeof(OrderShip))]
    public  class CreateOrderShipInput
     {
        private Int64 id;
        private string tel;
        private string cityCode;
        private string city;
        private string province;
        private string sex;
        private string areaCode;
        private string zip;
        private string shipname;
        private string orderId;
        private string provinceCode;
        private string remark;
        private string phone;
        private string shipaddress;
        private string area;
        protected virtual void OnPropertyChanged( string propertyName = null){}
        public virtual Int64 Id
        {
            get { return this.id; }
            set { this.id = value; if (id > 0) { OnPropertyChanged("Id"); } }
        }
        [Required(ErrorMessageResourceName ="order_ship_tel", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_tel_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Tel
        {
            get{    return this.tel;}
            set{    this.tel=value; if(!string.IsNullOrEmpty(tel)){ OnPropertyChanged("Tel"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_city_code", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_city_code_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string CityCode
        {
            get{    return this.cityCode;}
            set{    this.cityCode=value; if(!string.IsNullOrEmpty(cityCode)){ OnPropertyChanged("CityCode"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_city", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_city_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string City
        {
            get{    return this.city;}
            set{    this.city=value; if(!string.IsNullOrEmpty(city)){ OnPropertyChanged("City"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_province", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_province_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Province
        {
            get{    return this.province;}
            set{    this.province=value; if(!string.IsNullOrEmpty(province)){ OnPropertyChanged("Province"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_sex", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_sex_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Sex
        {
            get{    return this.sex;}
            set{    this.sex=value; if(!string.IsNullOrEmpty(sex)){ OnPropertyChanged("Sex"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_area_code", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_area_code_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string AreaCode
        {
            get{    return this.areaCode;}
            set{    this.areaCode=value; if(!string.IsNullOrEmpty(areaCode)){ OnPropertyChanged("AreaCode"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_zip", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_zip_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Zip
        {
            get{    return this.zip;}
            set{    this.zip=value; if(!string.IsNullOrEmpty(zip)){ OnPropertyChanged("Zip"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_shipname", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_shipname_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Shipname
        {
            get{    return this.shipname;}
            set{    this.shipname=value; if(!string.IsNullOrEmpty(shipname)){ OnPropertyChanged("Shipname"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_order_id", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_order_id_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string OrderId
        {
            get{    return this.orderId;}
            set{    this.orderId=value; if(!string.IsNullOrEmpty(orderId)){ OnPropertyChanged("OrderId"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_province_code", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_province_code_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ProvinceCode
        {
            get{    return this.provinceCode;}
            set{    this.provinceCode=value; if(!string.IsNullOrEmpty(provinceCode)){ OnPropertyChanged("ProvinceCode"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_remark", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_remark_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Remark
        {
            get{    return this.remark;}
            set{    this.remark=value; if(!string.IsNullOrEmpty(remark)){ OnPropertyChanged("Remark"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_phone", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_phone_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Phone
        {
            get{    return this.phone;}
            set{    this.phone=value; if(!string.IsNullOrEmpty(phone)){ OnPropertyChanged("Phone"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_shipaddress", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_shipaddress_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Shipaddress
        {
            get{    return this.shipaddress;}
            set{    this.shipaddress=value; if(!string.IsNullOrEmpty(shipaddress)){ OnPropertyChanged("Shipaddress"); }}
        }
        [Required(ErrorMessageResourceName ="order_ship_area", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "order_ship_area_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Area
        {
            get{    return this.area;}
            set{    this.area=value; if(!string.IsNullOrEmpty(area)){ OnPropertyChanged("Area"); }}
        }

    }
    [AutoMap(typeof(OrderShip))]
    public  class UpdateOrderShipInput : CreateOrderShipInput,IEntityDto<long>
     {

    }
    [AutoMap(typeof(OrderShip))]
    public  class QueryOrderShipInput   : CreateOrderShipInput
     {

    }
    [AutoMap(typeof(OrderShip))]
    public  class QueryOrderShipOutput : CreateOrderShipInput,IEntityDto<long>
     {

    }


}