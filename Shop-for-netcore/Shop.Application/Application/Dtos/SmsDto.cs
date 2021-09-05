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
    public  class CreateSmsInput
     {
        private Int64 id;
        private string appId;
        private string secrt;
        protected virtual void OnPropertyChanged( string propertyName = null){}
        public virtual Int64 Id
        {
            get { return this.id; }
            set { this.id = value; if (id > 0) { OnPropertyChanged("Id"); } }
        }
        [Required(ErrorMessageResourceName ="sms_app_id", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "sms_app_id_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string AppId
        {
            get{    return this.appId;}
            set{    this.appId=value; if(!string.IsNullOrEmpty(appId)){ OnPropertyChanged("AppId"); }}
        }
        [Required(ErrorMessageResourceName ="sms_secrt", ErrorMessageResourceType = typeof(Resource))]
        [Range(2, 10, ErrorMessageResourceName = "sms_secrt_range", ErrorMessageResourceType = typeof(Resource))]
        public virtual string Secrt
        {
            get{    return this.secrt;}
            set{    this.secrt=value; if(!string.IsNullOrEmpty(secrt)){ OnPropertyChanged("Secrt"); }}
        }

    }
  

}