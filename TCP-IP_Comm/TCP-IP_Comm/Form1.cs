using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TCP_IP_Comm
{
    public partial class Form1 : Form
    {
        SocketParam _SParams;
        Socket _TCPListener;
        bool _Listening = false;
        UserLevel _CurrentUser = UserLevel.Operator;
        WMI_VALUE WmiValue = new WMI_VALUE();

        public Form1()
        {
            InitializeComponent();
        }

        #region 控件响应
        private void Form1_Load(object sender, EventArgs e)
        {
            _LoadParam();

            this.cb_LocalIP.Items.Add(this._SParams.LocalIP ?? "");
            this.cb_LocalIP.SelectedIndex = 0;
            this.tb_RemoteIP.Text = this._SParams.RemoteIP ?? "";
            this.nud_ListenerPort.Value = this._SParams.Port;
            this.cb_ListLoopback.Checked = this._SParams.ListLoopback;

            this.cb_LocalIP.TextChanged += this.cb_ListenerIP_TextChanged;
            this.cb_LocalIP.DropDown += this.cb_ListenerIP_DropDown;
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
                    _TCPListener = new Socket(this._SParams);
                    _TCPListener.ConnectionReceived += new RemoteConnectHandler(RemEPArrived);
                    _TCPListener.DataReceived += new RemoteDataHandler(RemDataReceived);
                    _TCPListener.ClientOff += new RemoteDisconnectHandler(RemEPLeft);
                    _TCPListener.Connect();
                    _Listening = true;
                    cb_LocalIP.Enabled = false;
                    nud_ListenerPort.Enabled = false;
                    openToolStripMenuItem.Enabled = false;
                    saveToolStripMenuItem.Enabled = false;
                    newToolStripMenuItem.Enabled = false;
                    btn.Text = "断开";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法连接:" + ex.Message);
                }
            }
            else
            {
                _TCPListener.Disconnect();
                _Listening = false;
                cb_LocalIP.Enabled = true;
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
            this._SParams.Port = Convert.ToUInt16(nud.Value);
            _SaveParam();
        }

        private void cb_ListLoopback_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            this._SParams.ListLoopback = cb.Checked;
            _SaveParam();
        }

        private void cb_ListenerIP_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (!string.IsNullOrWhiteSpace(cb.Text))
                this._SParams.LocalIP = cb.Text;
            else
            {
                cb.TextChanged -= this.cb_ListenerIP_TextChanged;
                cb.Text = this._SParams.LocalIP;
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

        private void tb_RemoteIP_TextChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Socket响应
        private void RemEPArrived(System.Net.Sockets.Socket RemSoc)
        {
            if (InvokeRequired)
            {
                Invoke(new RemoteConnectHandler(RemEPArrived), new object[] { RemSoc });
                return;
            }
        }

        private void RemDataReceived(System.Net.Sockets.Socket RemSoc, byte[] Buffer, int DataLength)
        {
            if (InvokeRequired)
            {
                Invoke(new RemoteDataHandler(RemDataReceived), new object[] { RemSoc, Buffer, DataLength });
                return;
            }
        }

        private void RemEPLeft(System.Net.Sockets.Socket RemSoc)
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
                if (!inf.IsReceiveOnly && inf.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up && inf.SupportsMulticast && (inf.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback || this._SParams.ListLoopback))
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
            XmlSerializer xs = new XmlSerializer(typeof(SocketParam));

            string pName = Directory.GetCurrentDirectory() + "\\SocketParam.xml";

            FileStream fs = new FileStream(pName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Position = 0;

            try
            {
                _SParams = (SocketParam)xs.Deserialize(fs);
            }
            catch (Exception ex)
            {
                string message = "打开配置文件失败，错误信息:\r\n";
                message += ex.Message + "\r\n";
                if (ex.InnerException != null)
                    message += ex.InnerException.Message;
                MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fs.Close();
            }
        }
        private void _SaveParam()
        {
            XmlSerializer xs = new XmlSerializer(typeof(SocketParam));

            string pName = Directory.GetCurrentDirectory() + "\\SocketParam.xml";

            //if (File.Exists(pName)) File.Delete(pName);

            FileStream fs = new FileStream(pName, FileMode.Create, FileAccess.ReadWrite);
            fs.Position = 0;

            try
            {
                xs.Serialize(fs, this._SParams);
            }
            catch (Exception ex)
            {
                string message = "保存配置文件失败，错误信息:\r\n";
                message += ex.Message;
                message += ex.Message + "\r\n";
                if (ex.InnerException != null)
                    message += ex.InnerException.Message;
                MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fs.Close();
            }
        }

        private void _LevelShift(UserLevel User)
        {
            this._CurrentUser = User;
        }
        #endregion

        #region IEI_IO定义部分
        public struct WMI_VALUE
        {
            public UInt32 ID;//
            public UInt32 value1;//
            public UInt32 value2;//resvered for future
            public UInt32 status;//
        }

        [DllImport("ismmSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 WmiInit([MarshalAs(UnmanagedType.LPWStr)]String IpAddress,
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]String UserName,
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]String PassWord,
            int isConnectRemote);
        [DllImport("ismmSDK.dll")]
        public static extern void WmiExit();

        [DllImport("ismmSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SetDIOWMI(UInt32 DIO_Value, ref WMI_VALUE pWMI_VALUE);

        
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            _LevelShift(UserLevel.Operator);
        }

        private void tb_RemoteIP_Validated(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            this._SParams.RemoteIP = tb.Text;
            _SaveParam();
        }


    }


    [Serializable]
    public struct SocketParam
    {
        public string LocalIP;
        public string RemoteIP;
        public ushort Port;
        public bool ListLoopback;
        public SocketMode SocketMode;
    }

    enum UserLevel
    {
        Supervisor,
        Operator
    }
}
