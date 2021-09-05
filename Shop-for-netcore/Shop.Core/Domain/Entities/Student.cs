namespace Shop.Domain.Entities{
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("t_student")]
    public class Student:IEntity<Int64>, IHasCreationTime, IHasModificationTime, IHasDeletionTime{
        [Column("id")] 
        public virtual long Id{get;set;}
        [Column( "student_id")]   
        [StringLength(10)]
        public virtual String StudentId{get;set;}
        [Column( "name")]   
        [StringLength(20)]
        public virtual String Name{get;set;}
        [Column( "age")]   
        public virtual int Age{get;set;}
         [Column( "sex")]   
        public virtual String Sex{get;set;}
        [Column( "class_id")]   //ClassId class_id
        public virtual long? class_id{get;set;}
        [ForeignKey("class_id")]
        public virtual Class Class{get;set;}
          [Column("create_date")]
        public virtual DateTime CreationTime { get; set; }
        /// <summary>
        /// 修改 时间
        /// </summary>
        [Column("modify_date")]
        public virtual DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [Column("delete_date")]
        public virtual DateTime? DeletionTime { get; set; }
        /// <summary>
        /// 软删除 标识
        /// </summary>
        [Column("is_delete")]
        public virtual bool IsDeleted { get; set; }
        public virtual bool IsTransient(){
            return true;
        }
    }
}