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

                    //加载button
                    var btn = CreateButton(btnCfg, cfg, top, left);
                    //加载checkbox
                    if (btnCfg.Type?.ToString().ToLower() != "all")
                    {
                        var checkBox = CreateCheckBox(btnCfg, cfg, top, left);
                        checkBox.Tag = btn;
                        tabPageStartUp.Controls.Add(checkBox);
                    }

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
        /// 创建CheckBox
        /// </summary>
        /// <param name="cfg">全局配置文件</param>
        /// <param name="top">按钮上边距</param>
        /// <param name="left">按钮左边距</param>
        /// <returns></returns>
        CheckBox CreateCheckBox(dynamic btnCfg, dynamic cfg, int top, int left)
        {
            var checkBox = new CheckBox();
            checkBox.Name = $"chk_{btnCfg.Type}_{btnCfg.Name}";
            checkBox.Text = "";
            checkBox.BackColor = Color.Transparent;
            checkBox.Width = 15;
            checkBox.Height = 14;
            checkBox.Top = top + 4;
            checkBox.Left = left + Convert.ToInt32(cfg.width) - checkBox.Width - 4;
            return checkBox;
        }
        /// <summary>
        /// 创建按钮
        /// </summary>
        /// <param name="btnCfg">按钮配置文件</param>
        /// <param name="cfg">全局配置文件</param>
        /// <param name="top">按钮上边距</param>
        /// <param name="left">按钮左边距</param>
        /// <returns></returns>
        Button CreateButton(dynamic btnCfg, dynamic cfg, int top, int left)
        {
            var btn = new Button();
            btn.Name = $"btn_{btnCfg.Type}_{btnCfg.Name}";
            btn.Top = top;
            btn.Left = left;
            btn.FlatStyle = FlatStyle.Popup;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Width = cfg.width;
            btn.Height = cfg.height;
            btn.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.Tag = new { state = false, allclick = false };
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
                    case "all":
                        proc = new AllProcess(_proDic, tabPageStartUp);
                        break;
                    default:
                        return;
                }
                if ((bool)(((Button)btnsender).Tag as dynamic).state)
                {
                    if ((((Button)btnsender).Tag as dynamic).allclick)
                    {
                        proc.StopProcess(btnCfg);
                        btn.Text = btnCfg.StartText;
                        btn.Image = Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}{btnCfg.StopImage}");
                        ((Button)btnsender).Tag = new { state = (((Button)btnsender).Tag as dynamic).state, allclick = false };
                    }
                    else
                    {
                        var name = btnCfg.Name.ToString();
                        if (MessageBox.Show($"退出后服务会停止，你确定要退出{name}?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            proc.StopProcess(btnCfg);
                            btn.Text = btnCfg.StartText;
                            btn.Image = Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}{btnCfg.StopImage}");
                        }
                    }
                }
                else
                {
                    btn.Text = btnCfg.StopText;
                    btn.Image = Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}{btnCfg.StartImage}");
                    proc.StartProcess(btnCfg);
                }
                ((Button)btnsender).Tag = new { state = !(bool)(((Button)btnsender).Tag as dynamic).state, allclick = false };
            };
            return btn;
        }

        private void frmMainPanel_Resize(object sender, EventArgs e)
        {
            LoadButton();
        }
    }


}
