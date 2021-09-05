namespace {.namespace}
{
    using {.class_namespace};
    using {.dto_namespace};
    using {.repository_namespace};
    using {.service_namespace};
    using Abp.Application.Services;
    using System;
    using Abp.ObjectMapping;
    using Abp.Domain.Uow;
    using Microsoft.AspNetCore.Mvc;

    public class {.class}Controller:BaseController<{.class}AppService,IRepository<{.class}>,Create{.class}Input,
    Update{.class}Input,Query{.class}Input,Query{.class}Output,{.class}>
    {
        public {.class}Controller({.class}AppService service):base(service){

        }
      
    }
}