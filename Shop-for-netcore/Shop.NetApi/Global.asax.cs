using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;
using EventCloud.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Shop.Api
{
    public class WebApiApplication : AbpWebApplication<ShopApiModule>//System.Web.HttpApplication
    {
        static WebApiApplication(){
                 Utility.ConfigHelper.OrmFlag = Utility.OrmFlag.Map;
                 Utility.ConfigHelper.DbFlag = Utility.DbFlag.MySql;
            }
        protected override void Application_Start(object sender, EventArgs e)
        {
            //System.Data.SQLite.EF6.SQLiteProviderServices
            //System.Data.Entity.SqlServer.SqlProviderServices
            //System.Data.SQLite.EF6.SQLiteProviderFactory
            //new DbContext("");
            //AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }
    }
    public class WebApiApplication1 : AbpWebApplication<ShopApiModule>//System.Web.HttpApplication
    {
        static WebApiApplication1()
        {
            Utility.ConfigHelper.OrmFlag = Utility.OrmFlag.Map;
            Utility.ConfigHelper.DbFlag = Utility.DbFlag.Sqlite;
        }
        protected override void Application_Start(object sender, EventArgs e)
        {
            //AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            // IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }
        protected void Application_Start1()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
