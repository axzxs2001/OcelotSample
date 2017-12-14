using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// action信息类
    /// </summary>
    public class ActionMessage
    {
        /// <summary>
        /// 注释
        /// </summary>
        public string Commentaries { get; set; }
        /// <summary>
        /// 所属controller
        /// </summary>
        public string ControllerName
        { get; set; }
        /// <summary>
        /// action名称
        /// </summary>
        public string ActionName
        {
            get;set;
        }
        /// <summary>
        /// 谓词
        /// </summary>
        public string Predicate
        { get; set; }
    }
}
