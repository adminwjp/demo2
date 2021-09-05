using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Api.Repositories
{
    public interface IBaseRepository<Entity>:IRepository<Entity, long?> 
         where Entity : class, IEntity<long?>
    {
         void Delete(long?[] ids);
         IList<Entity> Find(Entity entity);
         IList<Entity> FindByPage(Entity entity, int page, int size);
         int Count(Entity entity);
    }
}
