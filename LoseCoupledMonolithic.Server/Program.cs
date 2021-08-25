using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;

namespace LoseCoupledMonolithic.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var levelSwitch = new LoggingLevelSwitch();

            Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.ControlledBy(levelSwitch)
                   .MinimumLevel.Override("Microsoft", levelSwitch)
                   .MinimumLevel.Override("Microsoft.AspNetCore", levelSwitch)
                   .MinimumLevel.Override("Microsoft.Hosting.Lifetime", levelSwitch)
                   .Enrich.FromLogContext()
                   .WriteTo.Console()
                   .WriteTo.Seq("http://localhost:6500", apiKey: "3pTn0IyAiEEFtPkdWmTF", controlLevelSwitch: levelSwitch)
                   .CreateLogger();

            CreateHostBuilder(args).Build().Run();
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
