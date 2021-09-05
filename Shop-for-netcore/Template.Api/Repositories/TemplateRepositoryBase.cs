using Abp.Domain.Entities;
using Abp.Linq.Expressions;
using Abp.NHibernate;
using Abp.NHibernate.Repositories;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Template.Api.Repositories
{
    public abstract class TemplateRepositoryBase<TEntity, TPrimaryKey> : NhRepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public TemplateRepositoryBase(ISessionProvider sessionProvider) : base(sessionProvider)
        {

        }

        //add common methods for all repositories

      
    }

    public abstract class TemplateRepositoryBase<TEntity> : TemplateRepositoryBase<TEntity, long?>
        ,IBaseRepository <TEntity>
		where TEntity : class, IEntity<long?>,new()
    {
        public TemplateRepositoryBase(ISessionProvider sessionProvider) : base(sessionProvider)
        {

        }
      

        protected virtual AbstractCriterion GetWhere(TEntity entity)
        {
			return null;
            //this_.IsDeleted = ?p0 AND this_.is_deleted = ? 为什么 出现这种情况
            //6.2.0 不能升级  6.1.1
            AbstractCriterion criterion = Expression.Eq("IsDeleted", false);
            if (entity.Id.HasValue&&entity.Id.Value>0)
            {
                criterion |= Expression.Eq("Id", entity.Id);
            }
            return criterion;
        }

        public virtual IList<TEntity> Find(TEntity entity)
        {
            //abp 内部异常 asp.net error asp.net core pass
            // using (var tx=Session.BeginTransaction())
            {
                ICriteria criteria = GetCriteria(entity);
                return criteria.List<TEntity>();
            }
        }

        internal ICriteria GetCriteria(TEntity entity)
        {
            var where = GetWhere(entity);
            ICriteria criteria = Session.CreateCriteria<TEntity>();
            //criteria.AddOrder(Order.Desc("CreationTime"));
            if (where != null)
            {
                criteria = criteria.Add(where);
            }
            return criteria;
        }

        public virtual IList<TEntity> FindByPage(TEntity entity,int page,int size)
        {
            //abp 内部异常 asp.net error asp.net core pass
            // using (var tx=Session.BeginTransaction())
            {
                ICriteria criteria = GetCriteria(entity);
                return criteria.SetFirstResult((page - 1) * size).SetMaxResults(size).List<TEntity>();
            }
        }
        public virtual int Count(TEntity entity)
        {
            //abp 内部异常 asp.net error asp.net core pass
           // using (var tx=Session.BeginTransaction())
            {
                ICriteria criteria = GetCriteria(entity);
                return criteria.SetProjection(Projections.RowCount()).UniqueResult<int>();
            }
        }
        //public override void Delete(long? id)
        //{
        //    base.GetAll().Where(it=>it.Id==id&&!it.IsDeleted).Update(it=>new TEntity() {IsDeleted=true,LastModificationTime=DateTime.Now });
       // }
       // public override TEntity Update(TEntity entity)
        //{
            //已删除 的不能 修改
            //var old = base.GetAll().Where(it => it.Id == entity.Id&&!it.IsDeleted).Select(it=>new { it.CreationTime }).FirstOrDefault();
            //if (old == null)
           // {
           //     throw new Exception("not exists!");
           // }
            //entity.CreationTime = old.CreationTime;
            //entity.LastModificationTime = DateTime.Now;
           // return base.Update(entity);
       // }

        //do not add any method here, add to the class above (since this inherits it)

        public virtual void Delete(long?[] ids)
        {   
			foreach (var id in ids)
                if(id.HasValue&&id.Value>0)
                    Delete(id);
			return;	
            //abp 异常  支持 组合 linq 只支持 一次 到位 
            //Expression<Func<TEntity, bool>> where=null;
            //for (int i = 0; i < ids.Length; i++)
            //{
            //    if (where == null)
            //    {
            //        where = it => it.Id == ids[i];
            //    }
            //    else
            //    {
            //        where = where.Or(it => it.Id == ids[i]);
            //    }
            //}
            //base.Delete(where);//之前版本 nhibernate 是不支持 的 abp 做了处理？
            //return;
            //string sql = $"delete from {GetTable()} where ";

            string sql = $"update  {GetTable()} set deletion_time='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',is_deleted=1 where id in(";

            for (int i = 0; i < ids.Length; i++)
            {
                sql += "?";
                if (i != ids.Length - 1)
                    sql += ",";
            }
            sql += ");";
            //Cannot access a disposed object
            //提交成功 appservice 异常 拦截器 框架 已组织 好 
            //using (var tx=Session.BeginTransaction())
            {
                IQuery sQLQuery = Session.CreateSQLQuery(sql);
                for (int i = 0; i < ids.Length; i++)
                {
                    sQLQuery = sQLQuery.SetInt64(i, ids[i].Value);
                }
                int res = sQLQuery.ExecuteUpdate();
                //tx.Commit();
            }
        }

       

        protected virtual string GetTable()
        {
            return string.Empty;
        }
    }
}