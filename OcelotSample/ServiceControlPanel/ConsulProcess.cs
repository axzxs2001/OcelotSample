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
    /// Consul进程
    /// </summary>
    public class ConsulProcess : ApplicationProcess
    {
        public ConsulProcess(Dictionary<string, Process> proDic)
        {
            _proDic = proDic;
        }
        /// <summary>
        /// 结束Consul进程
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
        /// 启动Consul进程
        /// </summary>
        /// <param name="btnCfg"></param>
        public override void StartProcess(dynamic btnCfg)
        {
            string name = btnCfg.Name.ToString();
            string file = $"{AppDomain.CurrentDomain.BaseDirectory}{btnCfg.cmd}";
            var arg = File.ReadAllText(file).Replace("consul", "").Replace("./", $@"{AppDomain.CurrentDomain.BaseDirectory}consul\").Trim();
            var proc = new Process();
            //设置要启动的应用程序
            proc.StartInfo.FileName = $@"{AppDomain.CurrentDomain.BaseDirectory}consul\consul.exe";
            proc.StartInfo.Arguments = arg;
            proc.Start();
            _proDic.Add(name, proc);
        }
    }
}
