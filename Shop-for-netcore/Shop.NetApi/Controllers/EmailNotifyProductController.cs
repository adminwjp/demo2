namespace Shop.Api.Controllers
{
    using Shop.Domain.Entities;
    using Shop.Application.Services.Dtos;
    using Shop.Domain.Repositories;
    using Shop.Application.Services;
    using Abp.Application.Services;
    using System;
    using Abp.ObjectMapping;
    using Abp.Domain.Uow;

    public class EmailNotifyProductController:BaseController<EmailNotifyProductAppService,IRepository<EmailNotifyProduct>,CreateEmailNotifyProductInput,
    UpdateEmailNotifyProductInput,QueryEmailNotifyProductInput,QueryEmailNotifyProductOutput,EmailNotifyProduct>
    {
        public EmailNotifyProductController(EmailNotifyProductAppService service):base(service){

        }
      
    }
}