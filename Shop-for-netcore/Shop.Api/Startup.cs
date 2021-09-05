using System.Net.Mime;
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
using Abp;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.EmbeddedResources;
using Abp.AspNetCore.Mvc.Extensions;
using Abp.AspNetCore.Mvc.Providers;
using Abp.Dependency;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewComponents;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Utility.Json;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.VisualBasic;
using Microsoft.Extensions.Localization;
using Utility.AspNetCore.Localizer;
using Utility.AspNetCore.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace Shop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
           // IServiceProvider serviceProvider=new DefaultServiceProviderFactory().CreateServiceProvider(services);
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;//return versions in a response header
                options.DefaultApiVersion =   new ApiVersion(1, 0);//default version select 
                options.AssumeDefaultVersionWhenUnspecified = true;//if not specifying an api version,show the default version
            });
            services.AddControllers(options =>
                {
                    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
                }
            ).AddControllersAsServices();
            //参考 源码 这有毛线有 如何本地化 只能在 再次aspnet 替换成本地化？
            //Both ErrorMessageResourceType and ErrorMessageResourceName need to be set on this attribute
            //System.ComponentModel.DataAnnotations 只支持 资源文件 不支持自定义文件

            //asp.net core 资源文件 可以自定义

            //Microsoft.AspNetCore.Mvc.Core Microsoft.AspNetCore.Mvc.DataAnnotations
            // Microsoft.AspNetCore.Mvc.ViewFeatures System.ComponentModel.DataAnnotations

            //ValidationAttributeAdapterProvider(Microsoft.AspNetCore.Mvc.DataAnnotations)

            //DataAnnotationsModelValidator -> Validate()
            // Both ErrorMessageResourceType and ErrorMessageResourceName need to be set on this attribute

            //https://www.it1352.com/1572888.html
            //services.AddSingleton<IValidationAttributeAdapterProvider, CustomValidationAttributeAdapterProvider>();
            //模型验证 本地化 怎么异常
            //https://www.it1352.com/1506083.html
            //Microsoft.AspNetCore.Mvc.DataAnnotations Dispaly...(DataAnnotationsMetadataProvider); Required DataAnnotationsModelValidatorProvider
            //asp.net core mvc controller Microsoft.AspNetCore.Mvc.ViewFeatures
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>(it => new JsonStringLocalizerFactory(new string[] { "Resources/ch-zn.json" }));
            services.AddSingleton<IStringLocalizer, JsonStringLocalizer>(it=>new JsonStringLocalizer(new string[] { "Resources/ch-zn.json" }));
            //services.AddLocalization(options => options.ResourcesPath = "Resources");
            // 400 Error: Bad Request ConfigureApiBehaviorOptions 配置就可以了
            //Microsoft.AspNetCore.Mvc.Core
            // DefaultObjectValidator : ObjectModelValidator 默认实现 
            //-> IModelValidator(Microsoft.AspNetCore.Mvc.DataAnnotations)
            //取消模型验证 但api 会出错 400 需要配置 ConfigureApiBehaviorOptions
            //services.AddSingleton<IObjectModelValidator, NullObjectModelValidator>();
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
                options.SerializerSettings.ContractResolver = JsonContractResolver.ObjectResolverJson;
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            }
          )
          .AddXmlSerializerFormatters()
           .ConfigureApiBehaviorOptions(it => { it.SuppressModelStateInvalidFilter = true; })
           //DataAnnotationsModelValidatorProvider -> AddDataAnnotationsLocalization
           .AddDataAnnotationsLocalization(
                    options =>
                    {
                         options.DataAnnotationLocalizerProvider = (type, factory) => 
                         //new JsonStringLocalizer(new string[] { "Resources/ch-zn.json" });
                         factory.Create(typeof(string));
                    });

            services
                .Configure<RequestLocalizationOptions>(
                opts =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("ch-zn"),
                    };

                    opts.DefaultRequestCulture = new RequestCulture("ch-zn");
                    // Formatting numbers, dates, etc.
                    opts.SupportedCultures = supportedCultures;
                    // UI strings that we have localized.
                    opts.SupportedUICultures = supportedCultures;

                    // Optional: add custom provider to support localization 
                    // based on route value
                    //opts.RequestCultureProviders.Insert (0, );

                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop.Api", Version = "v1" });
            });
            /**
                string connectionString = Configuration.GetConnectionString("SqliteConnectionString");
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            Func<DbContextOptionsBuilder, DbContextOptionsBuilder> func = options =>
            {
                // services.AddSingleton<DbContextOptions>(options.Options);
                return options.UseSqlite(connectionString,
                  sqliteOptionsAction: sqlOptions =>
                  {
                      //sqlOptions.MigrationsAssembly(migrationsAssembly);
                      //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                      
                      //abp MySqlRetryingExecutionStrategy' does not support user initiated transactions. 
                      //Use the execution strategy returned by 'DbContext.Database.CreateExecutionStrategy()
                      //sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                  });
            };
            // Add framework services.
            services.AddDbContextPool<Shop.EntityFrameworkCore.ShopDbContext>(options => func(options));
             **/
              //重置 了 没啥用 
            //return  services.AddAbp<ShopModule>(); //Configure Abp and Dependency Injection 扔掉 了很多东西 不然 不知道 怎么改动
            AbpBootstrapper abpBootstrapper = AbpBootstrapper.Create<ShopApiModule>();
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAbp();//Initializes ABP framework.
            //app.UseRequestLocalization();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop.Api v1"));
            }
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
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
