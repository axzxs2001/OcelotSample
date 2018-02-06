using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceControlPanel
{
    public partial class frmMainPanel : Form
    {
        public frmMainPanel()
        {
            InitializeComponent();
        }

        private void frmMainPanel_Load(object sender, EventArgs e)
        {
            _proDic = new Dictionary<string, Process>();
            LoadButton();
        }

        Dictionary<string, Process> _proDic;
        /// <summary>
        /// 从config.json配置文件中加载按钮
        /// </summary>
        void LoadButton()
        {
            try
            {
                tabPageStartUp.Controls.Clear();
                //读取配置文件
                var json = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/config.json");
                //转成配置对象
                var cfg = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
                //获取父控件宽度
                var parentWidth = tabPageStartUp.Width;
                //宽度计数
                int widthCount = 1;
                //高度计数
                int heightCount = 1;
                //间隔
                int split = 10;
                foreach (var btnCfg in cfg.buttons)
                {
                    #region top和left计算
                    //设置按钮属性
                    var top = split;
                    //右边距和上边距计算
                    var left = widthCount * split + Convert.ToInt32(cfg.width) * (widthCount - 1);
                    if (parentWidth < split + Convert.ToInt32(cfg.width))
                    {
                        top = heightCount * split + Convert.ToInt32(cfg.height) * (heightCount - 1);
                        left = split;
                        heightCount++;
                    }
                    else if (parentWidth < left + Convert.ToInt32(cfg.width))
                    {
                        heightCount++;
                        top = heightCount * split + Convert.ToInt32(cfg.height) * (heightCount - 1);
                        left = split;
                    }
                    #endregion
                    var btn = CreateButton(btnCfg, cfg, top, left);
                    widthCount++;
                    tabPageStartUp.Controls.Add(btn);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// 创建按钮
        /// </summary>
        /// <param name="btnCfg">按钮配置文件</param>
        /// <param name="cfg">全局配置文件</param>
        /// <param name="top">按钮上边距</param>
        /// <param name="left">按钮左边距</param>
        /// <returns></returns>
        Button CreateButton(dynamic btnCfg,dynamic cfg,int top,int left)
        {
            var btn = new Button();
            btn.Top = top;
            btn.Left = left;
            btn.FlatStyle = FlatStyle.Popup;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Width = cfg.width;
            btn.Height = cfg.height;
            btn.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.Tag = false;
            btn.Text = btnCfg.StartText;
            btn.Image = Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}{btnCfg.StopImage}");
            //设置按钮事件
            btn.Click += delegate (object btnsender, EventArgs eargs)
            {
                ApplicationProcess proc = null;
                switch (btnCfg.Type?.ToString().ToLower())
                {
                    case "consul":
                        proc = new ConsulProcess(_proDic);
                        break;
                    case "docker":
                        proc = new DockerProcess(_proDic);
                        break;
                    case "dotnet":
                        proc = new DotnetProcess(_proDic);
                        break;
                    default:
                        return;
                }
                if ((bool)((Button)btnsender).Tag)
                {
                    proc.StopProcess(btnCfg);
                    btn.Text = btnCfg.StartText;
                    btn.Image = Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}{btnCfg.StopImage}");
                }
                else
                {
                    btn.Text = btnCfg.StopText;
                    btn.Image = Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}{btnCfg.StartImage}");
                    proc.StartProcess(btnCfg);
                }
               ((Button)btnsender).Tag = !(bool)((Button)btnsender).Tag;
            };
            return btn;
        }

        private void frmMainPanel_Resize(object sender, EventArgs e)
        {
            LoadButton();
        }
    }


}
