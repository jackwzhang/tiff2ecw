namespace tiff2ecw
{
    partial class logReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logReport));
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logsDatagridview = new System.Windows.Forms.DataGridView();
            this.showlogsBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.exportByNameBtn = new System.Windows.Forms.Button();
            this.exportByOfficeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logsDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Location = new System.Drawing.Point(70, 39);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(127, 21);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Location = new System.Drawing.Point(69, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "To:";
            // 
            // logsDatagridview
            // 
            this.logsDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logsDatagridview.Location = new System.Drawing.Point(40, 169);
            this.logsDatagridview.Name = "logsDatagridview";
            this.logsDatagridview.RowTemplate.Height = 23;
            this.logsDatagridview.Size = new System.Drawing.Size(1028, 495);
            this.logsDatagridview.TabIndex = 5;
            this.logsDatagridview.Visible = false;
            // 
            // showlogsBtn
            // 
            this.showlogsBtn.Location = new System.Drawing.Point(30, 66);
            this.showlogsBtn.Name = "showlogsBtn";
            this.showlogsBtn.Size = new System.Drawing.Size(167, 34);
            this.showlogsBtn.TabIndex = 6;
            this.showlogsBtn.Text = "Load Logs";
            this.showlogsBtn.UseVisualStyleBackColor = true;
            this.showlogsBtn.Click += new System.EventHandler(this.showlogsBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Enabled = false;
            this.exportBtn.Location = new System.Drawing.Point(235, 17);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(92, 89);
            this.exportBtn.TabIndex = 7;
            this.exportBtn.Text = "Export to Excel";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // exportByNameBtn
            // 
            this.exportByNameBtn.Enabled = false;
            this.exportByNameBtn.Location = new System.Drawing.Point(434, 17);
            this.exportByNameBtn.Name = "exportByNameBtn";
            this.exportByNameBtn.Size = new System.Drawing.Size(90, 89);
            this.exportByNameBtn.TabIndex = 8;
            this.exportByNameBtn.Text = "Export By Names";
            this.exportByNameBtn.UseVisualStyleBackColor = true;
            this.exportByNameBtn.Click += new System.EventHandler(this.exportByNameBtn_Click);
            // 
            // exportByOfficeBtn
            // 
            this.exportByOfficeBtn.Enabled = false;
            this.exportByOfficeBtn.Location = new System.Drawing.Point(333, 17);
            this.exportByOfficeBtn.Name = "exportByOfficeBtn";
            this.exportByOfficeBtn.Size = new System.Drawing.Size(95, 88);
            this.exportByOfficeBtn.TabIndex = 9;
            this.exportByOfficeBtn.Text = "Export By Offices";
            this.exportByOfficeBtn.UseVisualStyleBackColor = true;
            this.exportByOfficeBtn.Click += new System.EventHandler(this.exportByOfficeBtn_Click);
            // 
            // logReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 123);
            this.Controls.Add(this.exportByOfficeBtn);
            this.Controls.Add(this.exportByNameBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.showlogsBtn);
            this.Controls.Add(this.logsDatagridview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "logReport";
            this.Text = "Generate System Log";
            ((System.ComponentModel.ISupportInitialize)(this.logsDatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView logsDatagridview;
        private System.Windows.Forms.Button showlogsBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button exportByNameBtn;
        private System.Windows.Forms.Button exportByOfficeBtn;
    }
}