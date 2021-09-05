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

    public class StudentController:BaseController<StudentAppService,IRepository<Student>,CreateStudentInput,
    UpdateStudentInput,QueryStudentInput,QueryStudentOutput,Student>
    {
          public StudentController(StudentAppService service):base(service){

        }
    }
}