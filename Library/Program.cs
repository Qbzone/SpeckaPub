using System.IO;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Rollbar;

namespace Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RollbarLocator.RollbarInstance.Configure(new RollbarConfig("892f218a045a4a0e9557c4e8c1ba2252"));
            RollbarLocator.RollbarInstance.Info("Rollbar is configured properly.");
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));

                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddUserSecrets(appAssembly, optional: true)
                        .AddEnvironmentVariables();
                })
                .UseStartup<Startup>();
    }
}
