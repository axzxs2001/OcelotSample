using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.APM.ApplicationProfiler;
using AspectCore.APM.AspNetCore;
using AspectCore.APM.HttpProfiler;
using AspectCore.APM.LineProtocolCollector;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspectCore_APMDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAspectCoreAPM(component =>
            {
                component.AddApplicationProfiler(); //注册ApplicationProfiler收集GC和ThreadPool数据
                component.AddHttpProfiler();        //注册HttpProfiler收集Http请求数据
                component.AddLineProtocolCollector(options => //注册LineProtocolCollector将数据发送到InfluxDb
                {
                    options.Server = "http://localhost:8086"; //你自己的InfluxDB Http地址
                    options.Database = "aspectcore";    //你自己创建的Database
                });
            });
            services.BuildAspectCoreServiceProvider(); //返回AspectCore AOP的ServiceProvider,这句代码一定要有
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
      
            app.UseHttpProfiler();      //启动Http请求监控
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
