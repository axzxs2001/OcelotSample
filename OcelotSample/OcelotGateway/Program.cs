using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OcelotGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "OcelotGateway";
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args)
        {
            IWebHostBuilder builder = new WebHostBuilder();
            //注入WebHostBuilder
            return builder.ConfigureServices(service =>
            {
                service.AddSingleton(builder);
            })
                //加载configuration配置文人年
                .ConfigureAppConfiguration(conbuilder =>
                {
                    conbuilder.AddJsonFile("appsettings.json");
                    conbuilder.AddJsonFile("configuration.json");
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()          
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .Build();
        }

    }
}
