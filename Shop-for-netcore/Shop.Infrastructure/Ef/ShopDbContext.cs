using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Ef.EntityMappings;

using Utility;
#if NET48
    using System.Data.Entity;
    using Abp.EntityFramework;
#else
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Abp.EntityFrameworkCore;
using Utility.Ef;
#endif

namespace Shop.Ef
{

#if NET5_0
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        public ShopDbContext CreateDbContext(string[] args)
        {
            //Method not found: 'System.Collections.Generic.Dictionary`2<System.String,System.Object> Microsoft.Extensions.Configuration.IConfigurationBuilder.get_Properties()'.
            ConfigHelper.DbFlag = DbFlag.Sqlite;

            string product = "Data Source=E:/work/utility/Utility-for-net/Example/Example.Web/demo.db;";
            // ConfigHelper.ConnectionString =ConfigManager.GetByConsul($"ShopProduct/{ConfigHelper.DbFlag}ConnectionString");
            ConfigHelper.ConnectionString = product;
            var bulder = AbstractDesignTimeDbContextFactory<ShopDbContext>.Parse();
            return new ShopDbContext(bulder.Options);
        }
    }
#endif
    //注解 太麻烦  mapp太麻烦 
    // 有接口 ？ 都搞得 这么不灵活! 灵活 设置 表名 或 列名
    //https://www.cnblogs.com/mmry/p/7159148.html 
    public class ShopDbContext:AbpDbContext
    {
#if NET48
        public ShopDbContext(string conn) : base(conn)
        {

        }
#else
        public ShopDbContext(DbContextOptions options) : base(options)
        {

        }
        // public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
        // {

        // }
#endif


        /// <summary>
        /// 不给 注释 mapp 该 属性 名称 就是 表名 ef core
        /// </summary>
       // public DbSet<Class> Classs { get; set; }
       // public DbSet<Student> Students { get; set; }


        //public DbSet<User> Buyers { get; set; }
        //public DbSet<Seller> Sellers { get; set; }




        //nhibernate mapp 
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }
        //public DbSet<OrderPay> OrderPays { get; set; }
        //public DbSet<OrderShip> OrderShips { get; set; }
        //public DbSet<OrderLog> OrderLogs { get; set; }
        //public DbSet<Cart> Carts { get; set; }

        //nhibernate annotation
        // public DbSet<ProductMsg> ProductMsgs { get; set; }


        //ef mapp
        public DbSet<EmailNotifyProduct> EmailNotifyProducts { get; set; }


     



#if NET5_0
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly,it=> {
            //   return !it.IsAbstract&&it.Namespace== "Shop.Ef.EntityMappings";
            // });
            modelBuilder.ApplyConfiguration(new EmailNotifyProductMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            base.OnConfiguring(optionsBuilder);
        }
#endif
    }

}