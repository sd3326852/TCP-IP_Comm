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
    public partial class LoginForm : Form
    {
        DecoderParam _DecoderParams;

        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(DecoderParam Params)
        {
            this._DecoderParams = Params;
            InitializeComponent();

            this.cb_User.SelectedIndex = 0;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (this.cb_User.SelectedIndex == 1)
            {
                this.DialogResult = DialogResult.Yes;
                return;
            }
            string strEncrypted = Encrypt.EncryptDES(this.tb_Password.Text, "HZC666");
            if (strEncrypted == _DecoderParams.Password)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("密码错误");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
