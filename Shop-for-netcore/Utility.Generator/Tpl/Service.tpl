using Utility.Domain.Entities;
using Utility.Application.Services;
using System;
using Utility.ObjectMapping;
using {.class_namespace};
using {.dto_namespace};
using {.repository_namespace};
using System.Collections.Generic; 
using Utility.Domain.Repositories;

namespace {.namespace}
{
    public class {.class}ResponseService : ResponseApiService<{.class}AppService,IRepository<{.class},int?>,Create{.class}Input,
    Update{.class}Input,Query{.class}Input,Query{.class}Output,{.class},int?>
    {
        public {.class}ResponseService({.class}AppService service) : base(service)
        {
        }

    }
    //[UnitOfWork]
     public class {.class}AppService:CrudApplicationService<IRepository<{.class},int?>,Create{.class}Input,
    Update{.class}Input,Query{.class}Input,Query{.class}Output,{.class},int?>
    {
        public {.class}AppService(IRepository<{.class},int?> repository, IObjectMapper objectMapper) : base(repository)
        {
            this.ObjectMapper = objectMapper;           
        }

    }
}
