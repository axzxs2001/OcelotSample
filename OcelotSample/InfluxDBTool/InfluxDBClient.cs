using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace InfluxDBTool
{

 
 public class InfluxDBClient
 {
     string _baseAddress;
     string _username;
     string _password;
 
     /// <summary>
     /// 构造函数
     /// </summary>
     /// <param name="baseAddress"></param>
     /// <param name="username"></param>
     /// <param name="password"></param>
     public InfluxDBClient(string baseAddress, string username, string password)
     {
         this._baseAddress = baseAddress;
         this._username = username;
         this._password = password;
     }
 
 
 
     /// <summary>
     /// 读
     /// </summary>
     /// <param name="database"></param>
     /// <param name="sql"></param>
     /// <returns></returns>
     public string Query(string database, string sql)
     {
         string pathAndQuery = string.Format("/query?db={0}&q={1}", database, sql);
         string url = _baseAddress + pathAndQuery;
 
         string result = HttpHelper.Get(url, _username, _password);
         return result;
     }
 
 
 
 
     /// <summary>
     /// 写
     /// </summary>
     /// <param name="database"></param>
     /// <param name="sql"></param>
     /// <returns></returns>
     public string Write(string database, string sql)
     {
         string pathAndQuery = string.Format("/write?db={0}&precision=s", database);
         string url = _baseAddress + pathAndQuery;
 
         string result = HttpHelper.Post(url, sql, _username, _password);
         return result;
     }
 }
}
