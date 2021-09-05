using System;
namespace Shop.Application.Services.Dtos
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Abp.AutoMapper;
    using Shop.Domain.Entities;
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using EventCloud;
    [AutoMap(typeof(Class))]
    public class CreateClassInput
    {
        private string name;

        protected virtual void OnPropertyChanged(string propertyName = null) { }
        //[Required()]
        public virtual String Name { get => name; set => name = value; }

    }

    [AutoMap(typeof(Class))]
    public class UpdateClassInput : IEntityDto<long>
    {
        private long id;
        private string name;

        protected virtual void OnPropertyChanged(string propertyName = null) { }
        public virtual long Id { get => id; set => id = value; }
        public virtual String Name { get => name; set => name = value; }
    }

    [AutoMap(typeof(Class))]
    public class QueryClassInput
    {
        protected virtual void OnPropertyChanged(string propertyName = null) { }
        public virtual String Name{get;set;}
    }

    [AutoMap(typeof(Class))]
    public class QueryClassOutput:IEntityDto<long>
    {
        protected virtual void OnPropertyChanged(string propertyName = null) { }
        public virtual long Id{get;set;}
        public virtual String Name{get;set;}

        public virtual List<QueryStudentOutput> Students{get;set;}
      
    }

}