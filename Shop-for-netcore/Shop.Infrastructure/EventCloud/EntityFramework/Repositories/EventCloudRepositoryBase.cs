using Abp.Domain.Entities;
#if NET5_0
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
#else
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
#endif
namespace EventCloud.EntityFramework.Repositories
{
    public abstract class EventCloudRepositoryBase<TEntity, TPrimaryKey> :
#if NET5_0
        EfCoreRepositoryBase<EventCloudDbContext, TEntity, TPrimaryKey>
#else
        EfRepositoryBase<EventCloudDbContext, TEntity, TPrimaryKey>
#endif
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected EventCloudRepositoryBase(IDbContextProvider<EventCloudDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class EventCloudRepositoryBase<TEntity> : EventCloudRepositoryBase<TEntity, long>
        where TEntity : class, IEntity<long>
    {
        protected EventCloudRepositoryBase(IDbContextProvider<EventCloudDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
