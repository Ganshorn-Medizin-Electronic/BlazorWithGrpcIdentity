using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace BlazorClientApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Listen(IPAddress.Any, 4000);
                        serverOptions.Listen(IPAddress.Any, 4001,
                            listenOptions =>
                            {
                                listenOptions.UseHttps();
                            });
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
