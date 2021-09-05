using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Logging;
using Abp.WebApi.Controllers;
using Abp.Web.Models;
using Shop.Application.Services;
using Shop.Domain.Repositories;
using Abp.Domain.Entities;
using Abp.Application.Services.Dto;
using Utility.Domain.Entities;
using System.Web.Http;

namespace Shop.Api.Controllers
{
    [Route("api/v{version:apiVersion}/admin/[controller]")]
    [DontWrapResult]//abp 改变默认封装的返回格式
    public class BaseController<Service, Repository, CreateInput, UpdateInput, QueryInput, QueryOutput, Entity> : AbpApiController
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
        [Route("Insert")]
        [HttpPost]
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
        [Route("Update")]
        [HttpPost]
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
        [Route("delete/{id}")]
        [HttpGet]
        public virtual dynamic Delete(long id)
        {
            service.Delete(id);
             return new {status=true,code=200};
        }
        [Route("delete")]
        [HttpPost]
        public virtual dynamic DeleteList([FromBody] DeleteEntity<long> ids)
        {
            service.Delete(ids.Ids.ToList());
            return new {status=true,code=200};
        }
        [Route("list/{page}/{size}")]
        [HttpPost]
        public virtual dynamic FindByPage([FromBody] QueryInput entity, int page = 1, int size = 10)
        {
            var res = service.Find(entity, page, size);
            return new {status=true,code=200,data=res};
        }

        [Route("list/{page}/{size}")]
        [HttpGet]
        public virtual dynamic List(int page = 1, int size = 10)
        {
            var res = service.Find( page, size);
            return new { status = true, code = 200, data = res };
        }
    }
}