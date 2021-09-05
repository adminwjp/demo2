using System.Configuration;
using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.ZeroCore.NHibernate;

#if NET5_0
using Abp.Zero.EntityFrameworkCore;

#else
using Abp.Zero.EntityFramework;
//using Abp.Zero.NHibernate;
#endif
namespace EventCloud
{
    //Abp.Zero.NHibernate 5.10.1 映射有问题  netstandard
    //AbpZeroCoreEntityFrameworkCoreModule 
    //修复 map 不知道 最新版本 改动 大? 不支持
    [DependsOn(
#if NET5_0
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        //typeof(AbpZeroNHibernateModule),
         typeof(AbpZeroCoreNHibernateModule),//修改后 支持 netstand
#else
         typeof(AbpZeroEntityFrameworkModule),
        // typeof(AbpZeroNHibernateModule),
         typeof(AbpZeroCoreNHibernateModule),
#endif
         typeof(EventCloudCoreModule))]
    public class EventCloudDataModule : AbpModule
    {
        public virtual bool IsEventCloud { get; set; } = true;
        public static void BasePreInitialize(IAbpStartupConfiguration Configuration)
        {
                var connStr = ConfigurationManager.AppSettings["Default"];

                //Configuration.Modules.AbpNHibernate().FluentConfiguration
                //    .Database(MySQLConfiguration.Standard.ConnectionString(connStr).ShowSql().FormatSql().Raw("hbm2ddl.auto", "update"))

                Utility.Nhibernate.NhibernateHelper
                .UseNhibernate(Configuration.Modules.AbpNHibernate().
                FluentConfiguration, Utility.ConfigHelper.DbFlag, connStr)

                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
            
            Configuration.DefaultNameOrConnectionString = "Default";
        }
        public override void PreInitialize()
        {
            if (IsEventCloud)
            {
                BasePreInitialize(Configuration);
            }
        }
        public static void BaseInitialize(IIocManager IocManager)
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
        public override void Initialize()
        {
            if (IsEventCloud)
            {
                BaseInitialize(IocManager);
            }
        }
    }
}
