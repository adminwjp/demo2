
namespace Shop.Ef.Repositories
{
    using Shop.Domain.Repositories;
    using Shop.Domain.Entities;
    using Abp.Domain.Uow;
#if NET48
    using Abp.EntityFramework;
    using Abp.EntityFramework.Repositories;
    using System.Data.Entity;
#else
    using Abp.EntityFrameworkCore;
    using Abp.EntityFrameworkCore.Repositories;
    using Microsoft.EntityFrameworkCore;
#endif
    using Abp.Linq.Expressions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Abp.Domain.Entities.Auditing;

    public class StudentEfRepository:BaseEfRepositoryByHasDeletionTime<Student>,IRepository<Student>
    {
        public StudentEfRepository(IDbContextProvider<ShopDbContext> dbContextProvider) : base(dbContextProvider)
        {
 
        }
        public override Tuple<List<Student>,long> GetList(Student query,int page,int size){
          if(query.Id>0)
          {
              return base.GetList(base.GetAll().Where(it => it.Id==query.Id)
              //.OrderBy(it => it.CreationTime)
              ,page,size);
          }
          return base.GetList(base.GetAll()
           //.OrderBy(it => it.CreationTime)
           ,page,size);
        }

    }
}