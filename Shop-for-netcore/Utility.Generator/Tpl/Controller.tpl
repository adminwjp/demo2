namespace {.namespace}
{
    using {.class_namespace};
    using {.dto_namespace};
    using {.repository_namespace};
    using {.service_namespace};
    using Utility.Application.Services;
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Utility.AspNetCore.Controllers;

    public class {.class}Controller:BaseController<ResponseApiService<{.class}AppService,IRepository<{.class},int?>,Create{.class}Input,
    Update{.class}Input,Query{.class}Input,Query{.class}Output,{.class},int?>,{.class}AppService,IRepository<{.class},int?>,Create{.class}Input,
    Update{.class}Input,Query{.class}Input,Query{.class}Output,{.class},int?>
    {
        public {.class}Controller(ResponseApiService<{.class}AppService,IRepository<{.class},int?>,Create{.class}Input,
    Update{.class}Input,Query{.class}Input,Query{.class}Output,{.class},int?> service){
            this.ApiService= service;
        }
      
    }
}