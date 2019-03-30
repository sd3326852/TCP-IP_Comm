using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TCP_IP_Comm
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            initInfo();
        }

        private void initInfo()
        {
            string path = "\\About\\about.txt";
            if (File.Exists(path))
            {
                FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream,Encoding.Default);
                string context = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                string[] values = context.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (values[0] != "") label2.Text = values[0];
                if (values[1] != "") label3.Text = values[1];
                if (values[2] != "") label4.Text = values[2];
            }
            string imgPath = "\\About\\logo";
            string[] imgType = new string[] { ".jpg", ".png", ".bmp" };
            for (int i = 0; i < 3; i++)
            {
                string name = imgPath + imgType[i];
                if (File.Exists(name))
                {
                    Image image = Image.FromFile(name);
                    pictureBox1.Image = image;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel_Web_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.haizhichen.com");
        }
    }
}
