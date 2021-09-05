using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;


using Microsoft.AspNetCore.Http;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.Mvc.Extensions;
using Newtonsoft.Json;
using Utility.Json;
using Abp;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Abp.Dependency;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Abp.AspNetCore.Mvc.Providers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Abp.AspNetCore.EmbeddedResources;
using Utility.Generator;
using Template.Api.Helpers;
using Abp.NHibernate;
using Utility.AspNetCore.Extensions;
using Utility.Consul;

namespace Template.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //initMap();
        }
        void initMap(){
            CsharepGeneratorHelper.NameSpace="Template.Api.EntityMappings";
            CsharepGeneratorHelper.ParseEntity(GetType().Assembly,new List<string>(){"Template.Api.Models"});
            CsharepGeneratorHelper.AbpNhibernateMap.EntityToMap();
            //CsharepGeneratorHelper.AbpNhibernateMap.EntityToMapStringCode("D:/shop/Shop-for-netcore/Template.Api/EntityMappings");
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
       public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<ConsulEntity>(Configuration.GetSection("Service"));

            services.AddRegisterService(Configuration,Utility.ConfigHelper.ServiceFlag);
            //IServiceProvider serviceProvider=new DefaultServiceProviderFactory().CreateServiceProvider(services);
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;//return versions in a response header
                options.DefaultApiVersion =   new ApiVersion(1, 0);//default version select 
                options.AssumeDefaultVersionWhenUnspecified = true;//if not specifying an api version,show the default version
            });  
             services.AddControllers().AddControllersAsServices();
              services.AddMvc(options =>
            {
                // options.ModelBinderProviders.Insert(0, new CustomModelBinderProvider());
                //options.InputFormatters.Insert(0, new XDocumentInputFormatter());
               
            })
            //全局配置Json序列化处理 方案1
            .AddNewtonsoftJson(options =>
            {
                // options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //使用 AbC ab_c
                options.SerializerSettings.ContractResolver =  JsonContractResolver.ObjectResolverJson;
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            }
          )
          .AddXmlSerializerFormatters();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Template.Api", Version = "v1" });
            });
              //重置 了 没啥用 
            //return  services.AddAbp<ShopModule>(); //Configure Abp and Dependency Injection 扔掉 了很多东西 不然 不知道 怎么改动
            AbpBootstrapper abpBootstrapper = AbpBootstrapper.Create<TemplateApiModule>();
            services.AddSingleton(abpBootstrapper);
            ConfigureAspNetCore(services, abpBootstrapper.IocManager);
            return WindsorRegistrationHelper.CreateServiceProvider(abpBootstrapper.IocManager.IocContainer, services);
        }

        private static void ConfigureAspNetCore(IServiceCollection services, IIocResolver iocResolver)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            services.Replace(ServiceDescriptor.Singleton<IPageModelActivatorProvider, ServiceBasedPageModelActivatorProvider>());
            services.Replace(ServiceDescriptor.Singleton<IViewComponentActivator, ServiceBasedViewComponentActivator>());
            services.GetSingletonServiceOrNull<ApplicationPartManager>()?.FeatureProviders.Add(new AbpAppServiceControllerFeatureProvider(iocResolver));

            services.Configure((Action<MvcOptions>)delegate (MvcOptions mvcOptions)
            {
                //mvcOptions.AddAbp(services); 只能反射 internal
            });
            services.Insert(0, ServiceDescriptor.Singleton((IConfigureOptions<MvcRazorRuntimeCompilationOptions>)new ConfigureOptions<MvcRazorRuntimeCompilationOptions>((Action<MvcRazorRuntimeCompilationOptions>)delegate (MvcRazorRuntimeCompilationOptions options)
            {
                options.FileProviders.Add(new EmbeddedResourceViewFileProvider(iocResolver));
            })));
            services.AddHttpClient("WebhookSenderHttpClient");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, Microsoft.Extensions.Hosting.IApplicationLifetime lifetime)
        {  
            app.UseAbp();//Initializes ABP framework.
            TemplateHelper.InitData(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template.Api v1"));
            }

            //app.UsePathBase();
            //方案1  IServiceCollection 不需要配置
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                //options.AllowCredentials();
            });
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
             app.UseApiVersioning();
            app.UseForwardedHeaders();
            Utility.AspNetCore.StartSimpleHelper.ApplicationStarted = lifetime.ApplicationStarted;
            Utility.AspNetCore.StartSimpleHelper.ApplicationStopped = lifetime.ApplicationStopped;
            Utility.AspNetCore.StartSimpleHelper.ApplicationStopping = lifetime.ApplicationStopping;

            Utility.AspNetCore.Extensions.RegisterServiceExtensions.UseService(app, Configuration, Utility.ConfigHelper.ServiceFlag);
            //Utility.AspNetCore.Extensions.ZipkinExtensions.UseZipkin(app, loggerFactory, Configuration);
            app.UseEndpoints(endpoints =>
            {
                //iis 不支持 
                endpoints.MapAreaControllerRoute(
                  name: "area",
                  areaName: "areas",
                  pattern: "{area:exists}/{controller}/{action}/{id?}"
                );
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller}/{action}/{id?}"
                );
                endpoints.MapControllers();
                app.ApplicationServices.GetRequiredService<IAbpAspNetCoreConfiguration>()
                                     .EndpointConfiguration
                                     .ConfigureAllEndpoints(endpoints);
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
