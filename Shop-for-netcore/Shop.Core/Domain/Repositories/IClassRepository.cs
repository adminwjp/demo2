namespace Shop.Domain.Repositories
{
    using Shop.Domain.Entities;
    using System;
    using System.Collections.Generic;

    public interface  IClassRepository:IRepository<Class>
    {
        List<Tuple<long,String>> GetClasss();
    }
}