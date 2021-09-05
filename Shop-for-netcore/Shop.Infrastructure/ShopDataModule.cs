
using Abp.Modules;
using System.Reflection;
using Shop.Domain.Repositories;
using Shop.Ef.Repositories;
using Shop.Ef;
#if NET48
    using System.Data.Entity;
    using Abp.EntityFramework.Repositories;
    using Abp.EntityFramework;
    using Abp.EntityFramework.Extensions;
#else
using Abp.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;
using Abp.EntityFrameworkCore;
#endif

using Shop.Domain.Entities;
using Abp.Dependency;

using Abp.NHibernate;
using global::NHibernate.Cfg;
using System;
using global::NHibernate;
using global::NHibernate.Tool.hbm2ddl;
using System.IO;
using Utility.IO;
using Abp.Configuration.Startup;
using FluentNHibernate.Cfg;
using global::NHibernate.Mapping.ByCode;
using Abp.NHibernate.Filters;
using EventCloud;
using Shop.NHibernate.Repositories;
using NH = NHibernate;
using EventCloud.EntityFramework;
using Abp.Dapper;
using Abp.ZeroCore.NHibernate;
using Abp.ZeroCore.NHibernate.EntityMappings;
#if NET5_0
using Abp.Zero.EntityFrameworkCore;
using Utility.Ef;

#else
using Abp.Zero.EntityFramework;
//using Abp.Zero.NHibernate;

#endif

namespace Shop
{
    // AbpZeroCoreNHibernateModule  Begin failed with SQL exception 
    //aop 不好调试
    //事务 冲突 应该 不能 使用 dapper ef nh
    //出现 问题根本没法 解决 只能源码调试 麻烦(引用统一源码)
    //ide(引用怎么搞的 非要 重启(要么重新加载)) 调试 dll(需要安装对应版本第三方工具 反编译 调试源码)
    //生成 失败 找不到 具体错误 位置(ms build vs ide 不灵 donet ) 再次 生成 就可以了
    //2(AbpZeroCore 不使用 可以 混合使用 技术栈 ) 选一  不然 ex 
    //orm dapper  ef nhibernate 
    //ef efcore ef annotation ef mapp nh annotation nh mapp  nh xml
    //ef sqlite CreateDatabase is not supported by the provider.
    //System.Data.SQLite.EF6.SQLiteProviderServices(参考 sqlserver 实现原理) 根本 没有这个类
    //难道 需要自定义 实现? 原生 ado.net 支持 包装后 都不支持 你 这 谁还用 不统一
    //找工作 话    这样 混合 各种 技术  当做 练习
    //最好声明接口不然不知道 用哪个  dapper  ef nhibernate 只 实现 一个 
    // 否则 复杂度变高了  不好 维护
    //net ef 配置到处 坑 还有 其它的需要 配置文件 也坑 多 默认 sqlserver (自家的好点 其它可能有问题)
    //暂时 放弃 ef() nhibernate 不该了 net 包 映射了
    //这里 暂时 用 源码 引用 出现问题 好调试 换来换去 麻烦
    //调试 毛线 定时器 异步 顺序无法保证
    //AbpBackgroundJobs 这个 定时器 一直 运行
    //sqlite
    //database is locked database is locked
    //mysql
    //An invalid or incomplete configuration was used while creating a SessionFactory. Check PotentialReasons collection, and InnerException for more detail.
    //纳闷 之前可以现在 不行 你 搞事?
    //最好 不要 使用内部封装 好的应用 demo(用内部技术) 一般 都有 坑
    //也 不修复下(每次 版本 更新 问题 不一样 不好 修复)
    //什么 情况 库 里 有数据 你查 为null(无法操作数据库?)

