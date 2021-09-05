namespace Shop.Application.Services.Dtos
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using Shop.Domain.Entities;
    using System;
    using Abp.Application.Services.Dto;
    using EventCloud;
    [AutoMap(typeof(Student))]
    public class CreateStudentInput
    {
        protected virtual void OnPropertyChanged(string propertyName = null) { }
        public virtual String StudentId{get;set;}
        public virtual String Name{get;set;}
        public virtual int Age{get;set;}
        public virtual String Sex{get;set;}
        public virtual long? ClassId{get;set;}
    }

    [AutoMap(typeof(Student))]
    public class UpdateStudentInput:IEntityDto<long>
    {
        protected virtual void OnPropertyChanged(string propertyName = null) { }
        public virtual long Id{get;set;}
        public virtual String StudentId{get;set;}
        public virtual String Name{get;set;}
        public virtual int Age{get;set;}
        public virtual String Sex{get;set;}
        public virtual long? ClassId{get;set;}
    }

     [AutoMap(typeof(Student))]
    public class QueryStudentInput
    {
        protected virtual void OnPropertyChanged(string propertyName = null) { }
        public virtual String StudentId{get;set;}
        public virtual String Name{get;set;}
        public virtual int Age{get;set;}
        public virtual String Sex{get;set;}
        public virtual long? ClassId{get;set;}
    }

     [AutoMap(typeof(Student))]
    public class QueryStudentOutput:IEntityDto<long>
    {
        protected virtual void OnPropertyChanged(string propertyName = null) { }
        public virtual long Id{get;set;}
        public virtual String StudentId{get;set;}
        public virtual String Name{get;set;}
        public virtual int Age{get;set;}
        public virtual String Sex{get;set;}
        public virtual long? ClassId{get;set;}
          [Column("create_date")]
        public virtual DateTime CreationTime { get; set; }

        [Column("modify_date")]
        public virtual DateTime? LastModificationTime { get; set; }
   
        public virtual DateTime? DeletionTime { get; set; }
      
    
        public virtual bool IsDeleted { get; set; }
    }
}