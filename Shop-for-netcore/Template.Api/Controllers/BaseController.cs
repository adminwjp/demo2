namespace Template.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Abp.AspNetCore.Mvc.Controllers;
    using Abp.Web.Models;
    using Abp.Domain.Entities;
    using Abp.Application.Services.Dto;
    using Abp.Application.Services;
    using Utility.Domain.Entities;
    using Abp.Domain.Repositories;
    using Abp.Domain.Uow;
    using Abp.NHibernate.Repositories;
    using Utility.Application.Services.Dtos;
	
	using Abp.Linq.Expressions;
	using Abp.NHibernate;
	using Abp.NHibernate.Repositories;
	using NHibernate;
	using NHibernate.Criterion;
	using NHibernate.Linq;
    using Template.Api.Repositories;

    [Route("api/v{version:apiVersion}/admin/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [DontWrapResult]//abp 改变默认封装的返回格式
    [UnitOfWork]
    public class BaseController<TEntity> : AbpController
        where TEntity :class, Abp.Domain.Entities.IEntity<long?>
    {
        // protected NhRepositoryBase<TEntity,long?> respository;
        protected IRepository<TEntity, long?> respository;
		//protected IBaseRepository<TEntity> respository;
        protected ISessionFactory sessionFactory;
        //protected NhRepositoryBase<TEntity, long?>  nhRepositoryBase;
        //NhRepositoryBase proxy  NhRepositoryBase
        //NhRepositoryBase<TEntity,long?> respository
        public BaseController(IRepository<TEntity, long?> respository, ISessionFactory sessionFactory)
        {
            this.respository = respository;
            //this.nhRepositoryBase=(NhRepositoryBase<TEntity, long?> )respository;
            this.sessionFactory = sessionFactory;
        }
        //public BaseController(IBaseRepository<TEntity> respository,ISessionFactory sessionFactory)
        //{
        //    this.respository = respository;
        //    //this.nhRepositoryBase=(NhRepositoryBase<TEntity, long?> )respository;
        //    this.sessionFactory = sessionFactory;
        //}
        [HttpPost("Insert")]
        public dynamic Insert([FromBody] TEntity create)
        {
            InsertBefore(create);
            respository.Insert(create);
            return new {status=true,code=200};
        }

        [HttpPost("insert_many")]
        public dynamic Insert([FromBody] ListDto<TEntity> create)
        {
            create.Data.ForEach(it=>{
                InsertBefore(it);
                respository.Insert(it);
            });
         
            return new {status=true,code=200};
        }
     

        protected virtual void InsertBefore(TEntity create){
            
        }
        [HttpPost("Update")]
        public dynamic Update([FromBody] TEntity update)
        {
            UpdateBefore(update);
             respository.Update(update);
             return new {status=true,code=200};
        }

         [HttpPost("update_many")]
        public dynamic Update([FromBody] ListDto<TEntity> update)
        {
            update.Data.ForEach(it=>{
                UpdateBefore(it);
                respository.Update(it);
            });
            return new {status=true,code=200};
        }
        protected virtual void UpdateBefore(TEntity update){
            
        }
        [HttpGet("delete/{id}")]
        public dynamic Delete(long? id)
        {
            if(id.HasValue&&id.Value>0){
                respository.Delete(id);
                return new {status=true,code=200};
            }
            return new {status=false,code=400};
        }
        [HttpPost("delete")]
        public dynamic DeleteList([FromBody] DeleteEntity<long?> ids)
        {
            foreach (var id in ids.Ids)
                if(id.HasValue&&id.Value>0)
                    respository.Delete(id);
            return new {status=true,code=200};
        }
		//protected virtual AbstractCriterion GetWhere(TEntity entity)
        //{
            //this_.IsDeleted = ?p0 AND this_.is_deleted = ? 为什么 出现这种情况
            //6.2.0 不能升级  6.1.1
       //     AbstractCriterion criterion = Expression.Eq("IsDeleted", false);
       //     if (entity.Id.HasValue&&entity.Id.Value>0)
       //     {
       //         criterion |= Expression.Eq("Id", entity.Id);
       //     }
       //     return criterion;
       // }
		//internal ICriteria GetCriteria(TEntity entity)
       // {
        //    var where = GetWhere(entity);
        //    ICriteria criteria = nhRepositoryBase.Session.CreateCriteria<TEntity>();
           // criteria.AddOrder(Order.Desc("CreationTime"));
       //     if (where != null)
       //     {
       //         criteria = criteria.Add(where);
       //     }
        //    return criteria;
       // }
        [HttpPost("find/{page}/{size}")]
        public dynamic FindByPage([FromBody] TEntity entity, int page = 1, int size = 10)
        {
            //map 映射异常(最好使用 NHibernate map ,要么看源码设置 放弃) hbm 正常
            //System.ObjectDisposedException: Session is closed!
            //var res = respository.GetAll().Skip((page-1)*size).Take(size).ToList();
            //nhibernate failed to lazily initialize a collection  
            //var res = respository.FindByPage(entity,page,size);
            using var session = sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
           var res = session.CreateCriteria<TEntity>().SetFirstResult((page - 1) * size).SetMaxResults(size).List<TEntity>();
            ///ICriteria criteria = GetCriteria(entity);
            //var res = criteria.SetFirstResult((page - 1) * size).SetMaxResults(size).List<TEntity>();
            return new {status=true,code=200,data=res};
        }

    }
}