    [DependsOn(
         typeof(AbpNHibernateModule),
         typeof(AbpDapperModule),
#if NET48
        //typeof(AbpEntityFrameworkModule),
#else
       //  typeof(AbpEntityFrameworkCoreModule),
#endif


#if NET5_0
         //typeof(AbpZeroCoreEntityFrameworkCoreModule),
         typeof(AbpZeroCoreNHibernateModule),
#else
         typeof(AbpZeroCoreNHibernateModule),
          //typeof(AbpZeroEntityFrameworkModule),
         //有问题 map 解决毛线 每次 版本 更新 都 不更新下?
         //typeof(AbpZeroNHibernateModule),//修改后 map 支持 不然 map 有问题 无法使用不知道修复没有
#endif

        typeof(ShopCoreModule))]

    
    public class ShopDataModule : AbpModule
    {
        public static bool IsNH { get; set; } = true;
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString=
            //@"Data Source=E:\work\utility\Utility-for-net\Example\Example.Web\demo.db;";
            "Database=EventCloud;Data Source=127.0.0.1;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
            //abp unit ex
            //abp nh mysql ex
            //8.0.26 真尼玛 奇怪 就 这里 需要 其它 怎么不提示 (8.0.23)
            //show variables like '%ssl%';
            var conn =new MySql.Data.MySqlClient.MySqlConnection(Configuration.DefaultNameOrConnectionString);
            conn.Open();
            //TestMySqlEx(Configuration.DefaultNameOrConnectionString);
#if NET48
            //手动注入 
             IocManager.Register<EventCloudDbContext>();
#else
            Configuration.Modules.AbpEfCore().AddDbContext<ShopDbContext>(options =>
            {
                EfConnectionHelper.GetDbContextOptions(options.DbContextOptions, Configuration.DefaultNameOrConnectionString
                    ,Utility.ConfigHelper.DbFlag);
                //options.DbContextOptions.UseSqlite(Configuration.DefaultNameOrConnectionString);
            });
#endif

