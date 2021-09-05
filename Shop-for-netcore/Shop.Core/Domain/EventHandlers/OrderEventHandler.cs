namespace Shop.Domain.EventHandlers
{  
    using Abp.Events.Bus.Entities;
    using Shop.Domain.Entities;
    using Abp.Domain.Entities;
    using Shop.Domain.Events;
     using Abp.Events.Bus.Handlers;
    using System.Threading.Tasks;

    public class OrderEventHandler : IAsyncEventHandler<EntityEventData<OrderEvent>>
    {
        public OrderEventHandler(){
        }
        public Task HandleEventAsync(EntityEventData<OrderEvent> eventData)
        {
           throw new System.Exception();
        }
    }
}