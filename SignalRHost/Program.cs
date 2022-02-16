using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace SignalRHost
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var logsDir = @"C:\nativekit\NativeApp\logs";
                var filePath = Path.Combine(logsDir, "log.txt");

                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File(filePath, rollingInterval: RollingInterval.Day
                        , outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Message:lj}{NewLine}{Exception}")
                    .CreateLogger();

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Error(e.StackTrace);
                throw;
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
             .UseSerilog()
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
             });
    }
}
