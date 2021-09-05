using N = NHibernate;
namespace Shop.NHibernate.Repositories
{
    using Abp.Domain.Entities;
    using Abp.Linq.Expressions;
    using Abp.NHibernate;
    using Abp.NHibernate.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;


    using Shop.Domain.Repositories;
    using Abp.Domain.Entities.Auditing;
    using N.Criterion;
    using Abp.Domain.Uow;

    public  class BaseNHRepository<TEntity, TPrimaryKey> : NhRepositoryBase<TEntity, TPrimaryKey>
       ,IRepository<TEntity,TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        protected BaseNHRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {

        }

        protected virtual AbstractCriterion GetWhere(TEntity entity,bool delete=true)
        {
            AbstractCriterion criterion =delete?
             N.Criterion.Expression.Eq("IsDeleted", false):null;
            //if (entity.Id.HasValue&&entity.Id.Value>0)
            //{
            //    if(delete){
            //        criterion |= N.Criterion.Expression.Eq("Id", entity.Id);
            //    }else{
            //        criterion = N.Criterion.Expression.Eq("Id", entity.Id);
            //    }
            //}
            return criterion;
        }

        internal protected virtual N.ICriteria GetCriteria(TEntity entity,bool delete=true)
        {
            var where = GetWhere(entity,delete);
            return GetCriteria(where);
        }
        internal protected virtual N.ICriteria GetCriteria(AbstractCriterion where)
        {
            N.ICriteria criteria = Session.CreateCriteria<TEntity>();
            criteria.AddOrder(N.Criterion.Order.Desc("CreationTime"));
            if (where != null)
            {
                criteria = criteria.Add(where);
            }
            return criteria;
        }
        public virtual void Add(List<TEntity> objs){
           objs.ForEach(it=>{
               base.Insert(it);
           });
        }

        public virtual void Update(List<TEntity> objs){
           objs.ForEach(it=>{
               base.Update(it);
           });
        }

     
        public virtual void Delete(List<TPrimaryKey> ids){
          ids.ForEach(it=>{
              base.Delete(it);
           });
        }

         public virtual List<TEntity> GetList(List<TPrimaryKey> ids){
           AbstractCriterion criterion = N.Criterion.Expression.Eq("IsDeleted", false);
            ids.ForEach(it=>{
             criterion |= N.Criterion.Expression.Eq("Id", it);
           });
            N.ICriteria criteria = GetCriteria(criterion);
          return criteria.List<TEntity>().ToList();
        }

         public virtual Tuple<List<TEntity>,long> GetList(int page,int size){
            N.ICriteria criteria = GetCriteria((AbstractCriterion)null);
           var data= criteria.SetFirstResult((page - 1) * size).SetMaxResults(size).List<TEntity>().ToList();
            var count = criteria.SetProjection(Projections.RowCountInt64()).UniqueResult<long>();
            return new Tuple<List<TEntity>, long>(data, count);
        }

        protected virtual Tuple<List<TEntity>,long> GetList(IQueryable<TEntity> queryable,int page,int size){
           var data= queryable.Skip((page-1)*size).Take(size).ToList();
           var count=queryable.Count();
           return new Tuple<List<TEntity>, long>(data,count);
        }

        public virtual Tuple<List<TEntity>,long> GetList(TEntity query,int page,int size){
            N.ICriteria criteria = GetCriteria(query);
            var data = criteria.SetFirstResult((page - 1) * size).SetMaxResults(size).List<TEntity>().ToList();
            var count = criteria.SetProjection(Projections.RowCountInt64()).UniqueResult<long>();
            return new Tuple<List<TEntity>, long>(data, count);
        }

         public virtual bool IsExists(TPrimaryKey id){
             //nhibernate linq 不支持 拼接 5.x
           //return base.Count(base.CreateEqualityExpressionForId(id).And(it=>it.IsDeleted))>0;
           return false;
        }

        public bool IsExistsAny(List<TPrimaryKey> ids)
        {
            AbstractCriterion criterion = N.Criterion.Expression.Eq("IsDeleted", false);
            ids.ForEach(it => {
                criterion |= N.Criterion.Expression.Eq("Id", it);
            });
            N.ICriteria criteria = GetCriteria(criterion);
            return criteria.SetProjection(Projections.RowCountInt64()).UniqueResult<long>()>0;
        }

        public bool IsExistsAll(List<TPrimaryKey> ids)
        {
            AbstractCriterion criterion = N.Criterion.Expression.Eq("IsDeleted", false);
            ids.ForEach(it => {
                criterion &= N.Criterion.Expression.Eq("Id", it);
            });
            N.ICriteria criteria = GetCriteria(criterion);
            return criteria.SetProjection(Projections.RowCountInt64()).UniqueResult<long>() > 0;
        }
    }

      [UnitOfWork]
      public class BaseNHRepository<TEntity> : BaseNHRepository<TEntity, long>,IRepository<TEntity>
        where TEntity : class, IEntity<long>
    {
        public BaseNHRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {

        }

        public override void Delete(List<long> ids){
          ids.ForEach(it=>{
              if(it>0){
                base.Delete(it);
              }
           });
        }

        public override bool IsExists(long id){
            return base.Count(it => it.Id == id) > 0;
            //return base.Count(it=>it.Id==id&&it.IsDeleted)>0;
        }

    }
}