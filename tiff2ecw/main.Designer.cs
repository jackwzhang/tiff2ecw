namespace tiff2ecw
{
    partial class Tiff2ECW
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tiff2ECW));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.createTFWBtun = new System.Windows.Forms.Button();
            this.selectInputBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gridSelectData = new System.Windows.Forms.DataGridView();
            this.hasTWF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rotation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PixSizeX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RotY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RotX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PixSizeY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ULX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ULY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queryDatabaseBtn = new System.Windows.Forms.Button();
            this.selectInputFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.generateBatBtn = new System.Windows.Forms.Button();
            this.setOutputBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gsdbox = new System.Windows.Forms.TextBox();
            this.tiffListBox = new System.Windows.Forms.ListBox();
            this.marginbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.photointerpComboBox = new System.Windows.Forms.ComboBox();
            this.runScriptBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.runNowBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.runAtBtn = new System.Windows.Forms.Button();
            this.timeM = new System.Windows.Forms.NumericUpDown();
            this.timeH = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v105ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateThumbnails = new System.Windows.Forms.Button();
            this.updateECWBtn = new System.Windows.Forms.Button();
            this.updateMAPDBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectData)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeH)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createTFWBtun
            // 
            this.createTFWBtun.Enabled = false;
            this.createTFWBtun.Location = new System.Drawing.Point(338, 28);
            this.createTFWBtun.Name = "createTFWBtun";
            this.createTFWBtun.Size = new System.Drawing.Size(75, 23);
            this.createTFWBtun.TabIndex = 0;
            this.createTFWBtun.Text = "Create TWF";
            this.createTFWBtun.UseVisualStyleBackColor = true;
            this.createTFWBtun.Click += new System.EventHandler(this.button2_Click);
            // 
            // selectInputBtn
            // 
            this.selectInputBtn.Location = new System.Drawing.Point(16, 28);
            this.selectInputBtn.Name = "selectInputBtn";
            this.selectInputBtn.Size = new System.Drawing.Size(75, 23);
            this.selectInputBtn.TabIndex = 7;
            this.selectInputBtn.Text = "Select Input";
            this.selectInputBtn.UseVisualStyleBackColor = true;
            this.selectInputBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Welcome";
            // 
            // gridSelectData
            // 
            this.gridSelectData.AllowUserToAddRows = false;
            this.gridSelectData.AllowUserToOrderColumns = true;
            this.gridSelectData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSelectData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hasTWF,
            this.Scale,
            this.GSD,
            this.Rotation,
            this.name,
            this.PixSizeX,
            this.RotY,
            this.RotX,
            this.PixSizeY,
            this.ULX,
            this.ULY});
            this.gridSelectData.Location = new System.Drawing.Point(16, 68);
            this.gridSelectData.MultiSelect = false;
            this.gridSelectData.Name = "gridSelectData";
            this.gridSelectData.ReadOnly = true;
            this.gridSelectData.RowHeadersWidth = 25;
            this.gridSelectData.Size = new System.Drawing.Size(1084, 348);
            this.gridSelectData.TabIndex = 11;
            // 
            // hasTWF
            // 
            this.hasTWF.HeaderText = "TWF";
            this.hasTWF.Name = "hasTWF";
            this.hasTWF.ReadOnly = true;
            this.hasTWF.Width = 5;
            // 
            // Scale
            // 
            this.Scale.HeaderText = "Scale";
            this.Scale.Name = "Scale";
            this.Scale.ReadOnly = true;
            // 
            // GSD
            // 
            this.GSD.HeaderText = "GSD";
            this.GSD.Name = "GSD";
            this.GSD.ReadOnly = true;
            // 
            // Rotation
            // 
            this.Rotation.HeaderText = "Rotation";
            this.Rotation.Name = "Rotation";
            this.Rotation.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "File Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // PixSizeX
            // 
            this.PixSizeX.HeaderText = "PixelSizeX";
            this.PixSizeX.Name = "PixSizeX";
            this.PixSizeX.ReadOnly = true;
            // 
            // RotY
            // 
            this.RotY.HeaderText = "RotationY";
            this.RotY.Name = "RotY";
            this.RotY.ReadOnly = true;
            // 
            // RotX
            // 
            this.RotX.HeaderText = "RotationX";
            this.RotX.Name = "RotX";
            this.RotX.ReadOnly = true;
            // 
            // PixSizeY
            // 
            this.PixSizeY.HeaderText = "PixelSizeY";
            this.PixSizeY.Name = "PixSizeY";
            this.PixSizeY.ReadOnly = true;
            // 
            // ULX
            // 
            this.ULX.HeaderText = "ULX";
            this.ULX.Name = "ULX";
            this.ULX.ReadOnly = true;
            // 
            // ULY
            // 
            this.ULY.HeaderText = "ULY";
            this.ULY.Name = "ULY";
            this.ULY.ReadOnly = true;
            // 
            // queryDatabaseBtn
            // 
            this.queryDatabaseBtn.Enabled = false;
            this.queryDatabaseBtn.Location = new System.Drawing.Point(97, 28);
            this.queryDatabaseBtn.Name = "queryDatabaseBtn";
            this.queryDatabaseBtn.Size = new System.Drawing.Size(75, 23);
            this.queryDatabaseBtn.TabIndex = 12;
            this.queryDatabaseBtn.Text = "QueryDB";
            this.queryDatabaseBtn.UseVisualStyleBackColor = true;
            this.queryDatabaseBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // generateBatBtn
            // 
            this.generateBatBtn.Enabled = false;
            this.generateBatBtn.Location = new System.Drawing.Point(740, 24);
            this.generateBatBtn.Name = "generateBatBtn";
            this.generateBatBtn.Size = new System.Drawing.Size(62, 38);
            this.generateBatBtn.TabIndex = 16;
            this.generateBatBtn.Text = "Save Script";
            this.generateBatBtn.UseVisualStyleBackColor = true;
            this.generateBatBtn.Click += new System.EventHandler(this.button7_Click);
            // 
            // setOutputBtn
            // 
            this.setOutputBtn.Enabled = false;
            this.setOutputBtn.Location = new System.Drawing.Point(506, 29);
            this.setOutputBtn.Name = "setOutputBtn";
            this.setOutputBtn.Size = new System.Drawing.Size(75, 23);
            this.setOutputBtn.TabIndex = 8;
            this.setOutputBtn.Text = "Set Output";
            this.setOutputBtn.UseVisualStyleBackColor = true;
            this.setOutputBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // runBtn
            // 
            this.runBtn.Enabled = false;
            this.runBtn.Location = new System.Drawing.Point(1371, 183);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(62, 38);
            this.runBtn.TabIndex = 17;
            this.runBtn.Text = "Process Selected";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Visible = false;
            this.runBtn.Click += new System.EventHandler(this.button8_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(71, 428);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(359, 23);
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Visible = false;
            // 
            // gsdbox
            // 
            this.gsdbox.Location = new System.Drawing.Point(209, 29);
            this.gsdbox.Name = "gsdbox";
            this.gsdbox.Size = new System.Drawing.Size(30, 20);
            this.gsdbox.TabIndex = 21;
            this.gsdbox.Text = "12.5";
            // 
            // tiffListBox
            // 
            this.tiffListBox.FormattingEnabled = true;
            this.tiffListBox.HorizontalScrollbar = true;
            this.tiffListBox.Location = new System.Drawing.Point(1106, 33);
            this.tiffListBox.Name = "tiffListBox";
            this.tiffListBox.ScrollAlwaysVisible = true;
            this.tiffListBox.Size = new System.Drawing.Size(331, 420);
            this.tiffListBox.TabIndex = 22;
            // 
            // marginbox
            // 
            this.marginbox.Location = new System.Drawing.Point(294, 29);
            this.marginbox.Name = "marginbox";
            this.marginbox.Size = new System.Drawing.Size(21, 20);
            this.marginbox.TabIndex = 23;
            this.marginbox.Text = "9";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Film";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "µ , Margin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "%";
            // 
            // photointerpComboBox
            // 
            this.photointerpComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.photointerpComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.photointerpComboBox.FormattingEnabled = true;
            this.photointerpComboBox.Items.AddRange(new object[] {
            "RGB",
            "GRAY"});
            this.photointerpComboBox.Location = new System.Drawing.Point(420, 28);
            this.photointerpComboBox.Name = "photointerpComboBox";
            this.photointerpComboBox.Size = new System.Drawing.Size(80, 21);
            this.photointerpComboBox.TabIndex = 27;
            this.photointerpComboBox.Tag = "";
            // 
            // runScriptBtn
            // 
            this.runScriptBtn.Enabled = false;
            this.runScriptBtn.Location = new System.Drawing.Point(1371, 217);
            this.runScriptBtn.Name = "runScriptBtn";
            this.runScriptBtn.Size = new System.Drawing.Size(62, 38);
            this.runScriptBtn.TabIndex = 28;
            this.runScriptBtn.Text = "Run Script";
            this.runScriptBtn.UseVisualStyleBackColor = true;
            this.runScriptBtn.Visible = false;
            this.runScriptBtn.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1237, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 127);
            this.tabControl1.TabIndex = 29;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.runNowBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 101);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Run Now";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // runNowBtn
            // 
            this.runNowBtn.Location = new System.Drawing.Point(43, 45);
            this.runNowBtn.Name = "runNowBtn";
            this.runNowBtn.Size = new System.Drawing.Size(113, 52);
            this.runNowBtn.TabIndex = 0;
            this.runNowBtn.Text = "Run Script Now";
            this.runNowBtn.UseVisualStyleBackColor = true;
            this.runNowBtn.Click += new System.EventHandler(this.runNowBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.runAtBtn);
            this.tabPage2.Controls.Add(this.timeM);
            this.tabPage2.Controls.Add(this.timeH);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 101);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pick Time";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = ":";
            // 
            // runAtBtn
            // 
            this.runAtBtn.Location = new System.Drawing.Point(32, 59);
            this.runAtBtn.Name = "runAtBtn";
            this.runAtBtn.Size = new System.Drawing.Size(93, 23);
            this.runAtBtn.TabIndex = 3;
            this.runAtBtn.Text = "Set Timer";
            this.runAtBtn.UseVisualStyleBackColor = true;
            this.runAtBtn.Click += new System.EventHandler(this.runAtBtn_Click);
            // 
            // timeM
            // 
            this.timeM.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.timeM.Location = new System.Drawing.Point(89, 30);
            this.timeM.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.timeM.Name = "timeM";
            this.timeM.Size = new System.Drawing.Size(36, 20);
            this.timeM.TabIndex = 2;
            // 
            // timeH
            // 
            this.timeH.Location = new System.Drawing.Point(32, 30);
            this.timeH.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.timeH.Name = "timeH";
            this.timeH.Size = new System.Drawing.Size(35, 20);
            this.timeH.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.systemLogToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1445, 25);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.fILEToolStripMenuItem.Text = "Settings";
            this.fILEToolStripMenuItem.Click += new System.EventHandler(this.fILEToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.v105ToolStripMenuItem,
            this.v11ToolStripMenuItem,
            this.testToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.aboutToolStripMenuItem.Text = "History";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // v105ToolStripMenuItem
            // 
            this.v105ToolStripMenuItem.Name = "v105ToolStripMenuItem";
            this.v105ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.v105ToolStripMenuItem.Text = "v1.0";
            this.v105ToolStripMenuItem.Click += new System.EventHandler(this.v105ToolStripMenuItem_Click);
            // 
            // v11ToolStripMenuItem
            // 
            this.v11ToolStripMenuItem.Name = "v11ToolStripMenuItem";
            this.v11ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.v11ToolStripMenuItem.Text = "v1.1";
            this.v11ToolStripMenuItem.Click += new System.EventHandler(this.v11ToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testToolStripMenuItem.Text = "v1.1.1";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // systemLogToolStripMenuItem
            // 
            this.systemLogToolStripMenuItem.Name = "systemLogToolStripMenuItem";
            this.systemLogToolStripMenuItem.Size = new System.Drawing.Size(87, 21);
            this.systemLogToolStripMenuItem.Text = "System Log";
            this.systemLogToolStripMenuItem.Click += new System.EventHandler(this.systemLogToolStripMenuItem_Click);
            // 
            // generateThumbnails
            // 
            this.generateThumbnails.Enabled = false;
            this.generateThumbnails.Location = new System.Drawing.Point(808, 25);
            this.generateThumbnails.Name = "generateThumbnails";
            this.generateThumbnails.Size = new System.Drawing.Size(73, 39);
            this.generateThumbnails.TabIndex = 31;
            this.generateThumbnails.Text = "Generate Thumbnail";
            this.generateThumbnails.UseVisualStyleBackColor = true;
            this.generateThumbnails.Click += new System.EventHandler(this.generateThumnail_Click);
            // 
            // updateECWBtn
            // 
            this.updateECWBtn.Location = new System.Drawing.Point(949, 25);
            this.updateECWBtn.Name = "updateECWBtn";
            this.updateECWBtn.Size = new System.Drawing.Size(56, 38);
            this.updateECWBtn.TabIndex = 32;
            this.updateECWBtn.Text = "register ECW";
            this.updateECWBtn.UseVisualStyleBackColor = true;
            this.updateECWBtn.Click += new System.EventHandler(this.updateDatabseBtn_Click);
            // 
            // updateMAPDBtn
            // 
            this.updateMAPDBtn.Location = new System.Drawing.Point(887, 25);
            this.updateMAPDBtn.Name = "updateMAPDBtn";
            this.updateMAPDBtn.Size = new System.Drawing.Size(56, 38);
            this.updateMAPDBtn.TabIndex = 33;
            this.updateMAPDBtn.Text = "Update MAPD";
            this.updateMAPDBtn.UseVisualStyleBackColor = true;
            this.updateMAPDBtn.Click += new System.EventHandler(this.updateMAPDBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(664, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 37);
            this.button2.TabIndex = 34;
            this.button2.Text = "JPEG Thumbnail";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_3);
            // 
            // Tiff2ECW
            // 
            this.ClientSize = new System.Drawing.Size(1445, 463);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.updateMAPDBtn);
            this.Controls.Add(this.updateECWBtn);
            this.Controls.Add(this.generateThumbnails);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.runScriptBtn);
            this.Controls.Add(this.photointerpComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.marginbox);
            this.Controls.Add(this.tiffListBox);
            this.Controls.Add(this.gsdbox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.generateBatBtn);
            this.Controls.Add(this.queryDatabaseBtn);
            this.Controls.Add(this.gridSelectData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.setOutputBtn);
            this.Controls.Add(this.selectInputBtn);
            this.Controls.Add(this.createTFWBtun);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Tiff2ECW";
            this.Text = "Tiff to ECW convertor V1.1.1 32bit";
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectData)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeH)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog chooseFolderDialog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button createTFWBtun;
        private System.Windows.Forms.Button selectInputBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView gridSelectData;
        private System.Windows.Forms.Button queryDatabaseBtn;
        private System.Windows.Forms.FolderBrowserDialog selectInputFolderDialog;
        private System.Windows.Forms.Button generateBatBtn;
        private System.Windows.Forms.Button setOutputBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox gsdbox;
        private System.Windows.Forms.ListBox tiffListBox;
        private System.Windows.Forms.TextBox marginbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasTWF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn GSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rotation;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PixSizeX;
        private System.Windows.Forms.DataGridViewTextBoxColumn RotY;
        private System.Windows.Forms.DataGridViewTextBoxColumn RotX;
        private System.Windows.Forms.DataGridViewTextBoxColumn PixSizeY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ULX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ULY;
        private System.Windows.Forms.ComboBox photointerpComboBox;
        private System.Windows.Forms.Button runScriptBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button runNowBtn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button runAtBtn;
        private System.Windows.Forms.NumericUpDown timeM;
        private System.Windows.Forms.NumericUpDown timeH;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v105ToolStripMenuItem;
        private System.Windows.Forms.Button generateThumbnails;
        private System.Windows.Forms.Button updateECWBtn;
        private System.Windows.Forms.Button updateMAPDBtn;
        private System.Windows.Forms.ToolStripMenuItem systemLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v11ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    }
}

