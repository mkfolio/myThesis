namespace rfid2._2
{
    partial class Form1
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
            this.AutoOpenCOM = new System.Windows.Forms.Button();
            this.ClosePort = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ParameterTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QueryTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ListView1_EPC = new System.Windows.Forms.ListView();
            this.listViewCol_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCol_Times = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QueryTag = new System.Windows.Forms.Button();
            this.Timer_Test_ = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.ParameterTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.QueryTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoOpenCOM
            // 
            this.AutoOpenCOM.Location = new System.Drawing.Point(6, 19);
            this.AutoOpenCOM.Name = "AutoOpenCOM";
            this.AutoOpenCOM.Size = new System.Drawing.Size(75, 23);
            this.AutoOpenCOM.TabIndex = 0;
            this.AutoOpenCOM.Text = "AutoOpen";
            this.AutoOpenCOM.UseVisualStyleBackColor = true;
            this.AutoOpenCOM.Click += new System.EventHandler(this.AutoOpenCOM_Click);
            // 
            // ClosePort
            // 
            this.ClosePort.Location = new System.Drawing.Point(6, 48);
            this.ClosePort.Name = "ClosePort";
            this.ClosePort.Size = new System.Drawing.Size(75, 23);
            this.ClosePort.TabIndex = 1;
            this.ClosePort.Text = "Close Port";
            this.ClosePort.UseVisualStyleBackColor = true;
            this.ClosePort.Click += new System.EventHandler(this.ClosePort_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ParameterTab);
            this.tabControl1.Controls.Add(this.QueryTab);
            this.tabControl1.Location = new System.Drawing.Point(-2, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(347, 313);
            this.tabControl1.TabIndex = 2;
            // 
            // ParameterTab
            // 
            this.ParameterTab.Controls.Add(this.groupBox1);
            this.ParameterTab.Location = new System.Drawing.Point(4, 22);
            this.ParameterTab.Name = "ParameterTab";
            this.ParameterTab.Padding = new System.Windows.Forms.Padding(3);
            this.ParameterTab.Size = new System.Drawing.Size(339, 287);
            this.ParameterTab.TabIndex = 0;
            this.ParameterTab.Text = "Parameter";
            this.ParameterTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AutoOpenCOM);
            this.groupBox1.Controls.Add(this.ClosePort);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication";
            // 
            // QueryTab
            // 
            this.QueryTab.Controls.Add(this.groupBox2);
            this.QueryTab.Controls.Add(this.QueryTag);
            this.QueryTab.Location = new System.Drawing.Point(4, 22);
            this.QueryTab.Name = "QueryTab";
            this.QueryTab.Padding = new System.Windows.Forms.Padding(3);
            this.QueryTab.Size = new System.Drawing.Size(339, 287);
            this.QueryTab.TabIndex = 1;
            this.QueryTab.Text = "Query";
            this.QueryTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ListView1_EPC);
            this.groupBox2.Location = new System.Drawing.Point(10, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 189);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // ListView1_EPC
            // 
            this.ListView1_EPC.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.ListView1_EPC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListView1_EPC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewCol_ID,
            this.listViewCol_Times});
            this.ListView1_EPC.FullRowSelect = true;
            this.ListView1_EPC.GridLines = true;
            this.ListView1_EPC.Location = new System.Drawing.Point(6, 19);
            this.ListView1_EPC.Name = "ListView1_EPC";
            this.ListView1_EPC.Size = new System.Drawing.Size(305, 164);
            this.ListView1_EPC.TabIndex = 1;
            this.ListView1_EPC.UseCompatibleStateImageBehavior = false;
            this.ListView1_EPC.View = System.Windows.Forms.View.Details;
            // 
            // listViewCol_ID
            // 
            this.listViewCol_ID.Text = "ID";
            this.listViewCol_ID.Width = 249;
            // 
            // listViewCol_Times
            // 
            this.listViewCol_Times.Text = "Times";
            // 
            // QueryTag
            // 
            this.QueryTag.Location = new System.Drawing.Point(246, 19);
            this.QueryTag.Name = "QueryTag";
            this.QueryTag.Size = new System.Drawing.Size(75, 23);
            this.QueryTag.TabIndex = 0;
            this.QueryTag.Text = "Query Tag";
            this.QueryTag.UseVisualStyleBackColor = true;
            this.QueryTag.Click += new System.EventHandler(this.QueryTag_Click);
            // 
            // Timer_Test_
            // 
            this.Timer_Test_.Tick += new System.EventHandler(this.Timer_Test__Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 308);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "UHF RFID";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.ParameterTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.QueryTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AutoOpenCOM;
        private System.Windows.Forms.Button ClosePort;
        private System.Windows.Forms.TabPage QueryTab;
        private System.Windows.Forms.Button QueryTag;
        private System.Windows.Forms.TabPage ParameterTab;
        private System.Windows.Forms.GroupBox groupBox1;
        protected internal System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView ListView1_EPC;
        private System.Windows.Forms.ColumnHeader listViewCol_ID;
        private System.Windows.Forms.ColumnHeader listViewCol_Times;
        private System.Windows.Forms.Timer Timer_Test_;
    }
}

