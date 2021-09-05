using Abp.Domain.Entities;
using Abp.Application.Services;
using System;
using Abp.ObjectMapping;
using Abp.Domain.Uow;
using Shop.Domain.Entities;
using Shop.Application.Services.Dtos;
using Shop.Domain.Repositories;
using System.Collections.Generic; 

namespace Shop.Application.Services
{
    [UnitOfWork]
     public class OrderAppService:AppService<IRepository<Order>,CreateOrderInput,
    UpdateOrderInput,QueryOrderInput,QueryOrderOutput,Order>
    {
        public OrderAppService(IRepository<Order> repository, IObjectMapper objectMapper) : base(repository,objectMapper)
        {
           
        }

    }
}
