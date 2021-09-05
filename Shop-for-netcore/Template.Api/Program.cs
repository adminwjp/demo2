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
using Utility;
using Utility.Application.Services.Dtos;

namespace Template.Api
{
   
    public class Program
    {
        //git pull origin tag:tags/refs/tag
        //http://kerwenzhang.github.io/git/2020/09/25/Git-Tag-Force-Update/
        // dotnet run --urls="http://*:4005"

        public static void Main(string[] args)
        {
            ConfigHelper.OrmFlag = OrmFlag.Xml;
            Utility.ConfigHelper.DbFlag = Utility.DbFlag.Sqlite;
            Utility.ConfigHelper.ServiceFlag = ServiceFlag.Eureka;
            Start<Startup>("Template.Api", args);
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
