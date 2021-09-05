
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
    //aop ���õ���
    //���� ��ͻ Ӧ�� ���� ʹ�� dapper ef nh
    //���� �������û�� ��� ֻ��Դ����� �鷳(����ͳһԴ��)
    //ide(������ô��� ��Ҫ ����(Ҫô���¼���)) ���� dll(��Ҫ��װ��Ӧ�汾���������� ������ ����Դ��)
    //���� ʧ�� �Ҳ��� ������� λ��(ms build vs ide ���� donet ) �ٴ� ���� �Ϳ�����
    //2(AbpZeroCore ��ʹ�� ���� ���ʹ�� ����ջ ) ѡһ  ��Ȼ ex 
    //orm dapper  ef nhibernate 
    //ef efcore ef annotation ef mapp nh annotation nh mapp  nh xml
    //ef sqlite CreateDatabase is not supported by the provider.
    //System.Data.SQLite.EF6.SQLiteProviderServices(�ο� sqlserver ʵ��ԭ��) ���� û�������
    //�ѵ� ��Ҫ�Զ��� ʵ��? ԭ�� ado.net ֧�� ��װ�� ����֧�� �� �� ˭���� ��ͳһ
    //�ҹ��� ��    ���� ��� ���� ����  ���� ��ϰ
    //��������ӿڲ�Ȼ��֪�� ���ĸ�  dapper  ef nhibernate ֻ ʵ�� һ�� 
    // ���� ���Ӷȱ����  ���� ά��
    //net ef ���õ��� �� ���� ��������Ҫ �����ļ� Ҳ�� �� Ĭ�� sqlserver (�Լҵĺõ� ��������������)
    //��ʱ ���� ef() nhibernate ������ net �� ӳ����
    //���� ��ʱ �� Դ�� ���� �������� �õ��� ������ȥ �鷳
    //���� ë�� ��ʱ�� �첽 ˳���޷���֤
    //AbpBackgroundJobs ��� ��ʱ�� һֱ ����
    //sqlite
    //database is locked database is locked
    //mysql
    //An invalid or incomplete configuration was used while creating a SessionFactory. Check PotentialReasons collection, and InnerException for more detail.
    //���� ֮ǰ�������� ���� �� ����?
    //��� ��Ҫ ʹ���ڲ���װ �õ�Ӧ�� demo(���ڲ�����) һ�� ���� ��
    //Ҳ ���޸���(ÿ�� �汾 ���� ���� ��һ�� ���� �޸�)
    //ʲô ��� �� �� ������ ��� Ϊnull(�޷��������ݿ�?)

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
         //������ map ���ë�� ÿ�� �汾 ���� �� ��������?
         //typeof(AbpZeroNHibernateModule),//�޸ĺ� map ֧�� ��Ȼ map ������ �޷�ʹ�ò�֪���޸�û��
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
            //8.0.26 ������ ��� �� ���� ��Ҫ ���� ��ô����ʾ (8.0.23)
            //show variables like '%ssl%';
            var conn =new MySql.Data.MySqlClient.MySqlConnection(Configuration.DefaultNameOrConnectionString);
            conn.Open();
            //TestMySqlEx(Configuration.DefaultNameOrConnectionString);
#if NET48
            //�ֶ�ע�� 
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
                          m.FluentMappings.Add(typeof(SoftDeleteFilter));//����ǹؼ���
                          m.FluentMappings.Add(typeof(MayHaveTenantFilter));//����ǹؼ���
                          m.FluentMappings.Add(typeof(MustHaveTenantFilter));//����ǹؼ���
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
            //AbpBootstrapper ����ģ�� AbpModuleManager ģ�� ���� �� 
            //core Ҳ ֧�� ConfigurationManager (֧�� netstandard)? 
            //NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
            //configuration = configuration.Configure("hibernate.cfg.xml");
            //hbm ���Ϲ���(��ѯ)֧�� �� map  FluentNHibernate �쳣
            var connStr = string.Empty;
            Configuration configuration = null;
            if (Utility.ConfigHelper.OrmFlag == Utility.OrmFlag.None)
            {
                configuration = (Configuration)Configuration.Modules.AbpNHibernate().FluentConfiguration.GetType().GetProperty("Configuration",
    BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Configuration.Modules.AbpNHibernate().FluentConfiguration);
                //configuration = configuration.Configure("hibernate.cfg.xml");
                connStr = System.Configuration.ConfigurationManager.AppSettings["Default"]; // web.config ��ȡ���� 
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
                export.SetOutputFile(Path.Combine(Directory.GetCurrentDirectory(), "sql/" + Utility.ConfigHelper.DbFlag.ToString() + "/sql.sql")); //�������Ŀ¼
                                                                                                                                                   // export.Drop(true, true);//�������ɱ�ṹ�������ж�,��ɾ��
                export.Create(false, false);//�����Ƿ����ɽű�,�Ƿ񵼳���
            }
        }
        public override void Initialize()
        {
            //���� �� ��ͬ�ķ��� ��Ȼ ��֪�� ���ĸ� ������ 
            //dapper nhibernate ef 
            //IocManager.Register(typeof(IRepository<>), typeof(BaseEfRepositoryByHasDeletionTime<>));
            IocManager.Register(typeof(IUserRepository<>), typeof(UserEfRepository<>), DependencyLifeStyle.Transient);
            //�������ǰ��
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
        //��ʼ��
        private static void InitiallizeSessionFactory()
        {
            try
            {
                Configuration configuration = new Configuration();
                configuration = configuration.Configure("hibernate.cfg.xml");

                // ������ʼ���� �������ݿ�� /  �˴��ᱬ������bug ע��mysql��dll�汾 
                //sessinFactory = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(db => db.Server("localhost").Database("Shop").Username("root").Password("wjp930514.")))
                //    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ShopModule>()).BuildSessionFactory();
                //error ���� ȥ ʲô ���� �ѵ� ����Դ�� ���� ?
                //string connStr = "Database=Shop;Data Source=localhost;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
                //sessinFactory = Fluently.Configure().Database(new MySQLConfigurationV1().Raw("dialect", "NHibernate.Dialect.MySQL5Dialect").ConnectionString(connStr).ShowSql()
                //    .FormatSql().Raw("hbm2ddl.auto", "update").Raw("connection.driver_class", "NHibernate.Driver.MySqlDataDriver"))
                //    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                //    .BuildSessionFactory();

                configuration = Fluently.Configure(configuration)
                 .Mappings(m => {
                     m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                     m.FluentMappings.Add(typeof(SoftDeleteFilter));//����ǹؼ���
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