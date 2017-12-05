using Dapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;

namespace DapperPlus
{
    /// <summary>
    /// IDapperPlusDB数据库类型 
    /// </summary>
    public interface IDapperPlusDB 
    {
        /// <summary>
        /// 连接对象
        /// </summary>
        /// <returns></returns>
         IDbConnection GetConnection();

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <typeparam name="T">映射实体类</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数对象</param>
        /// <param name="transaction">事务</param>
        /// <param name="buffered">是否缓存结果</param>
        /// <param name="commandTimeout">command超时时间(秒)</param>
        /// <param name="commandType">command类型</param>
        /// <returns></returns>
         IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = false, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="sql">映射实体类</param>
        /// <param name="param">参数对象</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">command超时时间(秒)</param>
        /// <param name="commandType">command类型</param>
        /// <returns></returns>
         int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行动态json参数的增删改语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="jsonString">json参数</param>
        /// <param name="timeStampField">时间戳字段</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">command超时时间(秒)</param>
        /// <param name="commandType">command类型</param>
        /// <returns></returns>
        int Execute(string sql, string jsonString, string timeStampField = "timestamp", IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);             
    }
}
