using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IOrderRepository : Abp.Domain.Repositories.IRepository<Order, long>
    {
    }
}
