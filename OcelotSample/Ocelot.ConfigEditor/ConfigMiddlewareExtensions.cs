using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Ocelot.ConfigEditor
{
    public static class ConfigMiddlewareExtensions
    {
        public static IServiceCollection AddOcelotConfigEditor(this IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<RazorViewEngineOptions>(
                opt => { opt.ViewLocationExpanders.Add(new ViewLocationMapper()); });

            services.AddScoped<IReloadService, ReloadService>();

            return services;
        }

        public static IApplicationBuilder UseOcelotConfigEditor(
            this IApplicationBuilder app,
            ConfigEditorOptions configEditorOptions = null)
        {
            var services = app.ApplicationServices;
            var reload = services.GetService<IReloadService>();
            reload.RemoveReloadFlag();
            if (configEditorOptions == null || configEditorOptions.Paths == null || configEditorOptions.Paths.Length != 2)
            {
                throw new System.Exception("路径数组必需有两个值，每一个为手动录入配置，第一个为自动配置");
            }

            app.UseMvc(
                routes =>
                    {
                        routes.MapRoute(
                            "ConfigEditor",
                            $"{configEditorOptions.Paths[0]}/{{controller=Editor}}/{{action=Index}}/{{id?}}",
                            null,
                            new { IsLocal = new LocalhostRouteConstraint() },
                            new { Namespace = "Ocelot.ConfigEditor.Editor.Controllers" });

                        routes.MapRoute(
                         "ConfigCreate",
                         $"{configEditorOptions.Paths[1]}/{{controller=Editor}}/{{action=AutoCreate}}/{{id?}}",
                         null,
                         new { IsLocal = new LocalhostRouteConstraint() },
                         new { Namespace = "Ocelot.ConfigEditor.Editor.Controllers" });

                        //                routes.MapRoute(
                        //"ConfigCreateAction",
                        //$"{"getserver"}/{{controller=Editor}}/{{action=GetActionByServer}}/{{id?}}",
                        //null,
                        //new { IsLocal = new LocalhostRouteConstraint() },
                        //new { Namespace = "Ocelot.ConfigEditor.Editor.Controllers" });
                    });

            return app;
        }
    }
}
