using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceControlPanel
{
    /// <summary>
    /// Consul Http API类
    /// </summary>
    public class ConsulHttpAPI
    {
        /// <summary>
        /// 基地址
        /// </summary>
        readonly string _baseUrl;
        /// <summary>
        /// 前缀
        /// </summary>
        readonly string _prefix;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="baseUrl">基地址</param>
        protected ConsulHttpAPI(string baseUrl = "http://127.0.0.1:8500")
        {
            _prefix = "v1";
            _baseUrl = baseUrl;
        }
        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="T">入参类型</typeparam>
        /// <typeparam name="W">出参类型</typeparam>
        /// <param name="url">url</param>
        /// <param name="parmeter">参数</param>
        /// <returns></returns>
        protected W Get<T, W>(string url, T parmeter) where T : class, new()
        {
            var parmeterString = GetUrlParmeter(parmeter).ToLower();
            var request = WebRequest.Create($@"{_baseUrl}/{_prefix}/{url}?{parmeterString}");
            request.Method = "Get";
            var stream = request.GetResponse().GetResponseStream();
            var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            reader.Close();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<W>(json);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <typeparam name="W">反回值类型</typeparam>
        /// <param name="url">url</param>
        /// <param name="parmeter">参数</param>
        /// <returns></returns>
        protected W Post<T, W>(string url, T parmeter) where T : class, new()
        {
            var request = WebRequest.Create($@"{_baseUrl}/{_prefix}/{url}");
            request.Method = "Post";
            var requestStream = request.GetRequestStream();
            var writer = new StreamWriter(requestStream);
            var parmeterString = GetUrlParmeter(parmeter);
            writer.Write(parmeterString);
            var responseStream = request.GetResponse().GetResponseStream();
            var reader = new StreamReader(responseStream);
            var json = reader.ReadToEnd();
            writer.Close();
            reader.Close();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<W>(json);
        }
        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <typeparam name="W">反回值类型</typeparam>
        /// <param name="url">url</param>
        /// <param name="parmeter">参数</param>
        /// <returns></returns>
        protected W Put<T,W>(string url, T parmeter) where T : class, new()
        {
            var request = WebRequest.Create($@"{_baseUrl}/{_prefix}/{url}");
            request.Method = "Put";
            var requestStream = request.GetRequestStream();
            var writer = new StreamWriter(requestStream);
            var parmeterString = GetUrlParmeter(parmeter);
            writer.Write(parmeterString);
            writer.Flush();
            var responseStream = request.GetResponse().GetResponseStream();
            var reader = new StreamReader(responseStream);
            var json = reader.ReadToEnd();
            writer.Close();
            reader.Close();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<W>(json);
        }
        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="W">反回值类型</typeparam>
        /// <param name="url">url</param>
        /// <param name="value">参数</param>
        /// <returns></returns>
        protected W Put<W>(string url, object value) 
        {
            var request = WebRequest.Create($@"{_baseUrl}/{_prefix}/{url}");
            request.Method = "Put";
            var requestStream = request.GetRequestStream();
            var writer = new StreamWriter(requestStream);        
            writer.Write(value);
            writer.Flush();
            var responseStream = request.GetResponse().GetResponseStream();
            var reader = new StreamReader(responseStream);
            var json = reader.ReadToEnd();
            writer.Close();
            reader.Close();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<W>(json);
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <typeparam name="W">反回值类型</typeparam>
        /// <param name="url">url</param>
        /// <param name="parmeter">参数</param>
        /// <returns></returns>
        protected W Delete<T, W>(string url, T parmeter) where T : class, new()
        {
            var parmeterString = GetUrlParmeter(parmeter);
            var request = WebRequest.Create($@"{_baseUrl}/{_prefix}/{url}");
            request.Method = "DELETE";
            var requestStream = request.GetRequestStream();
            var writer = new StreamWriter(requestStream);
            writer.Write(parmeterString);
            writer.Flush();
            var stream = request.GetResponse().GetResponseStream();
            var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            reader.Close();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<W>(json);
        }
        /// <summary>
        /// 从实体类生成字符参数
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="inEntity">实体类</param>
        /// <returns></returns>
        string GetUrlParmeter<T>(T inEntity) where T : class, new()
        {
            var parmeterString = new StringBuilder();
            foreach (var pro in inEntity.GetType().GetProperties())
            {
                if (pro.GetValue(inEntity, null) != null)
                {
                    var proName = pro.Name;
                    var atts = pro.GetCustomAttributes(typeof(FieldNameAttribute), false);
                    if (atts.Length > 0)
                    {
                        proName = (atts[0] as FieldNameAttribute).ChangeFieldName;
                    }
                    parmeterString.Append($"{proName}={pro.GetValue(inEntity, null)}&");
                }
            }
            return parmeterString.ToString().Trim('&');
        }
    }

}
