namespace Shop.Api.Controllers
{
    using Shop.Domain.Entities;
    using Shop.Application.Services.Dtos;
    using Shop.Domain.Repositories;
    using Shop.Application.Services;
    using Abp.Application.Services;
    using System;
    using Abp.ObjectMapping;
    using Abp.Domain.Uow;
    using Microsoft.AspNetCore.Mvc;

    public class OrderController:BaseController<OrderAppService,IRepository<Order>,CreateOrderInput,
    UpdateOrderInput,QueryOrderInput,QueryOrderOutput,Order>
    {
        public OrderController(OrderAppService service):base(service){

        }
      
    }
}