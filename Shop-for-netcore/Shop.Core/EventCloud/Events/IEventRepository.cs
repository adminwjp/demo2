using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventCloud.Events
{
    public interface IEventRepository:IRepository<Event,Guid>
    {
        Task<List<Event>> GetListAsync(bool includeCanceledEvents);
    }
}
