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
    /// 全部进程
    /// </summary>
    public class AllProcess : ApplicationProcess
    {
        Control _control;
        public AllProcess(Dictionary<string, Process> proDic, Control control)
        {
            _proDic = proDic;
            _control = control;
        }
        /// <summary>
        /// 结束所有进程
        /// </summary>
        /// <param name="btnCfg"></param>
        public override void StopProcess(dynamic btnCfg)
        {
            foreach (var control in _control.Controls)
            {
                if (control is CheckBox)
                {
                    var chk = control as CheckBox;
                    if (chk.Checked)
                    {
                        var btn = chk.Tag as Button;
                        btn.Tag= new { state = (btn.Tag as dynamic).state, allclick = true };
                        btn.PerformClick();
                    }
                    chk.Enabled = true;
                }
            }
        }
        /// <summary>
        /// 启动所有进程
        /// </summary>
        /// <param name="btnCfg"></param>
        public override void StartProcess(dynamic btnCfg)
        {
            foreach (var control in _control.Controls)
            {               
                if(control is CheckBox)
                {
                    var chk = control as CheckBox;
                    if(chk.Checked)
                    {
                        var btn = chk.Tag as Button;
                        btn.PerformClick();
                    }
                    chk.Enabled = false;
                }
            }
        }
    }
}
