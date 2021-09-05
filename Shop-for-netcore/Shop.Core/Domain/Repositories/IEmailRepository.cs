using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IEmailNotityProductRepository:Abp.Domain.Repositories.IRepository<EmailNotifyProduct, long> 
    {
    }
}
