using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AuthenticationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "AuthenticationAPI";
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   var env = hostingContext.HostingEnvironment;
                   config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                   config.AddEnvironmentVariables();
               })
            .UseUrls("http://*:5003")
                .UseStartup<Startup>()
                .Build();
    }
}
