namespace Shop.Api
{
    using Abp.Modules;
    using System.Reflection;
    using Abp.WebApi;
    using Abp.Application.Services;
    using Shop.Application.Services;
    using Abp.Configuration.Startup;
    using System.Web.Http;
    using Abp.Web.Mvc;
    using EventCloud.Web;
    using EventCloud.Api;
   
    //[DependsOn(typeof(AbpWebApiModule),typeof(ShopApplicationModule))]
    [DependsOn(
        typeof(ShopDataModule),

        typeof(ShopApplicationModule),
      

        typeof(EventCloudWebApiModule),

         // typeof(AbpWebApiModule),

        typeof(AbpWebMvcModule)

        )]
    public class ShopApiModule: AbpModule
    {
        //public override void PostInitialize()
        //{
        //    base.PostInitialize();
        //}
        public override void PreInitialize()
        {
            EventCloudWebModule.BasePreInitialize(Configuration);
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(EmailNotifyProductAppService).Assembly, "app")
                .Build();
            //IAuthenticationFilter
            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));

        }
        public override void Initialize()
        {
            EventCloudWebModule.BaseInitialize(IocManager);
        }
    }
}