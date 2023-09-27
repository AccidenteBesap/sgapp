using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Velzon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Call the ConfigureLogging method to set up Serilog
            ConfigureLogging();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void ConfigureLogging()
        {
            // Create a logger configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // Include all log levels
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
