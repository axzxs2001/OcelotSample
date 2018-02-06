namespace ServiceControlPanel
{
    partial class frmMainPanel
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabC = new System.Windows.Forms.TabControl();
            this.tabPageStartUp = new System.Windows.Forms.TabPage();
            this.tabPageConfigurationCenter = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabC.SuspendLayout();
            this.tabPageStartUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabC
            // 
            this.tabC.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabC.Controls.Add(this.tabPageStartUp);
            this.tabC.Controls.Add(this.tabPageConfigurationCenter);
            this.tabC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabC.Location = new System.Drawing.Point(0, 0);
            this.tabC.Multiline = true;
            this.tabC.Name = "tabC";
            this.tabC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabC.SelectedIndex = 0;
            this.tabC.Size = new System.Drawing.Size(963, 582);
            this.tabC.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabC.TabIndex = 0;
            // 
            // tabPageStartUp
            // 
            this.tabPageStartUp.Controls.Add(this.button1);
            this.tabPageStartUp.Location = new System.Drawing.Point(22, 4);
            this.tabPageStartUp.Name = "tabPageStartUp";
            this.tabPageStartUp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStartUp.Size = new System.Drawing.Size(937, 574);
            this.tabPageStartUp.TabIndex = 0;
            this.tabPageStartUp.Text = "启动管理";
            this.tabPageStartUp.UseVisualStyleBackColor = true;
            // 
            // tabPageConfigurationCenter
            // 
            this.tabPageConfigurationCenter.Location = new System.Drawing.Point(22, 4);
            this.tabPageConfigurationCenter.Name = "tabPageConfigurationCenter";
            this.tabPageConfigurationCenter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfigurationCenter.Size = new System.Drawing.Size(937, 574);
            this.tabPageConfigurationCenter.TabIndex = 1;
            this.tabPageConfigurationCenter.Text = "配置中心";
            this.tabPageConfigurationCenter.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(605, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(963, 582);
            this.Controls.Add(this.tabC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmMainPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务控制面板";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMainPanel_Load);
            this.Resize += new System.EventHandler(this.frmMainPanel_Resize);
            this.tabC.ResumeLayout(false);
            this.tabPageStartUp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabC;
        private System.Windows.Forms.TabPage tabPageStartUp;
        private System.Windows.Forms.TabPage tabPageConfigurationCenter;
        private System.Windows.Forms.Button button1;
    }
}

