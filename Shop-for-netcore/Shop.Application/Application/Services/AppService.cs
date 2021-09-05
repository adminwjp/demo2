namespace Shop.Application.Services
{  
     using Abp.Domain.Entities;
     using Shop.Domain.Repositories;
     using Abp.Application.Services;
     using System;
     using Abp.ObjectMapping;
     using Abp.Domain.Uow;
     using System.Collections.Generic;
    using Abp.Application.Services.Dto;

   // [UnitOfWork]
    public class AppService<Repository,CreateInput,UpdateInput,QueryInput,QueryOutput,TEntity>:
    ApplicationService
    //CrudAppService<TEntity, TEntityDto, TPrimaryKey, 
    //TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
   // CrudAppService<TEntity,QueryOutput,long?,QueryInput,CreateInput,UpdateInput,EntityDto<long?>>
    where Repository:Shop.Domain.Repositories.IRepository<TEntity> 
    where CreateInput:class
    where UpdateInput:class , IEntityDto<long>
    where QueryInput:class
      where QueryOutput:class, IEntityDto<long>
    where TEntity:class,IEntity<long>
    {
        protected Repository repository;
        //public IObjectMapper ObjectMapper{get;set;}
        public AppService(Repository repository, IObjectMapper objectMapper)//:base(repository){
        {
             this.repository=repository;
             this.ObjectMapper = objectMapper;
        }
        public virtual int Insert(List<CreateInput> create)
        {
            List<TEntity> entity = ObjectMapper.Map<List<TEntity>>(create);
            InsertBefore(create,entity);
            repository.Add(entity);
            return 1;
        }

         protected virtual void InsertBefore(List<CreateInput> create,List<TEntity> entity){

         }
        public virtual int Insert(CreateInput create)
        {
            TEntity entity = ObjectMapper.Map<TEntity>(create);
              InsertBefore(create,entity);
            repository.Insert(entity);
            return 1;
        }
         protected virtual void InsertBefore(CreateInput create,TEntity entity){

         }
    

        public virtual int Update(UpdateInput update)
        {
            TEntity entity = ObjectMapper.Map<TEntity>(update);
            if(repository.IsExists(update.Id)){
                return 0;
            }
            UpdateBefore(update,entity);
            repository.Update(entity);
            return 1;
        }
 
        protected virtual void UpdateBefore(UpdateInput update,TEntity entity){

         }
        public virtual int Update(List<UpdateInput> update)
        {
            List<TEntity> entity = ObjectMapper.Map<List<TEntity>>(update);
            List<TEntity> temps=new List<TEntity>(update.Count);
            entity.ForEach(it=>{
                 if(!repository.IsExists(it.Id)){
                     temps.Add(it);
                }
            });
            UpdateBefore(update,entity);
            repository.Update(temps);
            return 1;
        }
        protected virtual void UpdateBefore(List<UpdateInput> update,List<TEntity> entity){

         }
  
        public virtual void Delete(long id)
        {
            repository.Delete(id);
        }
        public virtual bool Exists(long id)
        {
           return repository.IsExists(id);
        }
        public virtual bool ExistsAny(List<long> ids)
        {
            return repository.IsExistsAny(ids);
        }
        public virtual bool ExistsAll(List<long> ids)
        {
            return repository.IsExistsAll(ids);
        }
        public virtual IList<QueryOutput> Find()
        {
            var res = repository.GetAllList();
            var result = ObjectMapper.Map<List<QueryOutput>>(res);
            return result;
        }
   
        public virtual void Delete(List<long> ids)
        {
            repository.Delete(ids);
        }

        public virtual IList<QueryOutput> Find(QueryInput queryInput,int page,int size)
        {
            TEntity entity = ObjectMapper.Map<TEntity>(queryInput);
            FindBefore(queryInput,entity);
            var res = repository.GetList(entity,page,size);
            var result = ObjectMapper.Map<List<QueryOutput>>(res.Item1);
            return result;
        }
        protected virtual void FindBefore(QueryInput queryInput,TEntity entity){

        }

        public virtual IList<QueryOutput> Find(int page = 1, int size = 10)
        {
           var res = repository.GetList(page,size);
            var result = ObjectMapper.Map<List<QueryOutput>>(res.Item1);
            return result;
        }

        public virtual QueryOutput Get(long id)
        {
            var res = repository.Get(id);
            if (res == null)
            {
                return null;
            }
            var result = ObjectMapper.Map<QueryOutput>(res);
            return result;
        }
    }
}