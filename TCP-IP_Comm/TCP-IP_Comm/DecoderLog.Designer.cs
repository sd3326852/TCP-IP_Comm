namespace TCP_IP_Comm
{
    partial class DecoderLog
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
            this.tsmi_File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_CSVPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Users = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ModifyPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_LocalIP = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.cb_AutoConnect = new System.Windows.Forms.CheckBox();
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
            this.btn_SetDecoderParam = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_PulseTime = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nud_CountPeriod = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.fbd_CSVSave = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_CSVPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_UserLevel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Blank = new System.Windows.Forms.ToolStripStatusLabel();
            this.tb_RemoteIP = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ListenerPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PulseTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CountPeriod)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_File,
            this.tsmi_Users});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(595, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmi_File
            // 
            this.tsmi_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_CSVPath,
            this.tsmi_Exit});
            this.tsmi_File.Name = "tsmi_File";
            this.tsmi_File.Size = new System.Drawing.Size(44, 21);
            this.tsmi_File.Text = "文件";
            // 
            // tsmi_CSVPath
            // 
            this.tsmi_CSVPath.Name = "tsmi_CSVPath";
            this.tsmi_CSVPath.Size = new System.Drawing.Size(148, 22);
            this.tsmi_CSVPath.Text = "文件保存路径";
            this.tsmi_CSVPath.Click += new System.EventHandler(this.tsmi_CSVPath_Click);
            // 
            // tsmi_Exit
            // 
            this.tsmi_Exit.Name = "tsmi_Exit";
            this.tsmi_Exit.Size = new System.Drawing.Size(148, 22);
            this.tsmi_Exit.Text = "退出";
            // 
            // tsmi_Users
            // 
            this.tsmi_Users.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Login,
            this.tsmi_ModifyPassword});
            this.tsmi_Users.Name = "tsmi_Users";
            this.tsmi_Users.Size = new System.Drawing.Size(68, 21);
            this.tsmi_Users.Text = "权限管理";
            // 
            // tsmi_Login
            // 
            this.tsmi_Login.Name = "tsmi_Login";
            this.tsmi_Login.Size = new System.Drawing.Size(124, 22);
            this.tsmi_Login.Text = "登陆";
            this.tsmi_Login.Click += new System.EventHandler(this.tsmi_Login_Click);
            // 
            // tsmi_ModifyPassword
            // 
            this.tsmi_ModifyPassword.Name = "tsmi_ModifyPassword";
            this.tsmi_ModifyPassword.Size = new System.Drawing.Size(124, 22);
            this.tsmi_ModifyPassword.Text = "修改密码";
            this.tsmi_ModifyPassword.Click += new System.EventHandler(this.tsmi_ModifyPassword_Click);
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
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.cb_AutoConnect);
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
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(493, 18);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 9;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            // 
            // cb_AutoConnect
            // 
            this.cb_AutoConnect.AutoSize = true;
            this.cb_AutoConnect.Location = new System.Drawing.Point(393, 48);
            this.cb_AutoConnect.Name = "cb_AutoConnect";
            this.cb_AutoConnect.Size = new System.Drawing.Size(108, 16);
            this.cb_AutoConnect.TabIndex = 8;
            this.cb_AutoConnect.Text = "启动时自动连接";
            this.cb_AutoConnect.UseVisualStyleBackColor = true;
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
            this.groupBox2.Controls.Add(this.btn_SetDecoderParam);
            this.groupBox2.Controls.Add(this.btn_Reset);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nud_PulseTime);
            this.groupBox2.Controls.Add(this.label8);
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
            // btn_SetDecoderParam
            // 
            this.btn_SetDecoderParam.Location = new System.Drawing.Point(393, 21);
            this.btn_SetDecoderParam.Name = "btn_SetDecoderParam";
            this.btn_SetDecoderParam.Size = new System.Drawing.Size(75, 23);
            this.btn_SetDecoderParam.TabIndex = 9;
            this.btn_SetDecoderParam.Text = "应用设置";
            this.btn_SetDecoderParam.UseVisualStyleBackColor = true;
            this.btn_SetDecoderParam.Click += new System.EventHandler(this.btn_SetDecoderParam_Click);
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
            // nud_PulseTime
            // 
            this.nud_PulseTime.Location = new System.Drawing.Point(272, 51);
            this.nud_PulseTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_PulseTime.Name = "nud_PulseTime";
            this.nud_PulseTime.Size = new System.Drawing.Size(92, 21);
            this.nud_PulseTime.TabIndex = 1;
            this.nud_PulseTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_PulseTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "脉冲时间";
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_CSVPath,
            this.tssl_UserLevel,
            this.tssl_Blank});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(595, 26);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_CSVPath
            // 
            this.tssl_CSVPath.Name = "tssl_CSVPath";
            this.tssl_CSVPath.Size = new System.Drawing.Size(410, 21);
            this.tssl_CSVPath.Spring = true;
            this.tssl_CSVPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssl_UserLevel
            // 
            this.tssl_UserLevel.AutoSize = false;
            this.tssl_UserLevel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tssl_UserLevel.Name = "tssl_UserLevel";
            this.tssl_UserLevel.Size = new System.Drawing.Size(120, 21);
            this.tssl_UserLevel.Text = "操作员";
            // 
            // tssl_Blank
            // 
            this.tssl_Blank.AutoSize = false;
            this.tssl_Blank.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tssl_Blank.Name = "tssl_Blank";
            this.tssl_Blank.Size = new System.Drawing.Size(50, 21);
            // 
            // tb_RemoteIP
            // 
            this.tb_RemoteIP.Location = new System.Drawing.Point(71, 46);
            this.tb_RemoteIP.Name = "tb_RemoteIP";
            this.tb_RemoteIP.Size = new System.Drawing.Size(130, 21);
            this.tb_RemoteIP.TabIndex = 10;
            // 
            // DecoderLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 453);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DecoderLog";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ListenerPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PulseTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CountPeriod)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_File;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Exit;
        private System.Windows.Forms.ComboBox cb_LocalIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_ListLoopback;
        private System.Windows.Forms.NumericUpDown nud_ListenerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_SocketMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_CurrentCount;
        private System.Windows.Forms.Button btn_SetDecoderParam;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nud_CountPeriod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_ValidateString;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem tsmi_CSVPath;
        private System.Windows.Forms.FolderBrowserDialog fbd_CSVSave;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Users;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Login;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_CSVPath;
        private System.Windows.Forms.ToolStripStatusLabel tssl_UserLevel;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Blank;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ModifyPassword;
        private System.Windows.Forms.CheckBox cb_AutoConnect;
        private System.Windows.Forms.NumericUpDown nud_PulseTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_RemoteIP;
    }
}

