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
            this.tabPageConfigCenter = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listKV = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.imgListBtns = new System.Windows.Forms.ImageList(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSava = new System.Windows.Forms.Button();
            this.tabPageServiceCenter = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridService = new System.Windows.Forms.DataGridView();
            this.gridCheck = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCheckDelete = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCheckModify = new System.Windows.Forms.Button();
            this.btnCheckAdd = new System.Windows.Forms.Button();
            this.comCheckMethod = new System.Windows.Forms.ComboBox();
            this.txbCheckTimeout = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txbCheckInterval = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbCheckHttp = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbCheckName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txbCheckID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnServiceDelete = new System.Windows.Forms.Button();
            this.btnServiceModify = new System.Windows.Forms.Button();
            this.btnServiceQuery = new System.Windows.Forms.Button();
            this.btnServiceAdd = new System.Windows.Forms.Button();
            this.txbServiceTag = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbServicePort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbServiceIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbSeviceName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbServiceID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageCluster = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txbClusterIP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnInsertCluster = new System.Windows.Forms.Button();
            this.gridRaft = new System.Windows.Forms.DataGridView();
            this.tabC.SuspendLayout();
            this.tabPageConfigCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageServiceCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageCluster.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRaft)).BeginInit();
            this.SuspendLayout();
            // 
            // tabC
            // 
            this.tabC.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabC.Controls.Add(this.tabPageStartUp);
            this.tabC.Controls.Add(this.tabPageConfigCenter);
            this.tabC.Controls.Add(this.tabPageServiceCenter);
            this.tabC.Controls.Add(this.tabPageCluster);
            this.tabC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabC.Location = new System.Drawing.Point(0, 0);
            this.tabC.Multiline = true;
            this.tabC.Name = "tabC";
            this.tabC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabC.SelectedIndex = 0;
            this.tabC.Size = new System.Drawing.Size(959, 582);
            this.tabC.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabC.TabIndex = 0;
            // 
            // tabPageStartUp
            // 
            this.tabPageStartUp.Location = new System.Drawing.Point(22, 4);
            this.tabPageStartUp.Name = "tabPageStartUp";
            this.tabPageStartUp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStartUp.Size = new System.Drawing.Size(933, 574);
            this.tabPageStartUp.TabIndex = 0;
            this.tabPageStartUp.Text = "启动管理";
            this.tabPageStartUp.UseVisualStyleBackColor = true;
            // 
            // tabPageConfigCenter
            // 
            this.tabPageConfigCenter.Controls.Add(this.splitContainer1);
            this.tabPageConfigCenter.Location = new System.Drawing.Point(22, 4);
            this.tabPageConfigCenter.Name = "tabPageConfigCenter";
            this.tabPageConfigCenter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfigCenter.Size = new System.Drawing.Size(933, 574);
            this.tabPageConfigCenter.TabIndex = 1;
            this.tabPageConfigCenter.Text = "配置中心";
            this.tabPageConfigCenter.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listKV);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbValue);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txbKey);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(927, 568);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 3;
            // 
            // listKV
            // 
            this.listKV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listKV.FormattingEnabled = true;
            this.listKV.ItemHeight = 12;
            this.listKV.Location = new System.Drawing.Point(0, 20);
            this.listKV.Name = "listKV";
            this.listKV.Size = new System.Drawing.Size(288, 548);
            this.listKV.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "全部参数：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbValue
            // 
            this.txbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbValue.Location = new System.Drawing.Point(0, 61);
            this.txbValue.Multiline = true;
            this.txbValue.Name = "txbValue";
            this.txbValue.Size = new System.Drawing.Size(635, 455);
            this.txbValue.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(635, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "全局参数值：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbKey
            // 
            this.txbKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.txbKey.Location = new System.Drawing.Point(0, 20);
            this.txbKey.Name = "txbKey";
            this.txbKey.Size = new System.Drawing.Size(635, 21);
            this.txbKey.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(635, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "全局参数键：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnSava);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 516);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(635, 52);
            this.panel1.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Font = new System.Drawing.Font("宋体", 10F);
            this.btnDelete.ImageKey = "Delete.png";
            this.btnDelete.ImageList = this.imgListBtns;
            this.btnDelete.Location = new System.Drawing.Point(363, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnUpdate.Font = new System.Drawing.Font("宋体", 10F);
            this.btnUpdate.ImageIndex = 2;
            this.btnUpdate.ImageList = this.imgListBtns;
            this.btnUpdate.Location = new System.Drawing.Point(451, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 36);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSava
            // 
            this.btnSava.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSava.Font = new System.Drawing.Font("宋体", 10F);
            this.btnSava.ImageIndex = 0;
            this.btnSava.ImageList = this.imgListBtns;
            this.btnSava.Location = new System.Drawing.Point(539, 8);
            this.btnSava.Name = "btnSava";
            this.btnSava.Size = new System.Drawing.Size(88, 36);
            this.btnSava.TabIndex = 0;
            this.btnSava.Text = "添加";
            this.btnSava.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSava.UseVisualStyleBackColor = false;
            this.btnSava.Click += new System.EventHandler(this.btnSava_Click);
            // 
            // tabPageServiceCenter
            // 
            this.tabPageServiceCenter.Controls.Add(this.splitContainer2);
            this.tabPageServiceCenter.Controls.Add(this.panel2);
            this.tabPageServiceCenter.Location = new System.Drawing.Point(22, 4);
            this.tabPageServiceCenter.Name = "tabPageServiceCenter";
            this.tabPageServiceCenter.Size = new System.Drawing.Size(933, 574);
            this.tabPageServiceCenter.TabIndex = 2;
            this.tabPageServiceCenter.Text = "服务中心";
            this.tabPageServiceCenter.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 67);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridService);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridCheck);
            this.splitContainer2.Panel2.Controls.Add(this.panel3);
            this.splitContainer2.Size = new System.Drawing.Size(933, 507);
            this.splitContainer2.SplitterDistance = 201;
            this.splitContainer2.TabIndex = 4;
            // 
            // gridService
            // 
            this.gridService.AllowUserToAddRows = false;
            this.gridService.AllowUserToDeleteRows = false;
            this.gridService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridService.Location = new System.Drawing.Point(0, 0);
            this.gridService.Name = "gridService";
            this.gridService.ReadOnly = true;
            this.gridService.RowTemplate.Height = 23;
            this.gridService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridService.Size = new System.Drawing.Size(933, 201);
            this.gridService.TabIndex = 4;
            this.gridService.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridService_CellClick);
            // 
            // gridCheck
            // 
            this.gridCheck.AllowUserToAddRows = false;
            this.gridCheck.AllowUserToDeleteRows = false;
            this.gridCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCheck.Location = new System.Drawing.Point(0, 65);
            this.gridCheck.Name = "gridCheck";
            this.gridCheck.ReadOnly = true;
            this.gridCheck.RowTemplate.Height = 23;
            this.gridCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCheck.Size = new System.Drawing.Size(933, 237);
            this.gridCheck.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCheckDelete);
            this.panel3.Controls.Add(this.btnCheckModify);
            this.panel3.Controls.Add(this.btnCheckAdd);
            this.panel3.Controls.Add(this.comCheckMethod);
            this.panel3.Controls.Add(this.txbCheckTimeout);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txbCheckInterval);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txbCheckHttp);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txbCheckName);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txbCheckID);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(933, 65);
            this.panel3.TabIndex = 3;
            // 
            // btnCheckDelete
            // 
            this.btnCheckDelete.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCheckDelete.ImageIndex = 1;
            this.btnCheckDelete.ImageList = this.imageList1;
            this.btnCheckDelete.Location = new System.Drawing.Point(823, 32);
            this.btnCheckDelete.Name = "btnCheckDelete";
            this.btnCheckDelete.Size = new System.Drawing.Size(100, 28);
            this.btnCheckDelete.TabIndex = 17;
            this.btnCheckDelete.Text = "删除";
            this.btnCheckDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckDelete.UseVisualStyleBackColor = false;
            this.btnCheckDelete.Click += new System.EventHandler(this.btnCheckDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Add.png");
            this.imageList1.Images.SetKeyName(1, "Delete.png");
            this.imageList1.Images.SetKeyName(2, "Modify.png");
            this.imageList1.Images.SetKeyName(3, "Query.png");
            // 
            // btnCheckModify
            // 
            this.btnCheckModify.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCheckModify.ImageIndex = 2;
            this.btnCheckModify.ImageList = this.imageList1;
            this.btnCheckModify.Location = new System.Drawing.Point(720, 32);
            this.btnCheckModify.Name = "btnCheckModify";
            this.btnCheckModify.Size = new System.Drawing.Size(100, 28);
            this.btnCheckModify.TabIndex = 16;
            this.btnCheckModify.Text = "修改";
            this.btnCheckModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckModify.UseVisualStyleBackColor = false;
            this.btnCheckModify.Click += new System.EventHandler(this.btnCheckModify_Click);
            // 
            // btnCheckAdd
            // 
            this.btnCheckAdd.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCheckAdd.ImageIndex = 0;
            this.btnCheckAdd.ImageList = this.imageList1;
            this.btnCheckAdd.Location = new System.Drawing.Point(617, 32);
            this.btnCheckAdd.Name = "btnCheckAdd";
            this.btnCheckAdd.Size = new System.Drawing.Size(100, 28);
            this.btnCheckAdd.TabIndex = 14;
            this.btnCheckAdd.Text = "添加";
            this.btnCheckAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckAdd.UseVisualStyleBackColor = false;
            this.btnCheckAdd.Click += new System.EventHandler(this.btnCheckAdd_Click);
            // 
            // comCheckMethod
            // 
            this.comCheckMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCheckMethod.FormattingEnabled = true;
            this.comCheckMethod.Items.AddRange(new object[] {
            "Get",
            "Post",
            "Put",
            "Delete"});
            this.comCheckMethod.Location = new System.Drawing.Point(747, 6);
            this.comCheckMethod.Name = "comCheckMethod";
            this.comCheckMethod.Size = new System.Drawing.Size(175, 20);
            this.comCheckMethod.TabIndex = 12;
            // 
            // txbCheckTimeout
            // 
            this.txbCheckTimeout.Location = new System.Drawing.Point(300, 36);
            this.txbCheckTimeout.Name = "txbCheckTimeout";
            this.txbCheckTimeout.Size = new System.Drawing.Size(174, 21);
            this.txbCheckTimeout.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(265, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 10;
            this.label14.Text = "超时：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(712, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "方式：";
            // 
            // txbCheckInterval
            // 
            this.txbCheckInterval.Location = new System.Drawing.Point(54, 36);
            this.txbCheckInterval.Name = "txbCheckInterval";
            this.txbCheckInterval.Size = new System.Drawing.Size(174, 21);
            this.txbCheckInterval.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "间隔：";
            // 
            // txbCheckHttp
            // 
            this.txbCheckHttp.Location = new System.Drawing.Point(516, 6);
            this.txbCheckHttp.Name = "txbCheckHttp";
            this.txbCheckHttp.Size = new System.Drawing.Size(174, 21);
            this.txbCheckHttp.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(482, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "http：";
            // 
            // txbCheckName
            // 
            this.txbCheckName.Location = new System.Drawing.Point(300, 6);
            this.txbCheckName.Name = "txbCheckName";
            this.txbCheckName.Size = new System.Drawing.Size(174, 21);
            this.txbCheckName.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "检查名称：";
            // 
            // txbCheckID
            // 
            this.txbCheckID.Location = new System.Drawing.Point(54, 6);
            this.txbCheckID.Name = "txbCheckID";
            this.txbCheckID.Size = new System.Drawing.Size(174, 21);
            this.txbCheckID.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "检查ID：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnServiceDelete);
            this.panel2.Controls.Add(this.btnServiceModify);
            this.panel2.Controls.Add(this.btnServiceQuery);
            this.panel2.Controls.Add(this.btnServiceAdd);
            this.panel2.Controls.Add(this.txbServiceTag);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txbServicePort);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txbServiceIP);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txbSeviceName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txbServiceID);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 67);
            this.panel2.TabIndex = 2;
            // 
            // btnServiceDelete
            // 
            this.btnServiceDelete.Font = new System.Drawing.Font("宋体", 9F);
            this.btnServiceDelete.ImageIndex = 1;
            this.btnServiceDelete.ImageList = this.imageList1;
            this.btnServiceDelete.Location = new System.Drawing.Point(821, 33);
            this.btnServiceDelete.Name = "btnServiceDelete";
            this.btnServiceDelete.Size = new System.Drawing.Size(100, 28);
            this.btnServiceDelete.TabIndex = 13;
            this.btnServiceDelete.Text = "删除";
            this.btnServiceDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnServiceDelete.UseVisualStyleBackColor = false;
            this.btnServiceDelete.Click += new System.EventHandler(this.btnServiceDelete_Click);
            // 
            // btnServiceModify
            // 
            this.btnServiceModify.Font = new System.Drawing.Font("宋体", 9F);
            this.btnServiceModify.ImageIndex = 2;
            this.btnServiceModify.ImageList = this.imageList1;
            this.btnServiceModify.Location = new System.Drawing.Point(719, 33);
            this.btnServiceModify.Name = "btnServiceModify";
            this.btnServiceModify.Size = new System.Drawing.Size(100, 28);
            this.btnServiceModify.TabIndex = 12;
            this.btnServiceModify.Text = "修改";
            this.btnServiceModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnServiceModify.UseVisualStyleBackColor = false;
            this.btnServiceModify.Click += new System.EventHandler(this.btnServiceModify_Click);
            // 
            // btnServiceQuery
            // 
            this.btnServiceQuery.Font = new System.Drawing.Font("宋体", 9F);
            this.btnServiceQuery.ImageIndex = 3;
            this.btnServiceQuery.ImageList = this.imageList1;
            this.btnServiceQuery.Location = new System.Drawing.Point(515, 33);
            this.btnServiceQuery.Name = "btnServiceQuery";
            this.btnServiceQuery.Size = new System.Drawing.Size(100, 28);
            this.btnServiceQuery.TabIndex = 11;
            this.btnServiceQuery.Text = "查询";
            this.btnServiceQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnServiceQuery.UseVisualStyleBackColor = true;
            this.btnServiceQuery.Click += new System.EventHandler(this.btnServiceQuery_Click);
            // 
            // btnServiceAdd
            // 
            this.btnServiceAdd.Font = new System.Drawing.Font("宋体", 9F);
            this.btnServiceAdd.ImageIndex = 0;
            this.btnServiceAdd.ImageList = this.imageList1;
            this.btnServiceAdd.Location = new System.Drawing.Point(617, 33);
            this.btnServiceAdd.Name = "btnServiceAdd";
            this.btnServiceAdd.Size = new System.Drawing.Size(100, 28);
            this.btnServiceAdd.TabIndex = 10;
            this.btnServiceAdd.Text = "添加";
            this.btnServiceAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnServiceAdd.UseVisualStyleBackColor = false;
            this.btnServiceAdd.Click += new System.EventHandler(this.btnServiceAdd_Click);
            // 
            // txbServiceTag
            // 
            this.txbServiceTag.Location = new System.Drawing.Point(54, 37);
            this.txbServiceTag.Name = "txbServiceTag";
            this.txbServiceTag.Size = new System.Drawing.Size(420, 21);
            this.txbServiceTag.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "标签：";
            // 
            // txbServicePort
            // 
            this.txbServicePort.Location = new System.Drawing.Point(747, 7);
            this.txbServicePort.Name = "txbServicePort";
            this.txbServicePort.Size = new System.Drawing.Size(174, 21);
            this.txbServicePort.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(712, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "端口：";
            // 
            // txbServiceIP
            // 
            this.txbServiceIP.Location = new System.Drawing.Point(516, 7);
            this.txbServiceIP.Name = "txbServiceIP";
            this.txbServiceIP.Size = new System.Drawing.Size(174, 21);
            this.txbServiceIP.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(494, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "IP：";
            // 
            // txbSeviceName
            // 
            this.txbSeviceName.Location = new System.Drawing.Point(300, 7);
            this.txbSeviceName.Name = "txbSeviceName";
            this.txbSeviceName.Size = new System.Drawing.Size(174, 21);
            this.txbSeviceName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "服务名称：";
            // 
            // txbServiceID
            // 
            this.txbServiceID.Location = new System.Drawing.Point(55, 7);
            this.txbServiceID.Name = "txbServiceID";
            this.txbServiceID.Size = new System.Drawing.Size(174, 21);
            this.txbServiceID.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "服务ID：";
            // 
            // tabPageCluster
            // 
            this.tabPageCluster.Controls.Add(this.gridRaft);
            this.tabPageCluster.Controls.Add(this.panel4);
            this.tabPageCluster.Location = new System.Drawing.Point(22, 4);
            this.tabPageCluster.Name = "tabPageCluster";
            this.tabPageCluster.Size = new System.Drawing.Size(933, 574);
            this.tabPageCluster.TabIndex = 3;
            this.tabPageCluster.Text = "集群管理";
            this.tabPageCluster.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnInsertCluster);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.txbClusterIP);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(933, 42);
            this.panel4.TabIndex = 0;
            // 
            // txbClusterIP
            // 
            this.txbClusterIP.Location = new System.Drawing.Point(92, 9);
            this.txbClusterIP.Name = "txbClusterIP";
            this.txbClusterIP.Size = new System.Drawing.Size(455, 21);
            this.txbClusterIP.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "加入集群IP：";
            // 
            // btnInsertCluster
            // 
            this.btnInsertCluster.Font = new System.Drawing.Font("宋体", 9F);
            this.btnInsertCluster.ImageIndex = 0;
            this.btnInsertCluster.ImageList = this.imageList1;
            this.btnInsertCluster.Location = new System.Drawing.Point(553, 5);
            this.btnInsertCluster.Name = "btnInsertCluster";
            this.btnInsertCluster.Size = new System.Drawing.Size(100, 28);
            this.btnInsertCluster.TabIndex = 15;
            this.btnInsertCluster.Text = "加入";
            this.btnInsertCluster.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsertCluster.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInsertCluster.UseVisualStyleBackColor = false;
            this.btnInsertCluster.Click += new System.EventHandler(this.btnInsertCluster_Click);
            // 
            // gridRaft
            // 
            this.gridRaft.AllowUserToAddRows = false;
            this.gridRaft.AllowUserToDeleteRows = false;
            this.gridRaft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRaft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRaft.Location = new System.Drawing.Point(0, 42);
            this.gridRaft.Name = "gridRaft";
            this.gridRaft.ReadOnly = true;
            this.gridRaft.RowTemplate.Height = 23;
            this.gridRaft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRaft.Size = new System.Drawing.Size(933, 532);
            this.gridRaft.TabIndex = 5;
            // 
            // frmMainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(959, 582);
            this.Controls.Add(this.tabC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmMainPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务控制面板";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMainPanel_Load);
            this.Resize += new System.EventHandler(this.frmMainPanel_Resize);
            this.tabC.ResumeLayout(false);
            this.tabPageConfigCenter.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPageServiceCenter.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPageCluster.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRaft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabC;
        private System.Windows.Forms.TabPage tabPageStartUp;
        private System.Windows.Forms.TabPage tabPageConfigCenter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txbValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSava;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ImageList imgListBtns;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listKV;
        private System.Windows.Forms.TabPage tabPageServiceCenter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbServicePort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbServiceIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbSeviceName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbServiceID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbServiceTag;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView gridService;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbCheckTimeout;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbCheckInterval;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbCheckHttp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbCheckName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbCheckID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnServiceDelete;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnServiceModify;
        private System.Windows.Forms.Button btnServiceQuery;
        private System.Windows.Forms.Button btnServiceAdd;
        private System.Windows.Forms.DataGridView gridCheck;
        private System.Windows.Forms.Button btnCheckDelete;
        private System.Windows.Forms.Button btnCheckModify;
        private System.Windows.Forms.Button btnCheckAdd;
        private System.Windows.Forms.ComboBox comCheckMethod;
        private System.Windows.Forms.TabPage tabPageCluster;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnInsertCluster;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbClusterIP;
        private System.Windows.Forms.DataGridView gridRaft;
    }
}

