namespace tiff2ecw
{
    partial class dbproperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dbproperty));
            this.dbHost = new System.Windows.Forms.TextBox();
            this.dbUsername = new System.Windows.Forms.TextBox();
            this.dbPassword = new System.Windows.Forms.TextBox();
            this.dbName = new System.Windows.Forms.TextBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dbInstance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dbPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.imaginePathLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.thumbnailSizeTB = new System.Windows.Forms.TextBox();
            this.thumbnailSizeBtn = new System.Windows.Forms.Button();
            this.setACLDBBtn = new System.Windows.Forms.Button();
            this.acldbpathLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dbHost
            // 
            this.dbHost.Location = new System.Drawing.Point(69, 25);
            this.dbHost.Name = "dbHost";
            this.dbHost.Size = new System.Drawing.Size(80, 21);
            this.dbHost.TabIndex = 0;
            // 
            // dbUsername
            // 
            this.dbUsername.Location = new System.Drawing.Point(69, 73);
            this.dbUsername.Name = "dbUsername";
            this.dbUsername.Size = new System.Drawing.Size(203, 21);
            this.dbUsername.TabIndex = 1;
            // 
            // dbPassword
            // 
            this.dbPassword.Location = new System.Drawing.Point(69, 97);
            this.dbPassword.Name = "dbPassword";
            this.dbPassword.Size = new System.Drawing.Size(203, 21);
            this.dbPassword.TabIndex = 2;
            // 
            // dbName
            // 
            this.dbName.Location = new System.Drawing.Point(69, 121);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(203, 21);
            this.dbName.TabIndex = 3;
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(12, 145);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(116, 23);
            this.testBtn.TabIndex = 4;
            this.testBtn.Text = "Test Connection";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Enabled = false;
            this.submitBtn.Location = new System.Drawing.Point(191, 145);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(81, 23);
            this.submitBtn.TabIndex = 5;
            this.submitBtn.Text = "Save It";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Host";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Database";
            // 
            // dbInstance
            // 
            this.dbInstance.Location = new System.Drawing.Point(69, 49);
            this.dbInstance.Name = "dbInstance";
            this.dbInstance.Size = new System.Drawing.Size(203, 21);
            this.dbInstance.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Instance";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dbPort
            // 
            this.dbPort.Location = new System.Drawing.Point(192, 25);
            this.dbPort.Name = "dbPort";
            this.dbPort.Size = new System.Drawing.Size(80, 21);
            this.dbPort.TabIndex = 13;
            this.dbPort.Text = "1433";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "port";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Set Imagine 2014 Path";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imaginePathLabel
            // 
            this.imaginePathLabel.AutoSize = true;
            this.imaginePathLabel.Location = new System.Drawing.Point(9, 257);
            this.imaginePathLabel.Name = "imaginePathLabel";
            this.imaginePathLabel.Size = new System.Drawing.Size(281, 12);
            this.imaginePathLabel.TabIndex = 16;
            this.imaginePathLabel.Text = "C:\\Program Files\\Intergraph\\ERDAS IMAGINE 2014";
            // 
            // thumbnailSizeTB
            // 
            this.thumbnailSizeTB.Location = new System.Drawing.Point(11, 294);
            this.thumbnailSizeTB.Name = "thumbnailSizeTB";
            this.thumbnailSizeTB.Size = new System.Drawing.Size(81, 21);
            this.thumbnailSizeTB.TabIndex = 17;
            this.thumbnailSizeTB.Text = "150";
            // 
            // thumbnailSizeBtn
            // 
            this.thumbnailSizeBtn.Location = new System.Drawing.Point(98, 292);
            this.thumbnailSizeBtn.Name = "thumbnailSizeBtn";
            this.thumbnailSizeBtn.Size = new System.Drawing.Size(157, 23);
            this.thumbnailSizeBtn.TabIndex = 18;
            this.thumbnailSizeBtn.Text = "Set Thumnail Size";
            this.thumbnailSizeBtn.UseVisualStyleBackColor = true;
            // 
            // setACLDBBtn
            // 
            this.setACLDBBtn.Location = new System.Drawing.Point(14, 174);
            this.setACLDBBtn.Name = "setACLDBBtn";
            this.setACLDBBtn.Size = new System.Drawing.Size(114, 23);
            this.setACLDBBtn.TabIndex = 19;
            this.setACLDBBtn.Text = "Set ACL database";
            this.setACLDBBtn.UseVisualStyleBackColor = true;
            this.setACLDBBtn.Click += new System.EventHandler(this.setACLDBBtn_Click);
            // 
            // acldbpathLabel
            // 
            this.acldbpathLabel.AutoSize = true;
            this.acldbpathLabel.Location = new System.Drawing.Point(12, 200);
            this.acldbpathLabel.Name = "acldbpathLabel";
            this.acldbpathLabel.Size = new System.Drawing.Size(0, 12);
            this.acldbpathLabel.TabIndex = 20;
            // 
            // dbproperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 327);
            this.Controls.Add(this.acldbpathLabel);
            this.Controls.Add(this.setACLDBBtn);
            this.Controls.Add(this.thumbnailSizeBtn);
            this.Controls.Add(this.thumbnailSizeTB);
            this.Controls.Add(this.imaginePathLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dbPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dbInstance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.dbName);
            this.Controls.Add(this.dbPassword);
            this.Controls.Add(this.dbUsername);
            this.Controls.Add(this.dbHost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dbproperty";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.dbproperty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dbHost;
        private System.Windows.Forms.TextBox dbUsername;
        private System.Windows.Forms.TextBox dbPassword;
        private System.Windows.Forms.TextBox dbName;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dbInstance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dbPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label imaginePathLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox thumbnailSizeTB;
        private System.Windows.Forms.Button thumbnailSizeBtn;
        private System.Windows.Forms.Button setACLDBBtn;
        private System.Windows.Forms.Label acldbpathLabel;
    }
}