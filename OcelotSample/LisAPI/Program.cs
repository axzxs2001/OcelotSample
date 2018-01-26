using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LisAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            foreach (var s in args)
            {
                Console.WriteLine("args参数:"+s);
            }
            Console.Title = "ListAPI";
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .UseUrls("http://*:5002")
                .UseStartup<Startup>()
                .Build();
    }
}
