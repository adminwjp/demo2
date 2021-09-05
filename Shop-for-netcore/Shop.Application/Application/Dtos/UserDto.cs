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
    //======buyer
    [AutoMap(typeof(User))]
    public class CreateUserInput
    {
        private Int64 id;
        private string realname;
        private string headimgurl;
        private string openId;
        private string imQq;
        private string authAppId;
        private string language;
        private string city;
        private string province;
        private string country;
        private Int32 subscribe;
        private Int64 subscribeTime;
        private Int64 groupid;
        private string remark;
        private Int64 accessIp;
        private string refreshToken;
        private Int64 tokenExpiresIn;
        private Int64 lastLoginDate;
        private string unionid;
        private Int32 score;
        private Int32 isReceiver;
        private string account;
        private string phone;
        private string email;
        private string pwd;
        private string name;
        private Int32 age;
        private string sex;
        private string address;
        private Int64 bir;
        private string postcode;
        private Single balance;
        private Int64 loginIp;
        private Int64 registerIp;
        private Boolean isLoginPc;
        private Int32 pcFlag;
        private Boolean isLoginApp;
        private Int32 appFlag;
        private Boolean isLoginWxProgram;
        private Boolean isLoginBrower;
        private Int64 regDate;
        private Int64 loginDate;
        private DateTime? deletionTime;
        private Boolean isDeleted;
        protected virtual void OnPropertyChanged( string propertyName = null){}
        public virtual Int64 Id
        {
            get { return this.id; }
            set { this.id = value; if (id > 0) { OnPropertyChanged("Id"); } }
        }
        [Required(ErrorMessageResourceName ="buyer_realname", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_realname_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Realname
        {
            get{    return this.realname;}
            set{    this.realname=value; if(!string.IsNullOrEmpty(realname)){ OnPropertyChanged("Realname"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_headimgurl", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_headimgurl_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Headimgurl
        {
            get{    return this.headimgurl;}
            set{    this.headimgurl=value; if(!string.IsNullOrEmpty(headimgurl)){ OnPropertyChanged("Headimgurl"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_open_id", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_open_id_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string OpenId
        {
            get{    return this.openId;}
            set{    this.openId=value; if(!string.IsNullOrEmpty(openId)){ OnPropertyChanged("OpenId"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_im_qq", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_im_qq_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string ImQq
        {
            get{    return this.imQq;}
            set{    this.imQq=value; if(!string.IsNullOrEmpty(imQq)){ OnPropertyChanged("ImQq"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_auth_app_id", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_auth_app_id_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string AuthAppId
        {
            get{    return this.authAppId;}
            set{    this.authAppId=value; if(!string.IsNullOrEmpty(authAppId)){ OnPropertyChanged("AuthAppId"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_language", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_language_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Language
        {
            get{    return this.language;}
            set{    this.language=value; if(!string.IsNullOrEmpty(language)){ OnPropertyChanged("Language"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_city", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_city_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string City
        {
            get{    return this.city;}
            set{    this.city=value; if(!string.IsNullOrEmpty(city)){ OnPropertyChanged("City"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_province", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_province_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Province
        {
            get{    return this.province;}
            set{    this.province=value; if(!string.IsNullOrEmpty(province)){ OnPropertyChanged("Province"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_country", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_country_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Country
        {
            get{    return this.country;}
            set{    this.country=value; if(!string.IsNullOrEmpty(country)){ OnPropertyChanged("Country"); }}
        }
        public virtual Int32 Subscribe
        {
            get{    return this.subscribe;}
            set{    this.subscribe=value; if(subscribe>0){ OnPropertyChanged("Subscribe"); }}
        }
        public virtual Int64 SubscribeTime
        {
            get{    return this.subscribeTime;}
            set{    this.subscribeTime=value; if(subscribeTime>0){ OnPropertyChanged("SubscribeTime"); }}
        }
        public virtual Int64 Groupid
        {
            get{    return this.groupid;}
            set{    this.groupid=value; if(groupid>0){ OnPropertyChanged("Groupid"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_remark", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_remark_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Remark
        {
            get{    return this.remark;}
            set{    this.remark=value; if(!string.IsNullOrEmpty(remark)){ OnPropertyChanged("Remark"); }}
        }
        public virtual Int64 AccessIp
        {
            get{    return this.accessIp;}
            set{    this.accessIp=value; if(accessIp>0){ OnPropertyChanged("AccessIp"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_refresh_token", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_refresh_token_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string RefreshToken
        {
            get{    return this.refreshToken;}
            set{    this.refreshToken=value; if(!string.IsNullOrEmpty(refreshToken)){ OnPropertyChanged("RefreshToken"); }}
        }
        public virtual Int64 TokenExpiresIn
        {
            get{    return this.tokenExpiresIn;}
            set{    this.tokenExpiresIn=value; if(tokenExpiresIn>0){ OnPropertyChanged("TokenExpiresIn"); }}
        }
        public virtual Int64 LastLoginDate
        {
            get{    return this.lastLoginDate;}
            set{    this.lastLoginDate=value; if(lastLoginDate>0){ OnPropertyChanged("LastLoginDate"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_unionid", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_unionid_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Unionid
        {
            get{    return this.unionid;}
            set{    this.unionid=value; if(!string.IsNullOrEmpty(unionid)){ OnPropertyChanged("Unionid"); }}
        }
        public virtual Int32 Score
        {
            get{    return this.score;}
            set{    this.score=value; if(score>0){ OnPropertyChanged("Score"); }}
        }
        public virtual Int32 IsReceiver
        {
            get{    return this.isReceiver;}
            set{    this.isReceiver=value; if(isReceiver>0){ OnPropertyChanged("IsReceiver"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_account", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_account_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Account
        {
            get{    return this.account;}
            set{    this.account=value; if(!string.IsNullOrEmpty(account)){ OnPropertyChanged("Account"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_phone", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_phone_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Phone
        {
            get{    return this.phone;}
            set{    this.phone=value; if(!string.IsNullOrEmpty(phone)){ OnPropertyChanged("Phone"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_email", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_email_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Email
        {
            get{    return this.email;}
            set{    this.email=value; if(!string.IsNullOrEmpty(email)){ OnPropertyChanged("Email"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_pwd", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_pwd_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Pwd
        {
            get{    return this.pwd;}
            set{    this.pwd=value; if(!string.IsNullOrEmpty(pwd)){ OnPropertyChanged("Pwd"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_name", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_name_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Name
        {
            get{    return this.name;}
            set{    this.name=value; if(!string.IsNullOrEmpty(name)){ OnPropertyChanged("Name"); }}
        }
        public virtual Int32 Age
        {
            get{    return this.age;}
            set{    this.age=value; if(age>0){ OnPropertyChanged("Age"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_sex", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_sex_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Sex
        {
            get{    return this.sex;}
            set{    this.sex=value; if(!string.IsNullOrEmpty(sex)){ OnPropertyChanged("Sex"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_address", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_address_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Address
        {
            get{    return this.address;}
            set{    this.address=value; if(!string.IsNullOrEmpty(address)){ OnPropertyChanged("Address"); }}
        }
        public virtual Int64 Bir
        {
            get{    return this.bir;}
            set{    this.bir=value; if(bir>0){ OnPropertyChanged("Bir"); }}
        }
        [Required(ErrorMessageResourceName ="buyer_postcode", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "buyer_postcode_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Postcode
        {
            get{    return this.postcode;}
            set{    this.postcode=value; if(!string.IsNullOrEmpty(postcode)){ OnPropertyChanged("Postcode"); }}
        }
        public virtual Single Balance
        {
            get{    return this.balance;}
            set{    this.balance=value; if(balance>0){ OnPropertyChanged("Balance"); }}
        }
        public virtual Int64 LoginIp
        {
            get{    return this.loginIp;}
            set{    this.loginIp=value; if(loginIp>0){ OnPropertyChanged("LoginIp"); }}
        }
        public virtual Int64 RegisterIp
        {
            get{    return this.registerIp;}
            set{    this.registerIp=value; if(registerIp>0){ OnPropertyChanged("RegisterIp"); }}
        }
        public virtual Boolean IsLoginPc
        {
            get{    return this.isLoginPc;}
            set{    this.isLoginPc=value; if(isLoginPc){ OnPropertyChanged("IsLoginPc"); }}
        }
        public virtual Int32 PcFlag
        {
            get{    return this.pcFlag;}
            set{    this.pcFlag=value; if(pcFlag>0){ OnPropertyChanged("PcFlag"); }}
        }
        public virtual Boolean IsLoginApp
        {
            get{    return this.isLoginApp;}
            set{    this.isLoginApp=value; if(isLoginApp){ OnPropertyChanged("IsLoginApp"); }}
        }
        public virtual Int32 AppFlag
        {
            get{    return this.appFlag;}
            set{    this.appFlag=value; if(appFlag>0){ OnPropertyChanged("AppFlag"); }}
        }
        public virtual Boolean IsLoginWxProgram
        {
            get{    return this.isLoginWxProgram;}
            set{    this.isLoginWxProgram=value; if(isLoginWxProgram){ OnPropertyChanged("IsLoginWxProgram"); }}
        }
        public virtual Boolean IsLoginBrower
        {
            get{    return this.isLoginBrower;}
            set{    this.isLoginBrower=value; if(isLoginBrower){ OnPropertyChanged("IsLoginBrower"); }}
        }
        public virtual Int64 RegDate
        {
            get{    return this.regDate;}
            set{    this.regDate=value; if(regDate>0){ OnPropertyChanged("RegDate"); }}
        }
        public virtual Int64 LoginDate
        {
            get{    return this.loginDate;}
            set{    this.loginDate=value; if(loginDate>0){ OnPropertyChanged("LoginDate"); }}
        }
        public virtual DateTime? DeletionTime
        {
            get{    return this.deletionTime;}
            set{    this.deletionTime=value; if(deletionTime.HasValue&&deletionTime!=default(DateTime)){ OnPropertyChanged("DeletionTime"); }}
        }
        public virtual Boolean IsDeleted
        {
            get{    return this.isDeleted;}
            set{    this.isDeleted=value; if(isDeleted){ OnPropertyChanged("IsDeleted"); }}
        }

    }

    [AutoMap(typeof(User))]
    public  class UpdateUserInput : CreateUserInput, IEntityDto<long>
     {

    }
    [AutoMap(typeof(User))]
    public  class QueryUserInput : CreateUserInput
    {

    }
    [AutoMap(typeof(User))]
    public  class QueryUserOutput : CreateUserInput, IEntityDto<long>
     {

    }

}