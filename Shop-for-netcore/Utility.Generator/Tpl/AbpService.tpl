using Abp.Domain.Entities;
using Abp.Application.Services;
using System;
using Abp.ObjectMapping;
using Abp.Domain.Uow;
using {.class_namespace};
using {.dto_namespace};
using {.repository_namespace};
using System.Collections.Generic; 

namespace {.namespace}
{
    [UnitOfWork]
     public class {.class}AppService:AppService<IRepository<{.class}>,Create{.class}Input,
    Update{.class}Input,Query{.class}Input,Query{.class}Output,{.class}>
    {
        public {.class}AppService(IRepository<{.class}> repository, IObjectMapper objectMapper) : base(repository,objectMapper)
        {
           
        }

    }
}
