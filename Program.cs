using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace foodb
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
                    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                    {
                        webBuilder.UseStartup<Startup>();
                    }
                    else
                    {
                        // Let heroku do it's magic
                        var port = Environment.GetEnvironmentVariable("PORT");

                        webBuilder.UseStartup<Startup>()
                        .UseUrls("http://*:" + port);
                    }
                });
    }
}
