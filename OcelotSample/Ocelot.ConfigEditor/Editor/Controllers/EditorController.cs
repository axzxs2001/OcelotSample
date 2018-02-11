using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

using Ocelot.ConfigEditor.Editor.Models;
using Ocelot.Configuration;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Provider;
using Ocelot.Configuration.Repository;
using Ocelot.Configuration.Setter;

namespace Ocelot.ConfigEditor.Editor.Controllers
{
    public class EditorController : Controller
    {
        private readonly IFileConfigurationRepository _fileConfigRepo;

        private readonly IReloadService _reload;

        public EditorController(IFileConfigurationRepository fileConfigurationRepository, IReloadService reload)
        {
            _fileConfigRepo = fileConfigurationRepository;
            _reload = reload;
        }

        [NamespaceConstraint]
        public FileStreamResult ContentFile(string id)
        {
            var assembly = typeof(EditorController).GetTypeInfo().Assembly;
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(f => f.EndsWith(id));
            var resource = assembly.GetManifestResourceStream(resourceName);
            return new FileStreamResult(resource, GetMimeType(id));
        }

        [NamespaceConstraint]
        public IActionResult CreateReRoute()
        {
            var viewModel = new FileReRouteViewModel { FileReRoute = new FileReRoute() };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [NamespaceConstraint]
        public IActionResult CreateReRoute(string id, FileReRouteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var validator = new FileReRouteValidator();
            var results = validator.Validate(model.FileReRoute);

            if (!results.IsValid)
            {
                results.Errors.ToList().ForEach(e => ModelState.AddModelError($"FileReRoute.{e.PropertyName}", e.ErrorMessage));
                return View(model);
            }

            var routes = _fileConfigRepo.Get().GetAwaiter().GetResult();
            routes.Data.ReRoutes.Add(model.FileReRoute);
            _fileConfigRepo.Set(routes.Data);

            _reload.AddReloadFlag();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [NamespaceConstraint]
        public IActionResult DeleteReRoute(string id)
        {
            var routes = _fileConfigRepo.Get().GetAwaiter().GetResult();
            var route = routes.Data.ReRoutes.FirstOrDefault(r => id == r.GetId());

            if (route == null) return RedirectToAction("Index");

            routes.Data.ReRoutes.Remove(route);
            _fileConfigRepo.Set(routes.Data);

            _reload.AddReloadFlag();

            return RedirectToAction("Index");
        }

        [NamespaceConstraint]
        public IActionResult EditReRoute(string id)
        {
            var routes = _fileConfigRepo.Get().GetAwaiter().GetResult();
            var route = routes.Data.ReRoutes.FirstOrDefault(r => id == r.GetId());

            if (route == null) return RedirectToAction("CreateReRoute");

            return View(new FileReRouteViewModel { FileReRoute = route });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [NamespaceConstraint]
        public IActionResult EditReRoute(string id, FileReRouteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var validator = new FileReRouteValidator();
            var results = validator.Validate(model.FileReRoute);

            if (!results.IsValid)
            {
                results.Errors.ToList().ForEach(e => ModelState.AddModelError($"FileReRoute.{e.PropertyName}", e.ErrorMessage));
                return View(model);
            }

            var routes = _fileConfigRepo.Get().GetAwaiter().GetResult();
            var route = routes.Data.ReRoutes.FirstOrDefault(r => id == r.GetId());

            if (route != null) routes.Data.ReRoutes.Remove(route);

            routes.Data.ReRoutes.Add(model.FileReRoute);
            _fileConfigRepo.Set(routes.Data);

            _reload.AddReloadFlag();

            return RedirectToAction("Index");
        }

        [NamespaceConstraint]
        public IActionResult Index()
        {
            var repo = _fileConfigRepo.Get().GetAwaiter().GetResult();
            return View(repo.Data);
        }

        [HttpPost]
        [NamespaceConstraint]
        public IActionResult Reload()
        {
            _reload.ReloadConfig();

            return RedirectToAction("Index");
        }

        private static string GetMimeType(string fileId)
        {
            if (fileId.EndsWith(".js")) return "text/javascript";

            if (fileId.EndsWith(".css")) return "text/css";

            if (fileId.EndsWith(".eot")) return "application/vnd.ms-fontobject";

            if (fileId.EndsWith(".ttf")) return "application/font-sfnt";

            if (fileId.EndsWith(".svg")) return "image/svg+xml";

            if (fileId.EndsWith(".woff")) return "application/font-woff";

            if (fileId.EndsWith(".woff2")) return "application/font-woff2";

            return fileId.EndsWith(".jpg") ? "image/jpeg" : "text";
        }



        [NamespaceConstraint]
        public IActionResult AutoCreate()
        {
            return View();
        }

        //[NamespaceConstraint]
        /// <summary>
        /// 获取项目中的路由
        /// </summary>
        /// <param name="ip">服务IP</param>
        /// <returns></returns>
        [HttpGet("/getserver")]
        public IActionResult GetActionByServer(string ip)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new System.Uri($@"http://{ip}");
                var json = client.GetStringAsync("getactions").GetAwaiter().GetResult();
                var actions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(json);
                var groupActions = actions.GroupBy(s => new {s.actionName, s.controllerName });
                var list = new List<dynamic>();
                foreach (var action in groupActions)
                {
                    var predicates = new List<string>();
                    var comms = new StringBuilder();
                    foreach (var pre in action)
                    {
                        predicates.Add(pre.predicate.ToString());
                        comms.AppendLine($"{pre.predicate.ToString()}：{pre.commentaries.ToString()}，");
                    }
                    list.Add(new { commentaries = comms.ToString().Trim('，'), controllername = action.Key.controllerName, actionname = action.Key.actionName, predicates = predicates.ToArray(), isauthzation = true });
                }
                return new JsonResult(new { result = 1, data = list });
            }
            catch (Exception exc)
            {
                return new JsonResult(new { result = 0, message = exc.Message });
            }
        }
        /// <summary>
        /// 自动保存服务中路由到网关配置
        /// </summary>
        /// <param name="actions"></param>
        /// <param name="ip"></param>
        /// <param name="jwtkey"></param>
        /// <returns></returns>
        [HttpPost("/savaconfig")]
        public IActionResult SavaFileReRoute(List<ConfigAction> actions, string ip, string jwtkey)
        {
            try
            {
                var list = new List<FileReRoute>();
                var host = ip.Split(':')[0];
                var port = int.Parse(ip.Split(':')[1]);
                foreach (var action in actions)
                {
                    var routes = _fileConfigRepo.Get().GetAwaiter().GetResult();
                    var oldRoute = routes.Data.ReRoutes.FirstOrDefault(r => action.ActionName == r.DownstreamPathTemplate && action.ActionName == r.DownstreamScheme && host == r.DownstreamHostAndPorts[0].Host && port == r.DownstreamHostAndPorts[0].Port && action.ActionName == r.UpstreamPathTemplate);
                    if (oldRoute != null)
                    {
                        routes.Data.ReRoutes.Remove(oldRoute);
                    }
                    var newRoute = new FileReRoute { DownstreamPathTemplate = action.ActionName, UpstreamPathTemplate = action.ActionName,  DownstreamHostAndPorts =new List<FileHostAndPort> { new FileHostAndPort { Host = host, Port = port } }, DownstreamScheme = "http", UpstreamHttpMethod = new List<string>(action.Predicates), AuthenticationOptions = new FileAuthenticationOptions { AuthenticationProviderKey = action.IsAuthzation ? jwtkey : "" } };

                    routes.Data.ReRoutes.Add(newRoute);
                    _fileConfigRepo.Set(routes.Data);
                    _reload.AddReloadFlag();
                }
                _reload.ReloadConfig();
                return new JsonResult(new { result = 1 });
            }
            catch (Exception exc)
            {
                return new JsonResult(new { result = 0, message = exc.Message });
            }
        }
    }

}