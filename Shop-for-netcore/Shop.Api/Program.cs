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
    //��־ ��� ��ͳһ ע�������� Ĭ�� consol
    //��� �� ���� unbutun php(�汾 ��һ�� ��Щ ��� ���� Ҫ ʹ�� ����� �Լ�ȥ����) python (�߰汾)
    //docker k8s gitlab jenkins ���� �ڴ治���� ֱ�� ʹ�÷�����Ĳ��� Ҫô���� ����
    //��� �� ���� �� �� �� ΢���� ����Ҫ��ɾ�� �ظ�ʵ��û��˼
    // asp.net ���� �鷳 �������鷳 һ�� �� �� ���� �� ��Ҫ ���� ��װ�� ����
    public class Program
    {
        //ע��
        //��ʹ�õ� ���� ��� ��Ҫ�̳�(AbpModule Ƕ�� �̳� ֱ�Ӽ̳�ԭ���� AbpModule)
        //��ȻĬ��ע��̳е�����ģ��
        //�����Զ���̳� ��Ȼִ�ж�� ��ɴ��� 

        //DependsOn ��˳�� ���� ��Ȼ ��Щ ����ִ�в��� Ҫô�ֶ����� �ı�abp ��������
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
