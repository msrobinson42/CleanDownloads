using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/* Clean Downloads
 * 12/7/2020
 * Windows service that moves files from
 * a given directory to the recyling bin
 * after a given expiration date.
 * 
 * Zach Robinson
 */

namespace CleanDownloads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IConfiguration>(config);

                    services.AddTransient<FileExpiration>();
                    services.AddTransient<FileRecycler>();

                    services.AddHostedService<Worker>();
                });
        }
    }
}
