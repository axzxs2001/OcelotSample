using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ocelot.Middleware;
using Ocelot.JWTAuthorizePolicy;
using Ocelot.DependencyInjection;
using App.Metrics;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.ConfigEditor;

using App.Metrics.Health;
using System.Reflection;


namespace OcelotGateway
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

            #region Metrics监控配置
            string IsOpen = Configuration.GetSection("InfluxDB:IsOpen").Value.ToLower();
            if (IsOpen == "true")
            {
                string database = Configuration.GetSection("InfluxDB")["DataBaseName"];
                string InfluxDBConStr = Configuration.GetSection("InfluxDB")["ConnectionString"];
                string app = Configuration.GetSection("InfluxDB")["app"];
                string env = Configuration.GetSection("InfluxDB")["env"];
                string username = Configuration.GetSection("InfluxDB")["username"];
                string password = Configuration.GetSection("InfluxDB")["password"];
                var uri = new Uri(InfluxDBConStr);

                var metrics = AppMetrics.CreateDefaultBuilder()
                .Configuration.Configure(
                options =>
                {
                    options.AddAppTag(app);
                    options.AddEnvTag(env);
                })
                .Report.ToInfluxDb(
                options =>
                {
                    options.InfluxDb.BaseUri = uri;
                    options.InfluxDb.Database = database;
                    options.InfluxDb.UserName = username;
                    options.InfluxDb.Password = password;
                    options.HttpPolicy.BackoffPeriod = TimeSpan.FromSeconds(30);
                    options.HttpPolicy.FailuresBeforeBackoff = 5;
                    options.HttpPolicy.Timeout = TimeSpan.FromSeconds(10);
                    options.FlushInterval = TimeSpan.FromSeconds(5);
                })
                .Build();

                services.AddMetrics(metrics);
                services.AddMetricsReportScheduler();
                services.AddMetricsTrackingMiddleware();
                services.AddMetricsEndpoints();

                //健康监控相关
                //var healthmetrics = AppMetricsHealth.CreateDefaultBuilder()
                //    .HealthChecks.AddProcessPhysicalMemoryCheck("process", (2048L * 1024L) * 1024L)
                //    .HealthChecks.AddPingCheck("ping", "baidu.com", TimeSpan.FromSeconds(5))
                //    .Build();
                //services.AddHealth(healthmetrics);
                //services.AddHealthEndpoints();
            }

            #endregion

            var audienceConfig = Configuration.GetSection("Audience");
            //注入OcelotJwtBearer
            services.AddOcelotJwtBearer(audienceConfig["Issuer"], audienceConfig["Issuer"], audienceConfig["Secret"], "GSWBearer");

            //注入Ocelot
            services.AddOcelot(Configuration as ConfigurationRoot);//.AddStoreOcelotConfigurationInConsul();
            services.AddOcelotConfigEditor();
        }


        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            #region 使用中间件Metrics
            string IsOpen = Configuration.GetSection("InfluxDB")["IsOpen"].ToLower();
            if (IsOpen == "true")
            {
                app.UseMetricsAllMiddleware();
                app.UseMetricsAllEndpoints();

                //健康监控相关
                //app.UseHealthAllEndpoints();
                //app.UsePingEndpoint();
                //app.UseHealthEndpoint();        
            }
            #endregion
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOcelotConfigEditor(new ConfigEditorOptions { Paths = new string[] { "edit", "create" } });
            await app.UseOcelot();
        }
    }
}
