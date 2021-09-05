using Abp.Linq.Extensions;
using Abp.NHibernate;
using EventCloud.NHibernate.Repositories;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCloud.Events
{
    public class EventNHRepository: EventCloudRepositoryBase<Event,Guid>,IEventRepository
    {
        public EventNHRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {

        }
      

        public Task<List<Event>> GetListAsync(bool includeCanceledEvents)
        {
            return base.GetAll().WhereIf(!includeCanceledEvents, e => !e.IsCancelled)
                .OrderByDescending(e => e.CreationTime)
                .Take(64).ToListAsync();
        }
    }
}
