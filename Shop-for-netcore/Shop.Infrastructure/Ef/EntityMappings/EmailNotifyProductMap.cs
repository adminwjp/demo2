#if NET48
using Shop.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Shop.Ef.EntityMappings
{
    public class EmailNotifyProductMap : EntityTypeConfiguration<EmailNotifyProduct>
    {
    
        public EmailNotifyProductMap()
        {
            this.TableName = "t_email_notify_product";
        }
        public virtual void Configure()
        {
            ToTable(this.TableName);
            //builder.HasKey(it => it.Id).HasName("id");//.HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
            //builder.HasKey(it => it.Id);
            //builder.Property(it => it.Id).HasColumnName("id").HasMaxLength(36).IsRequired(false);//.ValueGeneratedOnAdd();   
        
            HasKey(it => it.Id);//.HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
             Property(x => x.Id).HasColumnName("id");
            Property(x => x.Status).HasColumnName("status");
            Property(x => x.Notifydate).HasColumnName("notifydate");
            Property(x => x.ProductName).HasColumnName("product_name").HasMaxLength(50);
            Property(x => x.ReceiveEmail).HasColumnName("receive_email").HasMaxLength(50);
           Property(x => x.ProductID).HasColumnName("product_i_d");
           Property(x => x.SendFailureCount).HasColumnName("send_failure_count");
            Property(x => x.Account).HasColumnName("account").HasMaxLength(50);
            Property(x => x.SellerId).HasColumnName("seller_id");
            Property(x => x.BuyerId).HasColumnName("buyer_id");



        }
        protected string TableName { get; set; }

    }
 }
#else
using Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shop.Ef.EntityMappings
{
    public  class EmailNotifyProductMap :Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<EmailNotifyProduct> 
    { 
        public EmailNotifyProductMap(string tableName)
        {
            this.TableName=tableName;
        }
        public EmailNotifyProductMap()
        {
            this.TableName="t_email_notify_product";
        }
        public virtual void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EmailNotifyProduct> builder)
        { 
            builder.ToTable(this.TableName);
            //builder.HasKey(it => it.Id).HasName("id");//.HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
            //builder.HasKey(it => it.Id);
            //builder.Property(it => it.Id).HasColumnName("id").HasMaxLength(36).IsRequired(false);//.ValueGeneratedOnAdd();   
            this.Set(builder);

        }

        protected virtual void Set(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EmailNotifyProduct> builder){
            builder.HasKey(it => it.Id).HasName("id");//.HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
           builder.Property(x => x.Status).HasColumnName("status").HasMaxLength(50);
           builder.Property(x => x.Notifydate).HasColumnName("notifydate").HasMaxLength(50);
           builder.Property(x => x.ProductName).HasColumnName("product_name").HasMaxLength(50);
           builder.Property(x => x.ReceiveEmail).HasColumnName("receive_email").HasMaxLength(50);
           builder.Property(x => x.ProductID).HasColumnName("product_i_d").HasMaxLength(50);
           builder.Property(x => x.SendFailureCount).HasColumnName("send_failure_count").HasMaxLength(50);
           builder.Property(x => x.Account).HasColumnName("account").HasMaxLength(50);
           builder.Property(x => x.SellerId).HasColumnName("seller_id").HasMaxLength(50);
           builder.Property(x => x.BuyerId).HasColumnName("buyer_id").HasMaxLength(50);



        }
        protected string TableName { get; set; }

      
    }
}
#endif