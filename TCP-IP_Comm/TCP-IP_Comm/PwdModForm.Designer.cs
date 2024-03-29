﻿namespace TCP_IP_Comm
{
    partial class PwdModForm
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
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_OldPassword = new System.Windows.Forms.TextBox();
            this.tb_NewPassword = new System.Windows.Forms.TextBox();
            this.tb_ConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(55, 117);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 0;
            this.btn_Confirm.Text = "确认";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_NewPasswordConfirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(176, 117);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "现用密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "新密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认新密码";
            // 
            // tb_OldPassword
            // 
            this.tb_OldPassword.Location = new System.Drawing.Point(128, 16);
            this.tb_OldPassword.Name = "tb_OldPassword";
            this.tb_OldPassword.PasswordChar = '*';
            this.tb_OldPassword.Size = new System.Drawing.Size(100, 21);
            this.tb_OldPassword.TabIndex = 3;
            // 
            // tb_NewPassword
            // 
            this.tb_NewPassword.Location = new System.Drawing.Point(128, 43);
            this.tb_NewPassword.Name = "tb_NewPassword";
            this.tb_NewPassword.PasswordChar = '*';
            this.tb_NewPassword.Size = new System.Drawing.Size(100, 21);
            this.tb_NewPassword.TabIndex = 3;
            // 
            // tb_ConfirmNewPassword
            // 
            this.tb_ConfirmNewPassword.Location = new System.Drawing.Point(128, 73);
            this.tb_ConfirmNewPassword.Name = "tb_ConfirmNewPassword";
            this.tb_ConfirmNewPassword.PasswordChar = '*';
            this.tb_ConfirmNewPassword.Size = new System.Drawing.Size(100, 21);
            this.tb_ConfirmNewPassword.TabIndex = 3;
            // 
            // PwdModForm
            // 
            this.AcceptButton = this.btn_Confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(313, 160);
            this.Controls.Add(this.tb_ConfirmNewPassword);
            this.Controls.Add(this.tb_NewPassword);
            this.Controls.Add(this.tb_OldPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PwdModForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "密码更改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_OldPassword;
        private System.Windows.Forms.TextBox tb_NewPassword;
        private System.Windows.Forms.TextBox tb_ConfirmNewPassword;
    }
}