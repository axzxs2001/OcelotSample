using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

using Ocelot.Middleware;
using Ocelot.JWTAuthorizePolicy;
using Ocelot.DependencyInjection;

using App.Metrics;
using App.Metrics.Reporting.Interfaces;
using App.Metrics.Extensions.Reporting.InfluxDB;
using App.Metrics.Extensions.Reporting.InfluxDB.Client;
using Microsoft.Extensions.DependencyInjection;
using App.Metrics.Formatters.Json;
using App.Metrics.Filtering;
using App.Metrics.AspNetCore.Reporting;
using System.Threading;
using System.Threading.Tasks;

namespace OcelotGateway
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            builder.SetBasePath(environment.ContentRootPath)
                   .AddJsonFile("appsettings.json", false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                   //添加ocelot配置文件
                   .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
                   .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            #region Metrics监控部分，不用可注释掉
            //var database = "test";
            //var uri = new Uri("http://127.0.0.1:8086");
            //services.AddMetrics(options =>
            //{
            //    options.GlobalTags.Add("app", "sample app");
            //    options.GlobalTags.Add("env", "stage");
            //})
            //   .AddHealthChecks()

            //   .AddReporting(
            //      factory =>
            //      {
            //          factory.AddInfluxDb(
            //    new InfluxDBReporterSettings
            //    {
            //        InfluxDbSettings = new InfluxDBSettings(database, uri),
            //        ReportInterval = TimeSpan.FromSeconds(5)
            //    });
            //      })
            //   .AddMetricsMiddleware(options => options.IgnoredHttpStatusCodes = new[] { 404 });

            #endregion

            var filter = new MetricsFilter().WhereType(MetricType.Timer);
            var metrics = new MetricsBuilder()
                    //AppMetrics.CreateDefaultBuilder()
                   .Report.ToInfluxDb(options =>
                   {
                       options.InfluxDb.BaseUri = new Uri("http://localhost:8086");
                       options.InfluxDb.Database = "newmetricsdb";
                       options.InfluxDb.Consistenency = "consistency";
                       options.InfluxDb.UserName = "root";
                       options.InfluxDb.Password = "root";
                       options.InfluxDb.RetensionPolicy = "rp";
                       options.HttpPolicy.BackoffPeriod = TimeSpan.FromSeconds(30);
                       options.HttpPolicy.FailuresBeforeBackoff = 5;
                       options.HttpPolicy.Timeout = TimeSpan.FromSeconds(10);
                       options.MetricsOutputFormatter = new MetricsJsonOutputFormatter();
                       options.Filter = filter;
                       options.FlushInterval = TimeSpan.FromSeconds(20);
                   })
                //.Report.ToInfluxDb("http://localhost:8086", "newmetricsdb")
                .Build();

            services.AddMetrics(metrics);
            services.AddMetricsTrackingMiddleware();
            services.AddMetricsReportScheduler();
            metrics.ReportRunner.RunAllAsync();



            var audienceConfig = Configuration.GetSection("Audience");
            //注入OcelotJwtBearer
            services.AddOcelotJwtBearer(audienceConfig["Issuer"], audienceConfig["Issuer"], audienceConfig["Secret"], "GSWBearer");

            //注放Ocelot
            services.AddOcelot(Configuration);
        }


        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            #region Metrics监控部分，不用可注释掉
            //app.UseMetrics();
            //app.UseMetricsReporting(lifetime);
            #endregion

            app.UseMetricsAllMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            await app.UseOcelot();
        }
    }
}
