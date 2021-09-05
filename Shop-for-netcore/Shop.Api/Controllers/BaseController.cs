namespace Shop.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Abp.AspNetCore.Mvc.Controllers;
    using Abp.Web.Models;
    using Shop.Application.Services;
    using Shop.Domain.Repositories;
    using Abp.Domain.Entities;
    using Abp.Application.Services.Dto;
    using Utility.Domain.Entities;

    [Route("api/v{version:apiVersion}/admin/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [DontWrapResult]//abp 改变默认封装的返回格式
    public class BaseController<Service, Repository, CreateInput, UpdateInput, QueryInput, QueryOutput, Entity> : AbpController
        where Service: AppService<Repository, CreateInput, UpdateInput, QueryInput, QueryOutput, Entity>
         where Repository : IRepository<Entity>
        where CreateInput : class
        where UpdateInput : class,IEntityDto<long>
        where QueryInput : class
        where QueryOutput : class,IEntityDto<long>
        where Entity :class, Abp.Domain.Entities.IEntity<long>
    {
        protected Service service;
        public BaseController(Service service)
        {
            this.service = service;
        }
        [HttpPost("Insert")]
        public virtual dynamic Insert([FromBody] CreateInput create)
        {
            //ModelState.Clear();
            if (!ModelState.IsValid)
            {
                return new { status = false, code = 400 };
            }
            int res = service.Insert(create);
            return new {status=true,code=200};
        }
     
        [HttpPost("Update")]
        public virtual dynamic Update([FromBody] UpdateInput update)
        {
            //ModelState.Clear();
            if (!ModelState.IsValid)
            {
                return new { status = false, code = 400 };
            }
            int res = service.Update(update);
             return new {status=true,code=200};
        }
        [HttpGet("delete/{id}")]
        public virtual dynamic Delete(long id)
        {
            service.Delete(id);
             return new {status=true,code=200};
        }
        [HttpPost("delete")]
        public virtual dynamic DeleteList([FromBody] DeleteEntity<long> ids)
        {
            service.Delete(ids.Ids.ToList());
            return new {status=true,code=200};
        }
    
        [HttpPost("list/{page}/{size}")]
        public virtual dynamic FindByPage([FromBody] QueryInput entity, int page = 1, int size = 10)
        {
            var res = service.Find(entity, page, size);
            return new {status=true,code=200,data=res};
        }
        [HttpGet("list/{page}/{size}")]
        public virtual dynamic List(int page = 1, int size = 10)
        {
            var res = service.Find( page, size);
            return new { status = true, code = 200, data = res };
        }
    }
}