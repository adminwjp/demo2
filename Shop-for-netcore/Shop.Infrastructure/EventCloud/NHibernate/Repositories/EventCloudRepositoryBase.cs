using Abp.Domain.Entities;
using Abp.NHibernate;
using Abp.NHibernate.Repositories;

namespace EventCloud.NHibernate.Repositories
{
    public abstract class EventCloudRepositoryBase<TEntity, TPrimaryKey> : NhRepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected EventCloudRepositoryBase(ISessionProvider sessionProvider) : base(sessionProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class EventCloudRepositoryBase<TEntity> : EventCloudRepositoryBase<TEntity, long>
        where TEntity : class, IEntity<long>
    {
        protected EventCloudRepositoryBase(ISessionProvider sessionProvider) : base(sessionProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
