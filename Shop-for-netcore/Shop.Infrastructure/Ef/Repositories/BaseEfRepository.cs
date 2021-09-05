using Abp.Domain.Entities;
using Abp.Domain.Uow;
#if NET48
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
#else
    using Abp.EntityFrameworkCore;
    using Abp.EntityFrameworkCore.Repositories;
#endif
using Abp.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shop.Domain.Repositories;
using Abp.Domain.Entities.Auditing;

namespace Shop.Ef.Repositories
{
    public abstract class BaseEfRepository<TEntity, TPrimaryKey> :
#if NET48
    EfRepositoryBase<ShopDbContext, TEntity, TPrimaryKey>
#else
     EfCoreRepositoryBase<ShopDbContext, TEntity, TPrimaryKey>
#endif

       , IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        protected BaseEfRepository(IDbContextProvider<ShopDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        protected virtual Expression<Func<TEntity, bool>> GetWhere(TEntity entity, bool delete = true)
        {
            return null;
        }
        public virtual void Add(List<TEntity> objs)
        {
            objs.ForEach(it => {
                base.Insert(it);
            });
        }

        public virtual void Update(List<TEntity> objs)
        {
            objs.ForEach(it => {
                base.Update(it);
            });
        }


        public virtual void Delete(List<TPrimaryKey> ids)
        {
            ids.ForEach(it => {
                base.Delete(it);
            });
        }

        public virtual List<TEntity> GetList(List<TPrimaryKey> ids)
        {
            Expression<Func<TEntity, bool>> where = null;
            ids.ForEach(it => {
                if (where == null)
                {
                    where = base.CreateEqualityExpressionForId(it);
                }
                else
                {
                    where = where.Or(base.CreateEqualityExpressionForId(it));
                }
            });
            return base.GetAll().Where(where).ToList();
        }

        public virtual Tuple<List<TEntity>, long> GetList(int page, int size)
        {
            var data = GetList(base.GetAll()
            //.OrderBy(it => it.CreationTime)
            , page, size);
            return data;
        }

        protected virtual Tuple<List<TEntity>, long> GetList(IQueryable<TEntity> queryable, int page, int size)
        {
            var data = queryable.Skip((page - 1) * size).Take(size).ToList();
            var count = queryable.Count();
            return new Tuple<List<TEntity>, long>(data, count);
        }

        public virtual Tuple<List<TEntity>, long> GetList(TEntity query, int page, int size)
        {
            var where = GetWhere(query);
            var queryable = base.GetAll();
            if (where != null)
            {
                queryable = queryable.Where(where);
            }
            return GetList(queryable, page, size);
        }

        public virtual bool IsExists(TPrimaryKey id)
        {
            return base.Count(base.CreateEqualityExpressionForId(id)) > 0;
        }

        public virtual bool IsExistsAll(List<TPrimaryKey> ids)
        {
            Expression<Func<TEntity, bool>> where = null;
            ids.ForEach(it => {
                if (where == null)
                {
                    where = base.CreateEqualityExpressionForId(it);
                }
                else
                {
                    where = where.And(base.CreateEqualityExpressionForId(it));
                }
            });
            return base.Count(where) > 0;
        }
        public virtual bool IsExistsAny(List<TPrimaryKey> ids)
        {
            Expression<Func<TEntity, bool>> where = null;
            ids.ForEach(it => {
                if (where == null)
                {
                    where = base.CreateEqualityExpressionForId(it);
                }
                else
                {
                    where = where.Or(base.CreateEqualityExpressionForId(it));
                }
            });
            return base.Count(where) > 0;
        }
    }

    public abstract class BaseEfRepositoryByHasDeletionTime<TEntity, TPrimaryKey> : BaseEfRepository<TEntity, TPrimaryKey>
       ,IRepository<TEntity,TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>,IHasDeletionTime
    {
        protected BaseEfRepositoryByHasDeletionTime(IDbContextProvider<ShopDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        protected override Expression<Func<TEntity,bool>> GetWhere(TEntity entity,bool delete=true)
        {
            //C# 7.0 not support c# 9.0 support
            Expression<Func<TEntity,bool>> where =delete?
             (it => !it.IsDeleted) :(Expression<Func<TEntity, bool>>)null;
            // if (entity.Id.HasValue&&entity.Id.Value>0)
            // {
            //     if(delete){
            //         where |= base.CreateEqualityExpressionForId(id);
            //     }else{
            //         where = base.CreateEqualityExpressionForId(id)
            //     }
            // }
            return where;
        }

         public override bool IsExists(TPrimaryKey id){
           return base.Count(base.CreateEqualityExpressionForId(id).And(it=>it.IsDeleted))>0;
        }
    }
    
    public class BaseEfRepository<TEntity> : BaseEfRepository<TEntity, long>, IRepository<TEntity>
     where TEntity : class, IEntity<long>
    {
        public BaseEfRepository(IDbContextProvider<ShopDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public override void Delete(List<long> ids)
        {
            ids.ForEach(it => {
                if ( it > 0)
                {
                    base.Delete(it);
                }
            });
        }

        public override List<TEntity> GetList(List<long> ids)
        {
            Expression<Func<TEntity, bool>> where = null;
            ids.ForEach(it => {
                if ( it > 0)
                {
                    if (where == null)
                    {
                        where = obj => obj.Id == it;
                    }
                    else
                    {
                        where = where.Or(obj => obj.Id == it);
                    }
                }
            });
            return base.GetAllList(where).ToList();
        }
        public override bool IsExists(long id)
        {
            return base.Count(it => it.Id == id) > 0;
        }

    }

    public class BaseEfRepositoryByHasDeletionTime<TEntity> : BaseEfRepository<TEntity, long>,IRepository<TEntity>
        where TEntity : class, IEntity<long>,IHasDeletionTime
    {
        public BaseEfRepositoryByHasDeletionTime(IDbContextProvider<ShopDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
        public override void Delete(long id)
        {
            base.Delete(id);
        }
        public override void Delete(List<long> ids){
          ids.ForEach(it=>{
              if(it>0){
                Delete(it);
              }
           });
        }

         public override List<TEntity> GetList(List<long> ids){
             Expression<Func<TEntity,bool>> where=null;
               ids.ForEach(it=>{
              if(it>0){
               if (where==null){
                   where=obj=>obj.Id==it;
               }else{
                   where=where.Or(obj=>obj.Id==it);
               }
              }
           });
           return base.GetAllList(where).ToList();
        }

        public override bool IsExistsAll(List<long> ids)
        {
            Expression<Func<TEntity, bool>> where = it=>!it.IsDeleted;
            ids.ForEach(it => {
                if ( it > 0)
                {
                    if (where == null)
                    {
                        where = obj => obj.Id == it;
                    }
                    else
                    {
                        where = where.And(obj => obj.Id == it);
                    }
                }
            });
            return base.Count(where) > 0;
        }
        public override bool IsExistsAny(List<long> ids)
        {
            Expression<Func<TEntity, bool>> where = null;
            ids.ForEach(it => {
                if (it > 0)
                {
                    if (where == null)
                    {
                        where = obj => obj.Id == it;
                    }
                    else
                    {
                        where = where.Or(obj => obj.Id == it);
                    }
                }
            });
            where = where.And(it => !it.IsDeleted);
            return base.Count(where) > 0;
        }
        public override bool IsExists(long id)
        {
            return base.Count(it => it.Id == id && !it.IsDeleted) > 0;
        }

    }
}
