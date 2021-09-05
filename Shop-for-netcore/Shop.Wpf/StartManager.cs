using System.Reflection;
using Utility.Ioc;
using Utility.Mappers;
using Utility.Wpf.Attributes;
using System.Configuration;
using Abp;
using Microsoft.Extensions.DependencyInjection;
using System;
using Castle.Windsor.MsDependencyInjection;

namespace Shop.Wpf
{
    public class StartManager
    {
        public static AbpBootstrapper abpBootstrapper;
        public static IServiceCollection services;
        public static IServiceProvider serviceProvider;
        static StartManager()
        {

        }

        public static void Initial()
        {
            abpBootstrapper = AbpBootstrapper.Create<ShopWpfModule>();
            //Castle.MicroKernel.ComponentNotFoundException : No component for supporting t
            //he service Shop.Application.Services.ClassAppService was found
            abpBootstrapper.Initialize();
            services = new ServiceCollection();
            services.AddSingleton(abpBootstrapper);
            //这一步很 重要 
            serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(abpBootstrapper.IocManager.IocContainer, services);
            //serviceProvider=new DefaultServiceProviderFactory().CreateServiceProvider(services);

        }


    }
}
