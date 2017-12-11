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
        static string _url = "http://dotnetcoresample.service.consul:5000";
        static void Main(string[] args)
        {

            Console.Title = "TestClient";
            dynamic token = null;
            while (true)
            {
                Console.WriteLine("1、登录【admin】 2、登录【system】 3、登录【错误用户名密码】 4、查询HisUser数据  5、查询LisUser数据 6、用system登录后的压力测试  7、循环查询his");
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
                    case "6":
                        WebHisUser(token);
                        break;
                    case "7":
                        GetFeeItem(token);
                        break;
                }
                stopwatch.Stop();
                TimeSpan timespan = stopwatch.Elapsed;
                Console.WriteLine($"间隔时间：{timespan.TotalSeconds}");
                tokenString = "Bearer " + Convert.ToString(token?.access_token);
            }
        }
        static string tokenString = "";
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
            var request = new RestRequest("/hisapi/getfeeitems", Method.GET);
            var radom = new Random();
            var index = radom.Next(0, 36);
            request.AddParameter("name", arr[index]);
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

        static void WebHisUser(dynamic token)
        {
            count = 0;
            Console.Title = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff");
            for (int i = 0; i < 1000; i++)
            {
                new System.Threading.Thread(Exec).Start(tokenString);
            }
        }
        static int count = 0;
        static object oo = new Object();

        static string[] arr = new string[] { "直", "天", "大", "三", "小","阿","素","理","甲","黄","a","b" ,"c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u", "v", "w" ,"x","y","z"};
        static void Exec(object obj)
        {
            var client = new RestClient(_url);
            //这里要在获取的令牌字符串前加Bearer
            string tk = obj.ToString();
            client.AddDefaultHeader("Authorization", tk);
            client.Timeout = 300000;
            var request = new RestRequest("/hisapi/getfeeitems", Method.GET);
            var radom = new Random();
            var index=radom.Next(0, 36);
            request.AddParameter("name", arr[index]);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
           // Console.WriteLine(DateTime.Now+"         返回状态：" +(int)response.StatusCode +"\r\n"+content);
            if ((int)response.StatusCode == 200)
            {
                lock (oo)
                {
                    count++;
                }
            }
            if (count >= 1000)
            {
                Console.WriteLine($"{count} --总时间：{ (DateTime.Now - Convert.ToDateTime(Console.Title)).TotalMilliseconds}");
            }
        }

        public static void GetFeeItem(dynamic token)
        {
            for (int i = 0; i < 500; i++)
            {
                var client = new RestClient(_url);
                //这里要在获取的令牌字符串前加Bearer
                string tk = "Bearer " + Convert.ToString(token?.access_token);
                client.AddDefaultHeader("Authorization", tk);
                var request = new RestRequest("/hisapi/getfeeitems", Method.GET);
                var radom = new Random();
                var index = radom.Next(0, 36);
                request.AddParameter("name", arr[index]);
                IRestResponse response = client.Execute(request);
                var content = response.Content;
                Console.WriteLine($"状态码：{(int)response.StatusCode} 状态信息：{response.StatusCode}  返回结果：{content}");
            }
        }
    }

}
