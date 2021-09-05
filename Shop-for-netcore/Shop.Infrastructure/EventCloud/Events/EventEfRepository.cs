#if NET5_0
using Abp.EntityFrameworkCore;
#else
using Abp.EntityFramework;
#endif
using Abp.Linq.Extensions;
using EventCloud.EntityFramework;
using EventCloud.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EventCloud.Events
{
    public class EventEfRepository: EventCloudRepositoryBase<Event, Guid>, IEventRepository
    {
        public EventEfRepository(IDbContextProvider<EventCloudDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public override Task<Event> FirstOrDefaultAsync(Guid id)
        {
            return base.GetAll().Where(it=>it.Id==id).Include(it=>it.Registrations).FirstOrDefaultAsync();
        }

        public  Task<List<Event>> GetListAsync(bool includeCanceledEvents)
        {
            return base.GetAll().Include(it => it.Registrations).WhereIf(!includeCanceledEvents, e => !e.IsCancelled)
                .OrderByDescending(e => e.CreationTime)
                .Take(64).ToListAsync();
        }

    }
}
