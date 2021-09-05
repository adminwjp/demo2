namespace Shop.Application.Services.Dtos
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using Shop.Domain.Entities;
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using System;

    using EventCloud;

    public class EmailNotifyProductDto{
        protected virtual void OnPropertyChanged(string propertyName = null) { }
        public virtual char Status { get; set; }
		public virtual DateTime Notifydate { get; set; }
		public virtual string ProductName { get; set; }
		public virtual string ReceiveEmail { get; set; }
		public virtual string ProductID { get; set; }
		public virtual int SendFailureCount { get; set; }
		public virtual string Account { get; set; }
		public virtual long? SellerId { get; set; }
        public virtual long? BuyerId { get; set; }
    }
}