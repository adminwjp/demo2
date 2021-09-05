namespace Shop.Domain.Entities{
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    
    [Table("t_class")]
    public class Class :IEntity<Int64>, IHasCreationTime, IHasModificationTime, IHasDeletionTime{
        [Column("id")]   
        public virtual Int64 Id{get;set;}
        [Column( "name")]   
        [StringLength(20)]
        public virtual String Name{get;set;}
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