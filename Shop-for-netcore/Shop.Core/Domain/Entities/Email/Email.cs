namespace Shop.Domain.Entities
{
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;


	public class EmailNotifyProduct:IEntity<long>
    {
        public virtual long Id { get; set; }
        public virtual char Status { get; set; }
		public virtual DateTime Notifydate { get; set; }
		public virtual string ProductName { get; set; }
		public virtual string ReceiveEmail { get; set; }
		public virtual string ProductID { get; set; }
		public virtual int SendFailureCount { get; set; }
		public virtual string Account { get; set; }
		public virtual long? SellerId { get; set; }
        public virtual long? BuyerId { get; set; }

         public virtual bool IsTransient(){
            return true;
        }

	}

}