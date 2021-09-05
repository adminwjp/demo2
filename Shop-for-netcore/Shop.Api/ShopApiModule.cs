namespace Shop.Api
{
    using Abp.Modules;
    using System.Reflection;
    using Abp.AspNetCore;
    using Abp.AspNetCore.Configuration;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;

    [DependsOn(typeof(AbpAspNetCoreModule),typeof(ShopApplicationModule))]
    public class ShopApiModule: AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAspNetCore().DefaultResponseCacheAttributeForAppServices = new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None };

            Configuration.IocManager.Resolve<IAbpAspNetCoreConfiguration>().EndpointConfiguration.Add(endpoints =>
            {
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
        public override void PostInitialize()
        {
            base.PostInitialize();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(ShopApplicationModule).Assembly, "app");
        }
    }
}