            if (IsNH)
            {
                NhPre();
            }

        }
        static void TestMySqlEx(string connStr)
        {
            try
            {
                FluentConfiguration fluentConfiguration = Fluently.Configure();
                Utility.Nhibernate.NhibernateHelper
                   .UseNhibernate(fluentConfiguration, Utility.ConfigHelper.DbFlag, connStr)
                   //  * No mappings were configured through the Mappings method.
                   .Mappings(m =>
                      {
                          m.FluentMappings.Add(typeof(SoftDeleteFilter));//这个是关键的
                          m.FluentMappings.Add(typeof(MayHaveTenantFilter));//这个是关键的
                          m.FluentMappings.Add(typeof(MustHaveTenantFilter));//这个是关键的
                          m.FluentMappings.AddFromAssembly(typeof(EditionMap).Assembly);
                          m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());

                      }
                   );
                var sessionFactory = fluentConfiguration.BuildConfiguration().BuildSessionFactory();
            }
            catch (Exception ex)
            {

            }
        }
        void NhPre()
        {

            //InitiallizeSessionFactory();
            //AbpBootstrapper 启动模型 AbpModuleManager 模块 启动 类 
            //core 也 支持 ConfigurationManager (支持 netstandard)? 
            //NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
            //configuration = configuration.Configure("hibernate.cfg.xml");
            //hbm 集合关联(查询)支持 但 map  FluentNHibernate 异常
            var connStr = string.Empty;
            Configuration configuration = null;
            if (Utility.ConfigHelper.OrmFlag == Utility.OrmFlag.None)
            {
                configuration = (Configuration)Configuration.Modules.AbpNHibernate().FluentConfiguration.GetType().GetProperty("Configuration",
    BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Configuration.Modules.AbpNHibernate().FluentConfiguration);
                //configuration = configuration.Configure("hibernate.cfg.xml");
                connStr = System.Configuration.ConfigurationManager.AppSettings["Default"]; // web.config 获取不到 
            }
            new NH.Dialect.SQLiteDialect();
            connStr = string.IsNullOrEmpty(connStr) ?
                Configuration.DefaultNameOrConnectionString : connStr;//"Database=Shop;Data Source=localhost;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
            Console.WriteLine(connStr);
            Utility.Nhibernate.NhibernateHelper
                .UseNhibernate(Configuration.Modules.AbpNHibernate().
                FluentConfiguration, Utility.ConfigHelper.DbFlag, connStr)
            //Configuration.Modules.AbpNHibernate().FluentConfiguration
            //     .Database(
            //         //MySQLConfiguration
            //         SQLiteConfiguration
            //     .Standard.ConnectionString(connStr).ShowSql().
            //     FormatSql().Raw("hbm2ddl.auto", "update"))
               // .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                ;

            // .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false, IocManager.Resolve<DbConnection>(), Console.Out));

            if (Utility.ConfigHelper.OrmFlag == Utility.OrmFlag.Xml)
            {
                foreach (var item in Directory.GetFiles("Config/hbm", "*.hbm.xml"))
                {
                    configuration.AddXmlFile(item);
                }
                SchemaExport export = new SchemaExport(configuration);
                FileHelper.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "sql/" + Utility.ConfigHelper.DbFlag.ToString()));
                export.SetOutputFile(Path.Combine(Directory.GetCurrentDirectory(), "sql/" + Utility.ConfigHelper.DbFlag.ToString() + "/sql.sql")); //设置输出目录
                                                                                                                                                   // export.Drop(true, true);//设置生成表结构存在性判断,并删除
                export.Create(false, false);//设置是否生成脚本,是否导出来
            }
        }
        public override void Initialize()
        {
            //不能 用 相同的泛型 不然 不知道 用哪个 不智能 
            //dapper nhibernate ef 
            //IocManager.Register(typeof(IRepository<>), typeof(BaseEfRepositoryByHasDeletionTime<>));
            IocManager.Register(typeof(IUserRepository<>), typeof(UserEfRepository<>), DependencyLifeStyle.Transient);
            //必须放在前面
            //IocManager.Register(typeof(IRepository<ProductMsg>), typeof(BaseEfRepository<ProductMsg>));
            IocManager.Register(typeof(IOrderRepository), typeof(OrderNHRepository), DependencyLifeStyle.Transient);
            //IocManager.Register<IProductCatagoryRepository, ProductCatagoryRepository>();
           // IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //1
            //'Shop.Application.Services.StudentAppService' is waiting for the following dependencies:
            //- Service 'Shop.Domain.Repositories.IRepository registed

            //2 start  ex

            //3 'Shop.Application.Services.StudentAppService' is waiting for the following dependencies:
            //- Service 'Shop.Domain.Repositories.IRepository   which was not registered.

            //1 2 select 1
            //Castle.MicroKernel.ComponentRegistrationException : Component Shop.Ef.Repositories.BuyerAddressRepository could not be registered. There is already a component with that name. Did you want to modify the existing component instead?
            //If not, make sure you specify a unique name.

            //IocManager.Register(typeof(IRepository<>),typeof(BaseEfRepositoryByHasDeletionTime<>));
            
            Assembly assembly = typeof(ShopCoreModule).Assembly;
            foreach (var item in assembly.Modules)
            {
                foreach (var type in item.GetTypes())
                {
                   // IocManager.Register(typeof(IRepository<>), typeof(BaseRepository<>));
                }
            }



            //2 registed
            //IocManager.Replace(typeof(IRepository<Student>),typeof(StudentRepository));

            // IocManager.Register(typeof(ShopDbContext),new ShopDesignTimeDbContextFactory().CreateDbContext(null));



        }

        private static ISessionFactory sessinFactory = null;
        //初始化
        private static void InitiallizeSessionFactory()
        {
            try
            {
                Configuration configuration = new Configuration();
                configuration = configuration.Configure("hibernate.cfg.xml");

                // 工厂初始化， 链接数据库等 /  此处会爆发各种bug 注意mysql。dll版本 
                //sessinFactory = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(db => db.Server("localhost").Database("Shop").Username("root").Password("wjp930514.")))
                //    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ShopModule>()).BuildSessionFactory();
                //error 过不 去 什么 玩意 难道 下载源码 调试 ?
                //string connStr = "Database=Shop;Data Source=localhost;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
                //sessinFactory = Fluently.Configure().Database(new MySQLConfigurationV1().Raw("dialect", "NHibernate.Dialect.MySQL5Dialect").ConnectionString(connStr).ShowSql()
                //    .FormatSql().Raw("hbm2ddl.auto", "update").Raw("connection.driver_class", "NHibernate.Driver.MySqlDataDriver"))
                //    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                //    .BuildSessionFactory();

                configuration = Fluently.Configure(configuration)
                 .Mappings(m => {
                     m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                     m.FluentMappings.Add(typeof(SoftDeleteFilter));//这个是关键的
                 })
                 .BuildConfiguration();
                //configuration.FilterDefinitions.Clear();
                //foreach (var item in configuration.ClassMappings)
                //{
                //    item.FilterMap.Clear();
                //}
                sessinFactory = configuration.BuildSessionFactory();//pass

                //pass
                var mapper = new ModelMapper();
                //mapper.AddMappings(new Type[] { typeof(OrderMappV1) });
                var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

                configuration.AddMapping(domainMapping);
                sessinFactory = configuration.BuildSessionFactory();

            }
            catch (Exception e)
            {

            }

        }
        // private static ISessionFactory SessionFactory
        // {
        //     get
        //     {
        //         if (sessinFactory == null)
        //             InitiallizeSessionFactory();
        //         return sessinFactory;
        //     }
        // }
        // public static ISession OpenSession()
        // {
        //     return SessionFactory.OpenSession();
        // }



  


     
    }
}