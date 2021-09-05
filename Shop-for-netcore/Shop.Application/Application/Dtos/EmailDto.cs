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

    public  class CreateEmailInput
     {
        private Int64 id;
        private Int64? sellerId;
        private string account;
        private string emails;
        private string scrept;
        private Boolean isDefault;
        protected virtual void OnPropertyChanged( string propertyName = null){}
        public virtual Int64 Id
        {
            get { return this.id; }
            set { this.id = value; if (id > 0) { OnPropertyChanged("Id"); } }
        }
        public virtual Int64? SellerId
        {
            get{    return this.sellerId;}
            set{    this.sellerId=value; if(sellerId.HasValue&&sellerId.Value>0){ OnPropertyChanged("SellerId"); }}
        }
        [Required(ErrorMessageResourceName ="email_account", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "email_account_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Account
        {
            get{    return this.account;}
            set{    this.account=value; if(!string.IsNullOrEmpty(account)){ OnPropertyChanged("Account"); }}
        }
        [Required(ErrorMessageResourceName ="email_emails", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "email_emails_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Emails
        {
            get{    return this.emails;}
            set{    this.emails=value; if(!string.IsNullOrEmpty(emails)){ OnPropertyChanged("Emails"); }}
        }
        [Required(ErrorMessageResourceName ="email_scrept", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "email_scrept_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Scrept
        {
            get{    return this.scrept;}
            set{    this.scrept=value; if(!string.IsNullOrEmpty(scrept)){ OnPropertyChanged("Scrept"); }}
        }
        public virtual Boolean IsDefault
        {
            get{    return this.isDefault;}
            set{    this.isDefault=value; if(isDefault){ OnPropertyChanged("IsDefault"); }}
        }

    }
 


}