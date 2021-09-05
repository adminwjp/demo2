using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.NHibernate;
using Abp.Zero;



namespace Abp.ZeroCore.NHibernate
{
    /// <summary>
    /// Startup class for ABP ZeroCore NHibernate module.
    /// </summary>
    [DependsOn(
        typeof(AbpZeroCoreModule),

        typeof(AbpNHibernateModule))]
    public class AbpZeroCoreNHibernateModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpNHibernate().FluentConfiguration
               //ex test mysql
                 .Mappings(
                    m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                ) ;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
