namespace Shop.Domain.Repositories
{
    using Shop.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using Abp.Domain.Entities;
    
    public interface IUserRepository<Entity>:IRepository<Entity>
     where Entity:User<Entity>,IEntity<long>
    {
        List<Entity> FindByNameLike(String name);

        Entity FindByAccountAndPwd(String account, String pwd);

        Entity FindByEmailAndPwd(String email, String pwd);



        long CountByAccount(string account);

        long CountByPhone(String phone);

        long CountByEmail(String email);

        Tuple<List<Entity>,long> FindAll();
    }
}