using Abp.Domain.Entities;
using Abp.Application.Services;
using System;
using Abp.ObjectMapping;
using Abp.Domain.Uow;
using Shop.Domain.Entities;
using Shop.Application.Services.Dtos;
using Shop.Domain.Repositories;
using System.Collections.Generic; 

namespace Shop.Application.Services
{
    //[UnitOfWork]
    public abstract class UserAppService<BaseUser> : AppService<IUserRepository<BaseUser>, CreateUserInput,
     UpdateUserInput, QueryUserInput, QueryUserOutput, BaseUser>
        where BaseUser : User<BaseUser>
    {
        public UserAppService(IUserRepository<BaseUser> repository, IObjectMapper objectMapper) : base(repository, objectMapper)
        {

        }
        public virtual  long CountByAccount(string account)
        {
            return repository.CountByAccount(account);
        }

        public virtual long CountByEmail(string email)
        {
            return repository.CountByAccount(email);
        }

        public virtual long CountByPhone(string phone)
        {
            return repository.CountByAccount(phone);
        }

        public virtual Tuple<List<BaseUser>, long> FindAll()
        {
            return repository.FindAll();
        }

        public virtual BaseUser FindByAccountAndPwd(string account, string pwd)
        {
            return repository.FindByAccountAndPwd(account,pwd);
        }

        public virtual BaseUser FindByEmailAndPwd(string email, string pwd)
        {
            return repository.FindByAccountAndPwd(email, pwd);
        }

        public virtual List<BaseUser> FindByNameLike(string name)
        {
            return repository.FindByNameLike(name);
        }

        public virtual BaseUser FindByPhoneAndPwd(string phone, string pwd)
        {
            return repository.FindByAccountAndPwd(phone, pwd);
        }
    }
}
