using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
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
            //获取注释到字典中
            var dic = GetXML(assembly.Location);
            var actions = new List<ActionMessage>();
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(Controller).IsAssignableFrom(type))
                {
                    actions.AddRange(GetActionNames(type,dic));
                }
            }
            return actions.ToArray();
        }
        /// <summary>
        /// 获取controller下的所有action
        /// </summary>
        /// <param name="type">controller类型</param>
        /// <returns></returns>
        static ActionMessage[] GetActionNames(Type type,Dictionary<string,string> dic)
        {
          
            var controllerName = type.Name.ToLower();
            //获取Controller上的RouteAttribute特性
            var apiname = "";
            foreach (var att in type.GetCustomAttributes(false))
            {
                if (att is RouteAttribute && (att as RouteAttribute).Template != null)
                {
                    apiname = (att as RouteAttribute).Template.ToLower().TrimStart('/').Replace("[controller]", controllerName.Replace("controller", ""));
                }
            }

            var list = new List<ActionMessage>();
            //获取Action对应的路由
            foreach (var method in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
            {
                //拼装xml，把action的测试拼装成xml注释中的格式
                var fullMethodName = $"M:{method.DeclaringType.FullName}.{method.Name}(";
                foreach (var par in method.GetParameters())
                {
                    fullMethodName += $"{par.ParameterType.FullName},";
                }
                fullMethodName = $"{fullMethodName.TrimEnd(',')})";
                //查看是否包含对应的注释，存在取出对应注释内容
                var commentaries = dic.ContainsKey(fullMethodName) ? dic[fullMethodName] : "";
                var count = list.Count;
                //分类action上特性的类型
                foreach (var att in method.GetCustomAttributes(false))
                {
                    if (att is RouteAttribute && (att as RouteAttribute).Template != null)
                    {
                        var action = (att as RouteAttribute).Template.ToLower();
                        if (!action.StartsWith("/"))
                        {
                            action = $"/{apiname}";
                        }

                        list.Add(new ActionMessage() { Commentaries = commentaries, ControllerName = controllerName, ActionName = action, Predicate = "Get" });
                    }

                    if (att is HttpGetAttribute)
                    {
                        if ((att as HttpGetAttribute).Template != null)
                        {
                            var action = (att as HttpGetAttribute).Template.ToLower();
                            if (!action.StartsWith("/"))
                            {
                                action = $"/{apiname}/{action}";
                            }
                            list.Add(new ActionMessage() { Commentaries = commentaries, ControllerName = controllerName, ActionName = action, Predicate = "Get" });
                        }
                        else
                        {
                            list.Add(new ActionMessage() { Commentaries = commentaries, ControllerName = controllerName, ActionName = $"/{apiname}", Predicate = "Get" });
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
                            list.Add(new ActionMessage() { Commentaries = commentaries, ControllerName = controllerName, ActionName = action, Predicate = "Post" });
                        }
                        else
                        {
                            list.Add(new ActionMessage() { Commentaries = commentaries, ControllerName = controllerName, ActionName = $"/{apiname}", Predicate = "Post" });
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
                            list.Add(new ActionMessage() { Commentaries = commentaries, ControllerName = controllerName, ActionName = action, Predicate = "Delete" });
                        }
                        else
                        {
                            list.Add(new ActionMessage() { Commentaries = commentaries, ControllerName = controllerName, ActionName = $"/{apiname}", Predicate = "Delete" });
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
                            list.Add(new ActionMessage() { Commentaries = commentaries, ControllerName = controllerName, ActionName = action, Predicate = "Put" });
                        }
                        else
                        {
                            list.Add(new ActionMessage() { Commentaries = commentaries, ControllerName = controllerName, ActionName = $"/{apiname}", Predicate = "Put" });
                        }
                    }
                }
                //当没有Route特性时用controller名称和action名称
                if (count == list.Count)
                {
                    list.Add(new ActionMessage() { Commentaries = commentaries, ControllerName = controllerName, ActionName = $"/{controllerName.Replace("controller", "")}/{method.Name.ToLower().TrimStart('/')}", Predicate = "Get" });
                }
            }
            return list.ToArray();
        }
        /// <summary>
        /// 获取方法注释，要求在项属性中设置生成xml
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetXML(string dllPath)
        {           
            var xmlPath = dllPath.Replace(".dll", ".xml");
            //查看xml是否存在
            if (System.IO.File.Exists(xmlPath))
            {
                var xml = new XmlDocument();
                xml.Load(xmlPath);

                var nodes = xml.SelectNodes("doc")[0].SelectNodes("members")[0].ChildNodes;
                var dic = new Dictionary<string, string>();
                foreach (XmlNode node in nodes)
                {
                    var xmlDoc = node.Attributes[0].Value;
                    //方法是以M开头的
                    if (xmlDoc.StartsWith("M:"))
                    {
                        var des = node.SelectNodes("summary")[0].InnerText;
                        if (xmlDoc.Contains("(") && xmlDoc.Contains(")"))
                        {                      
                            dic.Add(xmlDoc, des.Trim('\r').Trim('\n').Trim());
                        }
                        else
                        {
                            dic.Add(xmlDoc+"()", des.Trim('\r').Trim('\n').Trim());
                        }
                    }
                }
                return dic;
            }
            else
            {
                throw new Exception($"{xmlPath}不存在！");
            }
        }
    }
}
