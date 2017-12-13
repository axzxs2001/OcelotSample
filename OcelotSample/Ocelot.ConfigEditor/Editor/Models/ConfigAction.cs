using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocelot.ConfigEditor.Editor.Models
{
    /// <summary>
    /// 配置Action
    /// </summary>
    public class ConfigAction
    {
        /// <summary>
        /// Controller名称
        /// </summary>
        public string ControllerName { get; set; }
        /// <summary>
        /// Action名称
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 是否验证
        /// </summary>
        public bool IsAuthzation { get; set; }
        /// <summary>
        /// 谓词集合
        /// </summary>
        public string[] Predicates { get; set; }
    }
}
