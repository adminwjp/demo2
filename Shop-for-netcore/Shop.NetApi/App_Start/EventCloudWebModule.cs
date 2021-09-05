using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Localization;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.Mvc.Configuration;
using EventCloud.Api;
using EventCloud.Web.Navigation;
using Shop.Api;

namespace EventCloud.Web
{
    [DependsOn(
        typeof(EventCloudDataModule),
        typeof(EventCloudApplicationModule),
        typeof(EventCloudWebApiModule),
        typeof(AbpWebMvcModule)
        )]
    public class EventCloudWebModule : AbpModule
    {
        public virtual bool IsEventCloud { get; set; } = true;
        public static void BasePreInitialize(IAbpStartupConfiguration Configuration)
        {
            Configuration.Modules.AbpMvc().IsAutomaticAntiForgeryValidationEnabled = false;
            Configuration.Modules.AbpWebApi().IsAutomaticAntiForgeryValidationEnabled = false;

            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<EventCloudNavigationProvider>();
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

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
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
