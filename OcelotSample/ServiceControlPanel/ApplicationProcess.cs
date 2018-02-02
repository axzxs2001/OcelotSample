using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceControlPanel
{
    /// <summary>
    /// 应用进程
    /// </summary>
    public abstract class ApplicationProcess
    {
        protected Dictionary<string, Process> _proDic;
        /// <summary>
        /// 停止进程
        /// </summary>
        /// <param name="btnCfg"></param>
        public abstract void StopProcess(dynamic btnCfg);
        /// <summary>
        /// 开始进程
        /// </summary>
        /// <param name="btnCfg"></param>
        public abstract void StartProcess(dynamic btnCfg);
    }
}
