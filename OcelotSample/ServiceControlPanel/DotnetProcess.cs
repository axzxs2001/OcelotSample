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
                if (proc != null && !proc.HasExited)
                {
                    var pid = proc.Id;
                    //查询所有dotnet进程，父进程与守护进行相同的kill掉，并把守护进程kill掉
                    foreach (var pro in Process.GetProcessesByName("dotnet"))
                    {
                        var childID = pro.Parent().Id;
                        if (pid == childID)
                        {
                            pro.Kill();
                            pro.Close();
                        }
                    }
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
            var arg = File.ReadAllText(file);
            var proc = new Process();
            //设置要启动的应用程序
            proc.StartInfo.FileName = $@"cmd.exe";       
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();    
            proc.StandardInput.WriteLine($"cd {btnCfg.Name}");
            proc.StandardInput.WriteLine($"{arg}");
            proc.StandardInput.AutoFlush = true;    
            proc.StandardInput.WriteLine("pause");
            _proDic.Add(name, proc);
        }
    }
}
