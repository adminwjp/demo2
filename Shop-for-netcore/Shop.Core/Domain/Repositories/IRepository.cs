namespace Shop.Domain.Repositories
{
    using Abp.Domain.Entities;
    using System.Collections.Generic;
    using System;

    public interface IRepository<TEntity>:IRepository<TEntity,long>
     where TEntity:class,IEntity<long>
     {

    }
    public interface IRepository<TEntity,Key>:Abp.Domain.Repositories.IRepository<TEntity,Key> 
     where TEntity:class,IEntity<Key>
    {
        void Add(List<TEntity> objs);

        void Update(List<TEntity> objs);

         void Delete(List<Key> ids);

         List<TEntity> GetList(List<Key> ids);

         Tuple<List<TEntity>,long> GetList(int page,int size);

        Tuple<List<TEntity>,long> GetList(TEntity query,int page,int size);

        bool IsExistsAny(List<Key> ids);

        bool IsExistsAll(List<Key> ids);

        bool IsExists(Key id);
    }
}