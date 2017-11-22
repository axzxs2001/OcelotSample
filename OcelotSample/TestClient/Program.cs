using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        /// <summary>
        /// 访问Url
        /// </summary>
        static string _url = "http://localhost:5000";
        static void Main(string[] args)
        {
            Console.Title = "TestClient";
            dynamic token = null;
            while (true)
            {
                Console.WriteLine("1、登录【admin】 2、登录【system】 3、登录【错误用户名密码】 4、查询HisUser数据  5、查询LisUser数据");
                var mark = Console.ReadLine();
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                switch (mark)
                {
                    case "1":
                        token = AdminLogin();
                        break;
                    case "2":
                        token = SystemLogin();
                        break;
                    case "3":
                        token = NullLogin();
                        break;
                    case "4":
                        HisUser(token);
                        break;
                    case "5":
                        LisUser(token);
                        break;
                }
                stopwatch.Stop();
                TimeSpan timespan = stopwatch.Elapsed;
                Console.WriteLine($"间隔时间：{timespan.TotalSeconds}");
            }
        }

        static dynamic NullLogin()
        {
            var loginClient = new RestClient(_url);
            var loginRequest = new RestRequest("/authapi/login", Method.POST);
            loginRequest.AddParameter("username", "gswaa");
            loginRequest.AddParameter("password", "111111");
            //或用用户名密码查询对应角色
            loginRequest.AddParameter("role", "system");
            IRestResponse loginResponse = loginClient.Execute(loginRequest);
            var loginContent = loginResponse.Content;
            Console.WriteLine(loginContent);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(loginContent);
        }
        static dynamic SystemLogin()
        {
            var loginClient = new RestClient(_url);
            var loginRequest = new RestRequest("/authapi/login", Method.POST);
            loginRequest.AddParameter("username", "ggg");
            loginRequest.AddParameter("password", "222222");        
            IRestResponse loginResponse = loginClient.Execute(loginRequest);
            var loginContent = loginResponse.Content;
            Console.WriteLine(loginContent);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(loginContent);
        }
        static dynamic AdminLogin()
        {
            var loginClient = new RestClient(_url);
            var loginRequest = new RestRequest("/authapi/login", Method.POST);
            loginRequest.AddParameter("username", "gsw");
            loginRequest.AddParameter("password", "111111");      
            IRestResponse loginResponse = loginClient.Execute(loginRequest);
            var loginContent = loginResponse.Content;
            Console.WriteLine(loginContent);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(loginContent);
        }
        static void HisUser(dynamic token)
        {
            var client = new RestClient(_url);
            //这里要在获取的令牌字符串前加Bearer
            string tk = "Bearer " + Convert.ToString(token?.access_token);
            client.AddDefaultHeader("Authorization", tk);
            var request = new RestRequest("/hisapi/hisuser", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine($"状态码：{(int)response.StatusCode} 状态信息：{response.StatusCode}  返回结果：{content}");
        }
        static void LisUser(dynamic token)
        {
            var client = new RestClient(_url);
            //这里要在获取的令牌字符串前加Bearer
            string tk = "Bearer " + Convert.ToString(token?.access_token);
            client.AddDefaultHeader("Authorization", tk);
            var request = new RestRequest("/lisapi/lisuser", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content; Console.WriteLine($"状态码：{(int)response.StatusCode} 状态信息：{response.StatusCode}  返回结果：{content}");
        }
    }
}
