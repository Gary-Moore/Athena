using System;
using Athena.Core.Logging;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Web.App
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var logDetail = new LogDetail()
            {
                Product = "Athena",
                ApplicationName = "Web Application"
            };

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .ConfigureBaseLogging(logDetail)
            .CreateBootstrapLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((context, services, loggerConfiguration) =>
            {
                var logDetail = new LogDetail()
                {
                    Product = "Athena",
                    ApplicationName = "Web Application"
                };
                loggerConfiguration.ConfigureBaseLogging(logDetail);
                loggerConfiguration.WriteTo.ApplicationInsights(services.GetRequiredService<TelemetryConfiguration>(), TelemetryConverter.Traces);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
