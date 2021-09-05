using {.class_namespace};
using Microsoft.EntityFrameworkCore;

namespace {.namespace}
{
    public  class {.class_map} :Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<{.class}> 
    { 
        public {.class_map}(string tableName)
        {
            this.TableName=tableName;
        }
        public {.class_map}()
        {
            this.TableName="{.table_name}";
        }
        public virtual void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<{.class}> builder)
        { 
            builder.ToTable(this.TableName);
            //builder.HasKey(it => it.Id).HasName("id");//.HasAnnotation("MySql: ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
            //builder.HasKey(it => it.Id);
            //builder.Property(it => it.Id).HasColumnName("id").HasMaxLength(36).IsRequired(false);//.ValueGeneratedOnAdd();   
            this.Set(builder);

        }

        protected virtual void Set(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<{.class}> builder){
{.string_code}
        }
        protected string TableName { get; set; }

      
    }
}