using Abp.Domain.Entities;
using Shop.Domain.Repositories;
using Abp.Application.Services;
using System;
using Abp.ObjectMapping;
using Abp.Domain.Uow;
using Shop.Domain.Entities;
using Shop.Application.Services.Dtos;
using System.Collections.Generic; 

namespace Shop.Application.Services
{
   // [UnitOfWork]
     public class ClassAppService:AppService<IClassRepository,CreateClassInput,
    UpdateClassInput,QueryClassInput,QueryClassOutput,Class>
    {
        public ClassAppService(IClassRepository repository, IObjectMapper objectMapper) : base(repository,objectMapper)
        {
           
        }

       
        public virtual List<TreeOutput> GetClasss(){
            var data=repository.GetClasss();
            if(data!=null){
                List<TreeOutput> list=new List<TreeOutput>();
                data.ForEach(it=>{
                    list.Add(new TreeOutput(){Title=it.Item2,Id=it.Item1});
                });
                return list;
            }
            return null;
        }

    }
}
