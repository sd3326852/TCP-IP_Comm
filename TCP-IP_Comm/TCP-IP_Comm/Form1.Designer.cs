namespace TCP_IP_Comm
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_LocalIP = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_RemoteIP = new System.Windows.Forms.TextBox();
            this.btn_StartListen = new System.Windows.Forms.Button();
            this.cb_ListLoopback = new System.Windows.Forms.CheckBox();
            this.nud_ListenerPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_SocketMode = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_ValidateString = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_CurrentCount = new System.Windows.Forms.Label();
            this.btn_SetCount = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_CountPeriod = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.文件保存路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fbd_CSVSave = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ListenerPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CountPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(595, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件保存路径ToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "退出";
            // 
            // cb_LocalIP
            // 
            this.cb_LocalIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_LocalIP.FormattingEnabled = true;
            this.cb_LocalIP.Location = new System.Drawing.Point(71, 20);
            this.cb_LocalIP.Name = "cb_LocalIP";
            this.cb_LocalIP.Size = new System.Drawing.Size(130, 20);
            this.cb_LocalIP.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_RemoteIP);
            this.groupBox1.Controls.Add(this.btn_StartListen);
            this.groupBox1.Controls.Add(this.cb_ListLoopback);
            this.groupBox1.Controls.Add(this.nud_ListenerPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_SocketMode);
            this.groupBox1.Controls.Add(this.cb_LocalIP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 81);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接参数";
            // 
            // tb_RemoteIP
            // 
            this.tb_RemoteIP.Location = new System.Drawing.Point(71, 46);
            this.tb_RemoteIP.Name = "tb_RemoteIP";
            this.tb_RemoteIP.Size = new System.Drawing.Size(130, 21);
            this.tb_RemoteIP.TabIndex = 10;
            this.tb_RemoteIP.Validated += new System.EventHandler(this.tb_RemoteIP_Validated);
            // 
            // btn_StartListen
            // 
            this.btn_StartListen.Location = new System.Drawing.Point(493, 18);
            this.btn_StartListen.Name = "btn_StartListen";
            this.btn_StartListen.Size = new System.Drawing.Size(75, 23);
            this.btn_StartListen.TabIndex = 9;
            this.btn_StartListen.Text = "连接";
            this.btn_StartListen.UseVisualStyleBackColor = true;
            // 
            // cb_ListLoopback
            // 
            this.cb_ListLoopback.AutoSize = true;
            this.cb_ListLoopback.Location = new System.Drawing.Point(393, 22);
            this.cb_ListLoopback.Name = "cb_ListLoopback";
            this.cb_ListLoopback.Size = new System.Drawing.Size(84, 16);
            this.cb_ListLoopback.TabIndex = 8;
            this.cb_ListLoopback.Text = "列出回环口";
            this.cb_ListLoopback.UseVisualStyleBackColor = true;
            // 
            // nud_ListenerPort
            // 
            this.nud_ListenerPort.Location = new System.Drawing.Point(272, 19);
            this.nud_ListenerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_ListenerPort.Name = "nud_ListenerPort";
            this.nud_ListenerPort.Size = new System.Drawing.Size(92, 21);
            this.nud_ListenerPort.TabIndex = 7;
            this.nud_ListenerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "端口号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "远端IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "工作模式";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "本地IP";
            // 
            // cb_SocketMode
            // 
            this.cb_SocketMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SocketMode.FormattingEnabled = true;
            this.cb_SocketMode.Items.AddRange(new object[] {
            "Server",
            "Client"});
            this.cb_SocketMode.Location = new System.Drawing.Point(272, 46);
            this.cb_SocketMode.Name = "cb_SocketMode";
            this.cb_SocketMode.Size = new System.Drawing.Size(92, 20);
            this.cb_SocketMode.TabIndex = 4;
            this.cb_SocketMode.SelectedIndexChanged += new System.EventHandler(this.cb_SocketMode_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_ValidateString);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lbl_CurrentCount);
            this.groupBox2.Controls.Add(this.btn_SetCount);
            this.groupBox2.Controls.Add(this.btn_Reset);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nud_CountPeriod);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 85);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "计数状态";
            // 
            // tb_ValidateString
            // 
            this.tb_ValidateString.Location = new System.Drawing.Point(71, 50);
            this.tb_ValidateString.Name = "tb_ValidateString";
            this.tb_ValidateString.Size = new System.Drawing.Size(130, 21);
            this.tb_ValidateString.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "NG校验";
            // 
            // lbl_CurrentCount
            // 
            this.lbl_CurrentCount.AutoSize = true;
            this.lbl_CurrentCount.Location = new System.Drawing.Point(270, 27);
            this.lbl_CurrentCount.Name = "lbl_CurrentCount";
            this.lbl_CurrentCount.Size = new System.Drawing.Size(11, 12);
            this.lbl_CurrentCount.TabIndex = 3;
            this.lbl_CurrentCount.Text = "0";
            this.lbl_CurrentCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_SetCount
            // 
            this.btn_SetCount.Location = new System.Drawing.Point(393, 21);
            this.btn_SetCount.Name = "btn_SetCount";
            this.btn_SetCount.Size = new System.Drawing.Size(75, 23);
            this.btn_SetCount.TabIndex = 9;
            this.btn_SetCount.Text = "应用设置";
            this.btn_SetCount.UseVisualStyleBackColor = true;
            this.btn_SetCount.Click += new System.EventHandler(this.btn_SetDecoderParam_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(493, 21);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset.TabIndex = 9;
            this.btn_Reset.Text = "重置计数";
            this.btn_Reset.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "当前计数：";
            // 
            // nud_CountPeriod
            // 
            this.nud_CountPeriod.Location = new System.Drawing.Point(71, 24);
            this.nud_CountPeriod.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_CountPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_CountPeriod.Name = "nud_CountPeriod";
            this.nud_CountPeriod.Size = new System.Drawing.Size(130, 21);
            this.nud_CountPeriod.TabIndex = 1;
            this.nud_CountPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_CountPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "计数周期";
            // 
            // 文件保存路径ToolStripMenuItem
            // 
            this.文件保存路径ToolStripMenuItem.Name = "文件保存路径ToolStripMenuItem";
            this.文件保存路径ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.文件保存路径ToolStripMenuItem.Text = "文件保存路径";
            this.文件保存路径ToolStripMenuItem.Click += new System.EventHandler(this.文件保存路径ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 386);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ListenerPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CountPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox cb_LocalIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_ListLoopback;
        private System.Windows.Forms.NumericUpDown nud_ListenerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_StartListen;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tb_RemoteIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_SocketMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_CurrentCount;
        private System.Windows.Forms.Button btn_SetCount;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nud_CountPeriod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_ValidateString;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem 文件保存路径ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog fbd_CSVSave;
    }
}

