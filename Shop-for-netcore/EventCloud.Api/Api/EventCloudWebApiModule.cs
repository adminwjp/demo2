using System.Reflection;
#if NET5_0
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
#else
using System.Web.Http;
using System.Web.Http.Filters;
using Abp.WebApi;
#endif
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;


namespace EventCloud.Api
{
    [DependsOn(
#if NET5_0
        typeof(AbpAspNetCoreModule)
#else
        typeof(AbpWebApiModule)
#endif
        //typeof(EventCloudApplicationModule)
        ,typeof(Shop.ShopApplicationModule)
        )]
    public class EventCloudWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
#if NET5_0
            Configuration.Modules.AbpAspNetCore().DefaultResponseCacheAttributeForAppServices = new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None };

            Configuration.IocManager.Resolve<IAbpAspNetCoreConfiguration>().EndpointConfiguration.Add(endpoints =>
            {
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
#else
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(EventCloudApplicationModule).Assembly, "app")
                .Build();
            //IAuthenticationFilter
            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
#endif
        }
    }
}
