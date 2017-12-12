using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
namespace Common
{
    /// <summary>
    /// action处理类型
    /// </summary>
    public class ActionHandle
    {
        /// <summary>
        /// 获取一个程序集中的所有Controller下的action
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <returns></returns>
        public static ActionMessage[] GetActions()
        {
            var assembly = Assembly.GetEntryAssembly();
            var actions = new List<ActionMessage>();
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(Controller).IsAssignableFrom(type))
                {
                    actions.AddRange(GetActionNames(type));
                }
            }
            return actions.ToArray();
        }
        /// <summary>
        /// 获取controller下的所有action
        /// </summary>
        /// <param name="type">controller类型</param>
        /// <returns></returns>
        static ActionMessage[] GetActionNames(Type type)
        {
            var list = new List<ActionMessage>();
            var controllerName = type.Name.ToLower().Replace("controller","");
            var apiname = "";
            foreach(var att in type.GetCustomAttributes(false))
            {
                if (att is RouteAttribute && (att as RouteAttribute).Template != null)
                {
                    apiname = (att as RouteAttribute).Template.ToLower().TrimStart('/').Replace("[controller]", controllerName);
                }
            }
            foreach (var method in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
            {
                var count = list.Count;
                foreach (var att in method.GetCustomAttributes(false))
                {

                    //todo 这里有bug
                    if (att is RouteAttribute && (att as RouteAttribute).Template != null)
                    {
                        var action = (att as RouteAttribute).Template.ToLower();
                        if (!action.StartsWith("/"))
                        {
                            action = $"/{apiname}/{action}";
                        }
                        list.Add(new ActionMessage() { ControllerName = controllerName, ActionName = action, Predicate ="Get" });
                    }

                    if (att is HttpGetAttribute)
                    {
                        if ((att as HttpGetAttribute).Template != null)
                        {
                            var action = (att as HttpGetAttribute).Template.ToLower();
                            if(!action.StartsWith("/"))
                            {
                                action = $"/{apiname}/{action}";
                            }
                            list.Add(new ActionMessage() { ControllerName = controllerName, ActionName = action, Predicate = "Get" });
                        }
                        else
                        {
                            list.Add(new ActionMessage() { ControllerName = controllerName, ActionName = $"/{controllerName.ToLower()}/{method.Name.ToLower().TrimStart('/')}", Predicate = "Get" });
                        }
                    }
                    if (att is HttpPostAttribute)
                    {
                        if ((att as HttpPostAttribute).Template != null)
                        {
                            var action = (att as HttpPostAttribute).Template.ToLower();
                            if (!action.StartsWith("/"))
                            {
                                action = $"/{apiname}/{action}";
                            }
                            list.Add(new ActionMessage() { ControllerName = controllerName, ActionName = action, Predicate = "Post" });
                        }
                        else
                        {
                            list.Add(new ActionMessage() { ControllerName = controllerName, ActionName = $"/{controllerName}/{method.Name.ToLower().TrimStart('/')}", Predicate = "Post" });
                        }
                    }
                    if (att is HttpDeleteAttribute)
                    {
                        if ((att as HttpDeleteAttribute).Template != null)
                        {
                            var action = (att as HttpDeleteAttribute).Template.ToLower();
                            if (!action.StartsWith("/"))
                            {
                                action = $"/{apiname}/{action}";
                            }
                            list.Add(new ActionMessage() { ControllerName = controllerName, ActionName = action, Predicate = "Delete" });
                        }
                        else
                        {
                            list.Add(new ActionMessage() { ControllerName = controllerName, ActionName = $"/{controllerName}/{method.Name.ToLower().TrimStart('/')}", Predicate = "Delete" });
                        }
                    }
                    if (att is HttpPutAttribute)
                    {
                        if ((att as HttpPutAttribute).Template != null)
                        {
                            var action = (att as HttpPutAttribute).Template.ToLower();
                            if (!action.StartsWith("/"))
                            {
                                action = $"/{apiname}/{action}";
                            }
                            list.Add(new ActionMessage() { ControllerName = controllerName, ActionName = action, Predicate = "Put" });
                        }
                        else
                        {
                            list.Add(new ActionMessage() { ControllerName = controllerName, ActionName = $"/{controllerName}/{method.Name.ToLower().TrimStart('/')}", Predicate = "Put" });
                        }
                    }
                }
                //当没有Route特性时用controller名称和action名称
                if (count == list.Count)
                {
                    list.Add(new ActionMessage() { ControllerName = controllerName, ActionName = $"/{controllerName.Replace("controller", "")}/{method.Name.ToLower().TrimStart('/')}", Predicate = "Get" });
                }
            }
            return list.ToArray();
        }
    }
}
