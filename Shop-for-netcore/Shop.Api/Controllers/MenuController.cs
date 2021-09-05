//namespace Shop.Api.Controllers
//{
//    using Abp.Domain.Entities;
//    using Shop.Domain.Repositories;
//    using Abp.Application.Services;
//    using System;
//    using Abp.ObjectMapping;
//    using Abp.Domain.Uow;
//    using Shop.Domain.Entities;
//    using Shop.Application.Services.Dtos;
    
//    using Shop.Application.Services;
//    using Microsoft.AspNetCore.Mvc;

//    public class MenuController:BaseController<MenuAppService,IMenuRepository,CreateMenuInput,
//    UpdateMenuInput,QueryMenuInput,QueryMenuOutput,Menu>
//    {
//        public MenuController(MenuAppService service):base(service){

//        }
//        [HttpGet("group")]
//        public dynamic GetGroups(){
//            return new {status=true,code=200,data=service.GetGroups()};
//        }
//        [HttpGet("")]
//        public dynamic GetMenus(){
//            return new {status=true,code=200,data=service.GetMenus()};
//        }
//        [HttpGet("tree")]
//        public dynamic GetListMenus(){
//            return new {status=true,code=200,data=service.GetListMenus()};
//        }
//    }
//}