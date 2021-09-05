namespace Shop.Api.Controllers
{
    using Abp.Domain.Entities;
    using Shop.Domain.Repositories;
    using Abp.Application.Services;
    using System;
    using Abp.ObjectMapping;
    using Abp.Domain.Uow;
    using Shop.Domain.Entities;
    using Shop.Application.Services.Dtos;
    using Shop.Application.Services;
    using System.Web.Http;

    public class ClassController:BaseController<ClassAppService,IClassRepository,CreateClassInput,
    UpdateClassInput,QueryClassInput,QueryClassOutput,Class>
    {
        public ClassController(ClassAppService service):base(service){

        }
      
        [Route("tree")]
        [HttpGet]
        public dynamic GetClasss(){
            return new {status=true,code=200,data=service.GetClasss()};
        }
    }
}