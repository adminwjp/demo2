namespace Shop.Domain.Entities
{
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using NHibernate.Mapping.Attributes;

    public class Msg
    {
         public virtual bool IsTransient(){
            return true;
        }
    }

    //新品通知
    [Class(Table ="t_product_msg",Lazy =false)]
    public class ProductMsg : IEntity<long>
    {
        [Id(Column ="t_product_msg")]
        public virtual long Id { get; set; }
        [Property(Column = "product_ids",Length =50)]
        public virtual string ProductIds { get; set; }
        [Property(Column = "title", Length = 50)]
        public virtual string Title { get; set; }
        [Property(Column = "msg", Length = 50)]
        public virtual string Msg { get; set; }
        [Property(Column = "start_date", Length = 50)]
        public virtual long StartDate { get; set; }
        [Property(Column = "end_date", Length = 50)]
        public virtual long EndDate { get; set; }
        [Property(Column = "end", Length = 50)]
        public virtual bool End { get; set; }
        [Property(Column = "pic", Length = 50)]
        public virtual string Pic { get; set; }
        [Property(Column = "times", Length = 50)]
        public virtual long Times { get; set; }
        public virtual bool IsTransient(){
            return true;
        }
    }
}