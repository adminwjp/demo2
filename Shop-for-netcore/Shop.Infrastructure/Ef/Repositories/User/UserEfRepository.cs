
#if NET48
    using Abp.EntityFramework;
    using Abp.EntityFramework.Repositories;
#else
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
#endif
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ef.Repositories
{
    public class UserEfRepository<Entity> : BaseEfRepositoryByHasDeletionTime<Entity>, IUserRepository<Entity>
        where Entity : User<Entity>, new()
    {
        public UserEfRepository(IDbContextProvider<ShopDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
        public virtual long CountByAccount(string account)
        {
            return Count(it => it.Account == account && !it.IsDeleted);
        }

        public virtual long CountByEmail(string email)
        {
            return Count(it => it.Email == email && !it.IsDeleted);
        }

        public virtual long CountByPhone(string phone)
        {
            return Count(it => it.Email == phone&& !it.IsDeleted);
        }

        public virtual Tuple<List<Entity>, long> FindAll()
        {
            var data= GetAll().Where(it => !it.IsDeleted).ToList();
            var count = Count(it => !it.IsDeleted);
            return new Tuple<List<Entity>, long>(data,count);
        }

        public virtual Entity FindByAccountAndPwd(string account, string pwd)
        {
            return GetAll().Where(it => it.Account == account && it.Pwd == pwd && !it.IsDeleted).FirstOrDefault();
        }

        public Entity FindByEmailAndPwd(string email, string pwd)
        {
            return GetAll().Where(it => it.Email==email&&it.Pwd==pwd && !it.IsDeleted).FirstOrDefault();
        }

        public virtual List<Entity> FindByNameLike(string name)
        {
            return GetAll().Where(it => it.Name.Contains(name) && !it.IsDeleted).ToList();
        }

        public virtual Entity FindByPhoneAndPwd(string phone, string pwd)
        {
            return GetAll().Where(it => it.Phone == phone && it.Pwd == pwd && !it.IsDeleted).FirstOrDefault();
        }
       
    }
}