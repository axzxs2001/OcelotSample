using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceControlPanel
{
    /// <summary>
    /// asp.net core进程
    /// </summary>
    public class DotnetProcess : ApplicationProcess
    {
        public DotnetProcess(Dictionary<string, Process> proDic)
        {
            _proDic = proDic;
        }
        /// <summary>
        /// 结束Dotnet进程
        /// </summary>
        /// <param name="btnCfg"></param>
        public override void StopProcess(dynamic btnCfg)
        {
            string name = btnCfg.Name.ToString();
            if (MessageBox.Show($"退出后服务会停止，你确定要退出{name}?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var proc = _proDic[name] as Process;
                if (!proc.HasExited)
                {
                    proc.Kill();
                    proc.Close();
                }
                _proDic.Remove(name);
            }
        }
        /// <summary>
        /// 启动Dotnet进程
        /// </summary>
        /// <param name="btnCfg"></param>
        public override void StartProcess(dynamic btnCfg)
        {
            string name = btnCfg.Name.ToString();
            string file = $"{AppDomain.CurrentDomain.BaseDirectory}{btnCfg.cmd}";
            var arg = File.ReadAllText(file).Replace("donet", "").Replace("./", $@"{AppDomain.CurrentDomain.BaseDirectory}consul\").Trim();
            var proc = new Process();
            //设置要启动的应用程序
            proc.StartInfo.FileName = $@"dotnet";
            proc.StartInfo.Arguments = arg;
            proc.Start();
            _proDic.Add(name, proc);
        }
    }
}
