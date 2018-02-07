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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainPanel));
            this.tabC = new System.Windows.Forms.TabControl();
            this.tabPageStartUp = new System.Windows.Forms.TabPage();
            this.tabPageConfigurationCenter = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listKey = new System.Windows.Forms.ListView();
            this.txbValue = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.imgListBtns = new System.Windows.Forms.ImageList(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSava = new System.Windows.Forms.Button();
            this.txbKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabC.SuspendLayout();
            this.tabPageConfigurationCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tabPageConfigurationCenter.Controls.Add(this.splitContainer1);
            this.tabPageConfigurationCenter.Location = new System.Drawing.Point(22, 4);
            this.tabPageConfigurationCenter.Name = "tabPageConfigurationCenter";
            this.tabPageConfigurationCenter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfigurationCenter.Size = new System.Drawing.Size(937, 574);
            this.tabPageConfigurationCenter.TabIndex = 1;
            this.tabPageConfigurationCenter.Text = "配置中心";
            this.tabPageConfigurationCenter.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listKey);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbValue);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txbKey);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(931, 568);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 3;
            // 
            // listKey
            // 
            this.listKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listKey.Location = new System.Drawing.Point(0, 20);
            this.listKey.Name = "listKey";
            this.listKey.Size = new System.Drawing.Size(291, 548);
            this.listKey.TabIndex = 0;
            this.listKey.UseCompatibleStateImageBehavior = false;
            this.listKey.SelectedIndexChanged += new System.EventHandler(this.listKey_SelectedIndexChanged);
            // 
            // txbValue
            // 
            this.txbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbValue.Location = new System.Drawing.Point(0, 128);
            this.txbValue.Multiline = true;
            this.txbValue.Name = "txbValue";
            this.txbValue.Size = new System.Drawing.Size(636, 377);
            this.txbValue.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(636, 67);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnSava);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 505);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(636, 63);
            this.panel1.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Font = new System.Drawing.Font("宋体", 16F);
            this.btnDelete.ImageKey = "Delete.png";
            this.btnDelete.ImageList = this.imgListBtns;
            this.btnDelete.Location = new System.Drawing.Point(289, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 47);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // imgListBtns
            // 
            this.imgListBtns.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListBtns.ImageStream")));
            this.imgListBtns.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListBtns.Images.SetKeyName(0, "Add.png");
            this.imgListBtns.Images.SetKeyName(1, "Delete.png");
            this.imgListBtns.Images.SetKeyName(2, "Modify.png");
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUpdate.Font = new System.Drawing.Font("宋体", 16F);
            this.btnUpdate.ImageIndex = 2;
            this.btnUpdate.ImageList = this.imgListBtns;
            this.btnUpdate.Location = new System.Drawing.Point(402, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(113, 47);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnSava
            // 
            this.btnSava.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSava.Font = new System.Drawing.Font("宋体", 16F);
            this.btnSava.ImageIndex = 0;
            this.btnSava.ImageList = this.imgListBtns;
            this.btnSava.Location = new System.Drawing.Point(515, 8);
            this.btnSava.Name = "btnSava";
            this.btnSava.Size = new System.Drawing.Size(113, 47);
            this.btnSava.TabIndex = 0;
            this.btnSava.Text = "添加";
            this.btnSava.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSava.UseVisualStyleBackColor = true;
            this.btnSava.Click += new System.EventHandler(this.btnSava_Click);
            // 
            // txbKey
            // 
            this.txbKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.txbKey.Location = new System.Drawing.Point(0, 87);
            this.txbKey.Name = "txbKey";
            this.txbKey.Size = new System.Drawing.Size(636, 21);
            this.txbKey.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(636, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "全局参数键：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(636, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "全局参数值(Json)：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "注意事项：";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "全部参数：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tabPageConfigurationCenter.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabC;
        private System.Windows.Forms.TabPage tabPageStartUp;
        private System.Windows.Forms.TabPage tabPageConfigurationCenter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listKey;
        private System.Windows.Forms.TextBox txbValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSava;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ImageList imgListBtns;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

