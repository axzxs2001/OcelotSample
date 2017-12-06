using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfluxDBTool
{
    public class HttpHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Get(string uri, string username, string password)
        {
            var result = string.Empty;

            var client = new WebClient();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                client.Credentials = GetCredentialCache(uri, username, password);
                client.Headers.Add("Authorization", GetAuthorization(username, password));
            }
            return client.DownloadString(uri);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="paramStr"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Post(string uri, string paramStr, string username, string password)
        {
            var result = string.Empty;

            var client = new WebClient();

            // 采取POST方式必须加的Header
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var postData = Encoding.UTF8.GetBytes(paramStr);

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                client.Credentials = GetCredentialCache(uri, username, password);
                client.Headers.Add("Authorization", GetAuthorization(username, password));
            }

            var responseData = client.UploadData(uri, "POST", postData); // 得到返回字符流
            return Encoding.UTF8.GetString(responseData);// 解码                  
        }






        private static CredentialCache GetCredentialCache(string uri, string username, string password)
        {
            var authorization = string.Format("{0}:{1}", username, password);
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Basic", new NetworkCredential(username, password));
            return credCache;
        }




        private static string GetAuthorization(string username, string password)
        {
            var authorization = string.Format("{0}:{1}", username, password);
            return "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(authorization));
        }



    }
}
