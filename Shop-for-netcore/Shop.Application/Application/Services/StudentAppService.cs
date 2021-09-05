namespace Shop.Application.Services
{
    using Abp.Domain.Entities;
    using Shop.Domain.Repositories;
    using Abp.Application.Services;
    using System;
    using Abp.ObjectMapping;
    using Abp.Domain.Uow;
    using Shop.Domain.Entities;
    using Shop.Application.Services.Dtos;
    using System.Collections.Generic;  
  

    //[UnitOfWork]
     public class StudentAppService:AppService<IRepository<Student>,CreateStudentInput,
    UpdateStudentInput,QueryStudentInput,QueryStudentOutput,Student>
    {
        public StudentAppService(IRepository<Student> repository, IObjectMapper objectMapper) : base(repository,objectMapper)
        {
           
        }
        protected override void InsertBefore(List<CreateStudentInput> create,List<Student> entity){
                for(var i=0;i<create.Count;i++){
                    entity[i].class_id=create[i].ClassId;
                }
         }
         protected override void InsertBefore(CreateStudentInput create,Student entity){
            entity.class_id=create.ClassId;
         }

         protected override void UpdateBefore(List<UpdateStudentInput> update,List<Student> entity){
            for(var i=0;i<update.Count;i++){
                    entity[i].class_id=update[i].ClassId;
                }
         }

         protected override void UpdateBefore(UpdateStudentInput update,Student entity){
               entity.class_id=update.ClassId;
         }

        protected override void FindBefore(QueryStudentInput queryInput,Student entity){
            entity.class_id=queryInput.ClassId;
        }
    }
}