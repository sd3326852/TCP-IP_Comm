using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TCP_IP_Comm
{
    public partial class Form1 : Form
    {
        ListenerParam _LParams;
        Listener _TCPListener;
        bool _Listening = false;

        public Form1()
        {
            InitializeComponent();
        }

        #region 控件响应
        private void Form1_Load(object sender, EventArgs e)
        {
            _LoadParam();

            this.cb_ListenerIP.Items.Add(this._LParams.ServerIP);
            this.cb_ListenerIP.SelectedIndex = 0;
            this.nud_ListenerPort.Value = this._LParams.Port;
            this.cb_ListLoopback.Checked = this._LParams.CistLoopback;

            this.cb_ListenerIP.TextChanged += this.cb_ListenerIP_TextChanged;
            this.cb_ListenerIP.DropDown += this.cb_ListenerIP_DropDown;
            this.nud_ListenerPort.ValueChanged += nud_ListenerPort_ValueChanged;
            this.cb_ListLoopback.CheckedChanged += cb_ListLoopback_CheckedChanged;
            this.btn_StartListen.Click += btn_StartListen_Click;
        }

        private void btn_StartListen_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (!this._Listening)
            {
                try
                {
                    _TCPListener = new Listener(this._LParams);
                    _TCPListener.ConnectionReceived += new RemoteConnectHandler(RemEPArrived);
                    _TCPListener.DataReceived += new RemoteDataHandler(RemDataReceived);
                    _TCPListener.ClientOff += new RemoteDisconnectHandler(RemEPLeft);
                    _TCPListener.Connect();
                    _Listening = true;
                    cb_ListenerIP.Enabled = false;
                    nud_ListenerPort.Enabled = false;
                    openToolStripMenuItem.Enabled = false;
                    saveToolStripMenuItem.Enabled = false;
                    newToolStripMenuItem.Enabled = false;
                    btn.Text = "断开";
                }
                catch(Exception ex)
                {
                    MessageBox.Show("无法连接:" + ex.Message);
                }
            }
            else
            {
                _TCPListener.DisConnect();
                _Listening = false;
                cb_ListenerIP.Enabled = true;
                nud_ListenerPort.Enabled = true;
                openToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                newToolStripMenuItem.Enabled = true;
                btn.Text = "连接";
            }
        }

        private void nud_ListenerPort_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            this._LParams.Port = Convert.ToUInt16(nud.Value);
            _SaveParam();
        }

        private void cb_ListLoopback_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            this._LParams.CistLoopback = cb.Checked;
            _SaveParam();
        }

        private void cb_ListenerIP_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (!string.IsNullOrWhiteSpace(cb.Text))
                this._LParams.ServerIP = cb.Text;
            else
            {
                cb.TextChanged -= this.cb_ListenerIP_TextChanged;
                cb.Text = this._LParams.ServerIP;
                cb.TextChanged += this.cb_ListenerIP_TextChanged;
                return;
            }
            _SaveParam();
        }

        private void cb_ListenerIP_DropDown(object sender, EventArgs e)
        {
            ComboBox cbox = (ComboBox)sender;
            string s = cbox.Text;
            string[] local_endpoints = _GetAvailableIps();

            cbox.Items.Clear();
            cbox.Items.AddRange(local_endpoints);
            cbox.Text = s;
        }


        #endregion

        #region Socket响应
        private void RemEPArrived(Socket RemSoc)
        {
            if (InvokeRequired)
            {
                Invoke(new RemoteConnectHandler(RemEPArrived), new object[] { RemSoc });
                return;
            }
        }

        private void RemDataReceived(Socket RemSoc, byte[] Buffer, int DataLength)
        {
            if (InvokeRequired)
            {
                Invoke(new RemoteDataHandler(RemDataReceived), new object[] { RemSoc, Buffer, DataLength });
                return;
            }
        }

        private void RemEPLeft(Socket RemSoc)
        {
            if (InvokeRequired)
            {
                Invoke(new RemoteDisconnectHandler(RemEPLeft), new object[] { RemSoc });
                return;
            }
        }
        #endregion

        #region 内部方法
        private string[] _GetAvailableIps()
        {
            List<string> ips = new List<string>();
            System.Net.NetworkInformation.NetworkInterface[] interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            foreach (System.Net.NetworkInformation.NetworkInterface inf in interfaces)
            {
                if (!inf.IsReceiveOnly && inf.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up && inf.SupportsMulticast && (inf.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback || this._LParams.CistLoopback))
                {
                    System.Net.NetworkInformation.IPInterfaceProperties ipinfo = inf.GetIPProperties();
                    foreach (System.Net.NetworkInformation.UnicastIPAddressInformation addr in ipinfo.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ips.Add(addr.Address.ToString());
                        }
                    }
                }
            }
            return ips.ToArray();
        }
        private void _LoadParam()
        {
            XmlSerializer xs = new XmlSerializer(typeof(ListenerParam));

            string pName = Directory.GetCurrentDirectory() + "ListenerParam.xml";

            FileStream fs = new FileStream(pName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Position = 0;

            try
            {
                _LParams = (ListenerParam)xs.Deserialize(fs);
            }
            catch (Exception ex)
            {
                string message = "打开配置文件失败，错误信息:\r\n";
                message += ex.Message;
                MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fs.Close();
            }
        }
        private void _SaveParam()
        {
            XmlSerializer xs = new XmlSerializer(typeof(ListenerParam));

            string pName = Directory.GetCurrentDirectory() + "ListenerParam.xml";

            //if (File.Exists(pName)) File.Delete(pName);

            FileStream fs = new FileStream(pName, FileMode.Create, FileAccess.ReadWrite);
            fs.Position = 0;

            try
            {
                xs.Serialize(fs, this._LParams);
            }
            catch (Exception ex)
            {
                string message = "保存配置文件失败，错误信息:\r\n";
                message += ex.Message;
                MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fs.Close();
            }
        }
        #endregion
    }


    [Serializable]
    public struct ListenerParam
    {
        public string ServerIP;
        public ushort Port;
        public bool CistLoopback;
    }
}
