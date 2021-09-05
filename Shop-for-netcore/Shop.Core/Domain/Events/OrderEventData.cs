namespace Shop.Domain.Events
{
    using Abp.Events.Bus.Entities;
    using Shop.Domain.Entities;
    using Abp.Domain.Entities;

        public enum OrderStatus{
            Confirm,
            Cancel,
            TimeOut
        }
      public class OrderEvent:IEntity<long?>{
        public virtual long? Id{get;set;}
        public virtual OrderStatus Status{get;set;}
        public virtual bool IsTransient(){
            return true;
        }
    }
    public class OrderCancel:IEntity<long?>{
        public virtual long? Id{get;set;}
        public virtual bool IsTransient(){
            return true;
        }
    }
    public class OrderCancelEventData:EntityChangedEventData<OrderCancel>
    {
        public OrderCancelEventData(OrderCancel order):base(order){

        }
    }

     public class OrderConfrim:IEntity<long?>{
        public virtual long? Id{get;set;}
        public virtual bool IsTransient(){
            return true;
        }
    }
    public class OrderConfrimEventData:EntityChangedEventData<OrderConfrim>
    {
        public OrderConfrimEventData(OrderConfrim order):base(order){
        }
    }
}