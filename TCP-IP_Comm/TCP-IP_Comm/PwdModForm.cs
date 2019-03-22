using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_IP_Comm
{
    public partial class PwdModForm : Form
    {
        DecoderParam _DecoderParams;

        public string NewPassword;

        public PwdModForm()
        {
            InitializeComponent();
        }

        public PwdModForm(DecoderParam Params)
        {
            this._DecoderParams = Params;
            InitializeComponent();
        }

        private void btn_NewPasswordConfirm_Click(object sender, EventArgs e)
        {
            if (Encrypt.EncryptDES(this.tb_OldPassword.Text, "HZC666") != this._DecoderParams.Password)
            {
                MessageBox.Show("密码错误");
                return;
            }
            else if (this.tb_NewPassword.Text!=this.tb_ConfirmNewPassword.Text)
            {
                MessageBox.Show("新密码与确认密码不一致");
                return;
            }

            this.NewPassword = Encrypt.EncryptDES(this.tb_ConfirmNewPassword.Text, "HZC666");
            this.DialogResult = DialogResult.OK;
        }
    }
}
