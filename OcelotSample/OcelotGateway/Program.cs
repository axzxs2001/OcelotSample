using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using App.Metrics.AspNetCore;

namespace OcelotGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "OcelotGateway";
            IWebHostBuilder builder = new WebHostBuilder();
            builder.ConfigureServices(service =>
            {
                service.AddSingleton(builder);
            });
            builder.UseKestrel()
                   .UseContentRoot(Directory.GetCurrentDirectory())
                   .UseIISIntegration()
                   .UseUrls("http://*:5000")
                   .UseStartup<Startup>()
                   .UseApplicationInsights();
            var host = builder.Build();
            host.Run();
        }

    }
}
