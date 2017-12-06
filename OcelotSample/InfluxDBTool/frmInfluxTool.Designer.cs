namespace InfluxDBTool
{
    partial class frmInfluxTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfluxTool));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txbSQL = new System.Windows.Forms.TextBox();
            this.txbQueryResult = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tstbUrl = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstbUserName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tstbPassword = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tstbDataBase = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txbSQL);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbQueryResult);
            this.splitContainer1.Size = new System.Drawing.Size(976, 522);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.TabIndex = 2;
            // 
            // txbSQL
            // 
            this.txbSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbSQL.Location = new System.Drawing.Point(0, 0);
            this.txbSQL.Multiline = true;
            this.txbSQL.Name = "txbSQL";
            this.txbSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbSQL.Size = new System.Drawing.Size(976, 145);
            this.txbSQL.TabIndex = 2;
            this.txbSQL.Text = "select * from /application.httprequests__active/";
            // 
            // txbQueryResult
            // 
            this.txbQueryResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbQueryResult.Location = new System.Drawing.Point(0, 0);
            this.txbQueryResult.Multiline = true;
            this.txbQueryResult.Name = "txbQueryResult";
            this.txbQueryResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbQueryResult.Size = new System.Drawing.Size(976, 373);
            this.txbQueryResult.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tstbUrl,
            this.toolStripLabel2,
            this.tstbUserName,
            this.toolStripLabel3,
            this.tstbPassword,
            this.toolStripLabel4,
            this.tstbDataBase,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(976, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::InfluxDBTool.Properties.Resources.play;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tstbUrl
            // 
            this.tstbUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbUrl.Name = "tstbUrl";
            this.tstbUrl.Size = new System.Drawing.Size(300, 25);
            this.tstbUrl.Text = "http://127.0.0.1:8086";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(26, 22);
            this.toolStripLabel1.Text = "url:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel2.Text = "username:";
            // 
            // tstbUserName
            // 
            this.tstbUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbUserName.Name = "tstbUserName";
            this.tstbUserName.Size = new System.Drawing.Size(100, 25);
            this.tstbUserName.Text = "admin";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel3.Text = "password:";
            // 
            // tstbPassword
            // 
            this.tstbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbPassword.Name = "tstbPassword";
            this.tstbPassword.Size = new System.Drawing.Size(100, 25);
            this.tstbPassword.Text = "123456";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel4.Text = "database:";
            // 
            // tstbDataBase
            // 
            this.tstbDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbDataBase.Name = "tstbDataBase";
            this.tstbDataBase.Size = new System.Drawing.Size(150, 25);
            this.tstbDataBase.Text = "AppMetricsDemo";
            // 
            // frmInfluxTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 547);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInfluxTool";
            this.Text = "InfluxTool";
            this.Load += new System.EventHandler(this.frmInfluxTool_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txbSQL;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox txbQueryResult;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstbUrl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tstbUserName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tstbPassword;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox tstbDataBase;
    }
}

