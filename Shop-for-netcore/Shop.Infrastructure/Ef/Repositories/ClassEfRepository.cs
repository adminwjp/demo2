
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
  

    public class ClassEfRepository:BaseEfRepositoryByHasDeletionTime<Class>,IClassRepository
    {
        public ClassEfRepository(IDbContextProvider<ShopDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
         public virtual List<Tuple<long,String>> GetClasss(){
           return  base.GetAll()
           .Select(it=>new Tuple<long,String>(it.Id,it.Name)).ToList();
        }
    }
}