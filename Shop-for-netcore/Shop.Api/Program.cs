using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Api
{
    //日志 组件 不统一 注册服务组件 默认 consol
    //最好 用 宝塔 unbutun php(版本 不一致 有些 组件 必须 要 使用 低组件 自己去控制) python (高版本)
    //docker k8s gitlab jenkins 。。 内存不够吃 直接 使用发布后的部署 要么单机 部署
    //如果 找 工作 话 拆 成 微服务 不需要的删除 重复实现没意思
    // asp.net 引用 麻烦 升个级麻烦 一旦 用 到 其它 库 还要 重新 安装或 引用
    public class Program
    {
        //注意
        //不使用的 东西 最好 不要继承(AbpModule 嵌套 继承 直接继承原生的 AbpModule)
        //不然默认注入继承的所有模块
        //不能自定义继承 不然执行多次 造成错误 

        //DependsOn 按顺序 加载 不然 有些 东西执行不了 要么手动调用 改变abp 调用流程
        /**
         * [DependsOn]
         class a:AbpModule{ override a1(){}}
         class b:a{override a1(){}}
         class c:a{}
         */
        //dotnet run --urls="http://*:4006"
        //dotnet ef migrations add a7   -c ShopDbContext -o Migrations/Shop
        //dotnet ef database update a7  -c ShopDbContext
        public static void Main(string[] args)
        {
            Utility.ConfigHelper.OrmFlag = Utility.OrmFlag.Map;
            Utility.ConfigHelper.DbFlag = Utility.DbFlag.Sqlite;
            Start<Startup>("Shop.Api", args);
           // CreateHostBuilder(args).Build().Run();
        }

        public static void Start<T>(string title, string[] args) where T : class
        {
            Console.Title = title;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrEmpty(environment))
            {
                environment = "Development";
            }
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File(Path.Combine("logs", @"log.txt"), rollingInterval: RollingInterval.Hour)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate)
                .ReadFrom.Configuration(config)
                .CreateLogger();
            CreateWebHostBuilder<T>(config, args).Run();
        }

        public static IWebHost CreateWebHostBuilder<T>(IConfiguration configuration, string[] args) where T : class =>
           WebHost.CreateDefaultBuilder(args)
             .CaptureStartupErrors(false)
            .UseDefaultServiceProvider(options => { options.ValidateScopes = false; })
             .UseStartup<T>()
             // .UseApplicationInsights()
             .UseContentRoot(Directory.GetCurrentDirectory())
             .UseConfiguration(configuration)
             .UseSerilog()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            })
             //.UseUrls(configuration["applicationUrl"].Split(new char[] { ';' }))
             .Build();
  
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}
