using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Fivet.ZeroIce.model;
using Fivet.ZeroIce;
using Fivet.Dao;

namespace Fivet.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        
        /// <summary>
        /// Build and configure Host
        /// </summary>
        /// <param name="args"> Arguments to be passed</param> 
        /// <returns> IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args){

            return Host
            .CreateDefaultBuilder(args)
            .UseEnvironment("Development")
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole(options =>
                {
                    options.IncludeScopes = true;
                    options.TimestampFormat = "[yyyy-MM-dd HH:mm:ss.fff] ";
                    options.DisableColors = false;
                });
                logging.SetMinimumLevel(LogLevel.Trace);
            })
            .UseConsoleLifetime()
            .ConfigureServices((hostContext, services)=>
            {
                // Sistema
                services.AddSingleton<SistemaDisp_, SistemaImpl>();
                // Contratos
                services.AddSingleton<ContratosDisp_, ContratosImpl>();
                // DB Service
                services.AddDbContext<FivetContext>(); 
                // FivetService
                services.AddHostedService<FivetService>();
                // Logging Service
                services.AddLogging();
                // Add 15s wait
                services.Configure<HostOptions>(option =>
                {
                    option.ShutdownTimeout = System.TimeSpan.FromSeconds(15);
                });
            });
        }
    }
}
