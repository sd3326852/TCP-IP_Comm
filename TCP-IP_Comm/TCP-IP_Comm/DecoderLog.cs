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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TCP_IP_Comm
{
    public partial class DecoderLog : Form
    {
        SocketParam _SParams;
        DecoderParam _DParams;
        Socket _Socket;
        bool _Connected = false;
        UserLevel _CurrentUser = UserLevel.Operator;
        WMI_VALUE _WmiValue = new WMI_VALUE();

        public DecoderLog()
        {
            InitializeComponent();
        }

        #region 控件响应
        private void Form1_Load(object sender, EventArgs e)
        {
            _LoadSocketParam();
            _LoadDecoderParam();

            _LevelShift(this._CurrentUser);

            //TCP参数
            this.cb_LocalIP.Items.Add(this._SParams.LocalIP ?? "");
            this.cb_LocalIP.SelectedIndex = 0;
            this.cb_SocketMode.SelectedIndex = (byte)this._SParams.SocketMode;
            this.tb_RemoteIP.Text = this._SParams.RemoteIP ?? "";
            this.nud_ListenerPort.Value = this._SParams.Port;
            this.cb_ListLoopback.Checked = this._SParams.ListLoopback;
            this.cb_AutoConnect.Checked = this._SParams.AutoConnect;

            //解码参数
            this.nud_CountPeriod.Value = this._DParams.CountPeriod;
            this.tb_ValidateString.Text = this._DParams.ValidateString ?? "";
            this.lbl_CurrentCount.Text = this._DParams.CurrentCount.ToString();
            this.tssl_CSVPath.Text = this._DParams.CSVSavingPath;
            this.nud_PulseTime.Value = this._DParams.PulseTime;

            this.cb_LocalIP.TextChanged += this.cb_LocalIP_TextChanged;
            this.tb_RemoteIP.Validated += this.tb_RemoteIP_Validated;
            this.cb_LocalIP.DropDown += this.cb_LocalIP_DropDown;
            this.nud_ListenerPort.ValueChanged += nud_ListenerPort_ValueChanged;
            this.cb_ListLoopback.CheckedChanged += cb_ListLoopback_CheckedChanged;
            this.cb_AutoConnect.CheckedChanged += cb_AutoConnect_CheckedChanged;
            this.btn_Connect.Click += btn_Connect_Click;
            this.nud_CountPeriod.Maximum = uint.MaxValue;
            this.nud_PulseTime.ValueChanged += nud_PulseTime_ValueChanged;

            uint ret = WmiInit(null, null, null, 0);

            if (this._SParams.AutoConnect)
                this.btn_Connect_Click(this.btn_Connect, new EventArgs());
        }

        private void nud_PulseTime_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            this._DParams.PulseTime = Convert.ToUInt16(nud.Value);
        }

        private void cb_AutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            this._SParams.AutoConnect = cb.Checked;
            this._SaveSocketParam();
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (!this._Connected)
            {
                try
                {
                    _Socket = new Socket(this._SParams);
                    _Socket.ConnectionReceived += new RemoteConnectHandler(RemEPArrived);
                    _Socket.DataReceived += new RemoteDataHandler(RemDataReceived);
                    _Socket.ClientOff += new RemoteDisconnectHandler(RemEPLeft);
                    _Socket.Connect();
                    _Connected = true;
                    btn.Text = "断开";

                    if (this._CurrentUser == UserLevel.Operator)
                        return;

                    cb_LocalIP.Enabled = false;
                    nud_ListenerPort.Enabled = false;
                    tb_RemoteIP.Enabled = false;
                    cb_SocketMode.Enabled = false;
                    tsmi_CSVPath.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法连接:" + ex.Message);
                }
            }
            else
            {
                _Socket.Disconnect();
                _Connected = false;
                btn.Text = "连接";

                if (this._CurrentUser == UserLevel.Operator)
                    return;

                cb_LocalIP.Enabled = true;
                nud_ListenerPort.Enabled = true;
                tb_RemoteIP.Enabled = true;
                cb_SocketMode.Enabled = true;
                tsmi_CSVPath.Enabled = true;
            }
        }

        private void nud_ListenerPort_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            this._SParams.Port = Convert.ToUInt16(nud.Value);
            _SaveSocketParam();
        }

        private void cb_ListLoopback_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            this._SParams.ListLoopback = cb.Checked;
            _SaveSocketParam();
        }

        private void cb_LocalIP_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (!string.IsNullOrWhiteSpace(cb.Text))
                this._SParams.LocalIP = cb.Text;
            else
            {
                cb.TextChanged -= this.cb_LocalIP_TextChanged;
                cb.Text = this._SParams.LocalIP;
                cb.TextChanged += this.cb_LocalIP_TextChanged;
                return;
            }
            _SaveSocketParam();
        }

        private void cb_LocalIP_DropDown(object sender, EventArgs e)
        {
            ComboBox cbox = (ComboBox)sender;
            string s = cbox.Text;
            string[] local_endpoints = _GetAvailableIps();

            cbox.Items.Clear();
            cbox.Items.AddRange(local_endpoints);
            cbox.Text = s;
        }

        private void tb_RemoteIP_Validated(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            this._SParams.RemoteIP = tb.Text;
            _SaveSocketParam();
        }

        private void cb_SocketMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            this._SParams.SocketMode = (SocketMode)cb.SelectedIndex;
            this._SaveSocketParam();
        }

        private void btn_SetDecoderParam_Click(object sender, EventArgs e)
        {
            this._DParams.CountPeriod = Convert.ToUInt32(this.nud_CountPeriod.Value);
            this._DParams.ValidateString = this.tb_ValidateString.Text;
            this._DParams.PulseTime = Convert.ToUInt16(this.nud_PulseTime.Value);
            this._SaveDecoderParam();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _LevelShift(UserLevel.Operator);
        }

        private void tsmi_CSVPath_Click(object sender, EventArgs e)
        {
            var result = fbd_CSVSave.ShowDialog();
            if (result == DialogResult.OK)
            {
                this._DParams.CSVSavingPath = fbd_CSVSave.SelectedPath;
                this._SaveDecoderParam();
                this.tssl_CSVPath.Text = fbd_CSVSave.SelectedPath;
            }
        }

        private void tsmi_Login_Click(object sender, EventArgs e)
        {
            DialogResult result = new LoginForm(this._DParams).ShowDialog(this);
            switch (result)
            {
                case DialogResult.OK:
                    _LevelShift(UserLevel.Supervisor);
                    this.timer1.Interval = 10 * 60 * 1000;
                    this.timer1.Start();
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Yes:
                    _LevelShift(UserLevel.Operator);
                    break;
                default:
                    break;
            }

        }

        private void tsmi_ModifyPassword_Click(object sender, EventArgs e)
        {
            PwdModForm pmf = new PwdModForm(this._DParams);
            DialogResult result = pmf.ShowDialog();

            switch (result)
            {
                case DialogResult.OK:
                    this._DParams.Password = pmf.NewPassword;
                    this._SaveDecoderParam();
                    break;
                default:
                    break;
            }
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

            string strDecode = Encoding.ASCII.GetString(Buffer, 0, DataLength);

            //TODO , resolve code , DOut1(!Result)
            string csvPath = _DParams.CSVSavingPath + "\\" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
            try
            {
                _WriteCSV(csvPath, DateTime.Now.ToString("HH:mm:ss") + "," + strDecode);
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, "保存文件失败，请确认文件保存路径可正常访问");
                this.btn_Connect.PerformClick();
                return;
            }
            _UpdateIEIDIoState(1, strDecode == this._DParams.ValidateString, -1);

            this._DParams.CurrentCount++;
            this.lbl_CurrentCount.Text = this._DParams.CurrentCount.ToString();
            if (this._DParams.CurrentCount >= this._DParams.CountPeriod)
            {
                //DOut0;

                _UpdateIEIDIoState(0, true, this._DParams.PulseTime);
            }
            this._DParams.CurrentCount %= this._DParams.CountPeriod;
        }

        private void RemEPLeft(System.Net.Sockets.Socket RemSoc)
        {
            if (InvokeRequired)
            {
                Invoke(new RemoteDisconnectHandler(RemEPLeft), new object[] { RemSoc });
                return;
            }

            switch (this._SParams.SocketMode)
            {
                case SocketMode.Server:
                    break;
                case SocketMode.Client:
                    MessageBox.Show("服务端断开连接");
                    if (this._Connected)
                        this.btn_Connect_Click(this.btn_Connect, new EventArgs());
                    break;
                default:
                    break;
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

        private void _LoadSocketParam()
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
        private void _SaveSocketParam()
        {
            XmlSerializer xs = new XmlSerializer(typeof(SocketParam));

            string sName = Directory.GetCurrentDirectory() + "\\SocketParam.xml";

            FileStream fs = new FileStream(sName, FileMode.Create, FileAccess.ReadWrite);
            fs.Position = 0;

            try
            {
                xs.Serialize(fs, this._SParams);
            }
            catch (Exception ex)
            {
                string message = "保存Socket配置文件失败，错误信息:\r\n";
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

        private void _SaveDecoderParam()
        {
            XmlSerializer xs = new XmlSerializer(typeof(DecoderParam));

            string sName = Directory.GetCurrentDirectory() + "\\DecoderParam.xml";

            //if (File.Exists(pName)) File.Delete(pName);

            FileStream fs = new FileStream(sName, FileMode.Create, FileAccess.ReadWrite);
            fs.Position = 0;

            try
            {
                xs.Serialize(fs, this._DParams);
            }
            catch (Exception ex)
            {
                string message = "保存解码器配置文件失败，错误信息:\r\n";
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
        private void _LoadDecoderParam()
        {
            XmlSerializer xs = new XmlSerializer(typeof(DecoderParam));

            string pName = Directory.GetCurrentDirectory() + "\\DecoderParam.xml";

            FileStream fs = new FileStream(pName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Position = 0;

            try
            {
                _DParams = (DecoderParam)xs.Deserialize(fs);
            }
            catch (Exception ex)
            {
                string message = "打开解码器配置文件失败，错误信息:\r\n";
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

        private void _WriteCSV(string FilePath, string CSV_Line)
        {
            FileStream fs;
            if (!File.Exists(FilePath))
                fs = File.Create(FilePath);
            else
                fs = File.Open(FilePath, FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(CSV_Line);
            sw.Close();
            fs.Close();
        }

        private void _LevelShift(UserLevel User)
        {
            this._CurrentUser = User;
            this.tssl_UserLevel.Text = User == UserLevel.Supervisor ? "管理员" : "操作员";

            this.tsmi_ModifyPassword.Enabled = User == UserLevel.Supervisor;
            this.tb_ValidateString.Enabled = User == UserLevel.Supervisor;
            this.nud_CountPeriod.Enabled = User == UserLevel.Supervisor;
            this.btn_SetDecoderParam.Enabled = User == UserLevel.Supervisor;
            this.btn_Connect.Enabled = User == UserLevel.Supervisor;
            this.cb_ListLoopback.Enabled = User == UserLevel.Supervisor;
            this.cb_AutoConnect.Enabled = User == UserLevel.Supervisor;

            if (this._Connected)
                return;

            this.nud_ListenerPort.Enabled = User == UserLevel.Supervisor;
            this.tb_RemoteIP.Enabled = User == UserLevel.Supervisor;
            this.cb_LocalIP.Enabled = User == UserLevel.Supervisor;
            this.cb_SocketMode.Enabled = User == UserLevel.Supervisor;
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

        [DllImport("ismmSDK_x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 WmiInit([MarshalAs(UnmanagedType.LPWStr)]String IpAddress,
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]String UserName,
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]String PassWord,
            int isConnectRemote);
        [DllImport("ismmSDK_x86.dll")]
        public static extern void WmiExit();

        [DllImport("ismmSDK_x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SetDIOWMI(UInt32 DIO_Value, ref WMI_VALUE pWMI_VALUE);

        private void _UpdateIEIDIoState(int index, bool value, int delay)
        {
            UInt32 DioValue = 0;
            SetDIOWMI(DioValue, ref _WmiValue);
            DioValue = _WmiValue.value2 & (0xFFFFFF);
            DioValue &= ~((uint)(0x1 << index));
            DioValue |= Convert.ToUInt32(value) << index;
            DioValue |= (1 << 24);
            SetDIOWMI(DioValue, ref _WmiValue);

            if (delay >= 0)
            {
                System.Timers.Timer t = new System.Timers.Timer();
                t.AutoReset = false;
                t.Interval = Math.Max(50, delay);
                t.Elapsed += delegate
                {
                    t.Stop();
                    t.Dispose();
                    value = !value;
                    DioValue &= ~((uint)(0x1 << index));
                    DioValue |= Convert.ToUInt32(value) << index;
                    DioValue |= (1 << 24);
                    SetDIOWMI(DioValue, ref _WmiValue);
                };
                t.Start();
            }
        }

        #endregion
    }


    public struct SocketParam
    {
        public string LocalIP;
        public string RemoteIP;
        public ushort Port;
        public bool ListLoopback;
        public bool AutoConnect;
        public SocketMode SocketMode;
    }

    public struct DecoderParam
    {
        public uint CountPeriod;
        public uint CurrentCount;
        public string ValidateString;
        public string CSVSavingPath;
        public string Password;
        public ushort PulseTime;
    }

    enum UserLevel
    {
        Supervisor,
        Operator
    }

    internal class Encrypt
    {
        static Encoding encoding = Encoding.UTF8;

        public static string EncryptDES(string encryptString, string key)
        {
            var input = encoding.GetBytes(encryptString);
            var ouptputData = ProcessDES(input, key, true);
            var outputStr = Convert.ToBase64String(ouptputData);

            //base64编码中有不能作为文件名的'/'符号，这里把它替换一下，增强适用范围
            return outputStr.Replace('/', '@');
        }

        public static string DecryptDES(string decryptString, string key)
        {
            decryptString = decryptString.Replace('@', '/');

            var input = Convert.FromBase64String(decryptString);
            var data = ProcessDES(input, key, false);
            return encoding.GetString(data);
        }


        private static byte[] ProcessDES(byte[] data, string key, bool isEncrypt)
        {
            using (var dCSP = new DESCryptoServiceProvider())
            {
                var keyData = Md5(key);
                var rgbKey = new ArraySegment<byte>(keyData, 0, 8).ToArray();
                var rgbIV = new ArraySegment<byte>(keyData, 8, 8).ToArray();
                var dCSPKey = isEncrypt ? dCSP.CreateEncryptor(rgbKey, rgbIV) : dCSP.CreateDecryptor(rgbKey, rgbIV);

                using (var memory = new MemoryStream())
                using (var cStream = new CryptoStream(memory, dCSPKey, CryptoStreamMode.Write))
                {
                    cStream.Write(data, 0, data.Length);
                    cStream.FlushFinalBlock();
                    return memory.ToArray();
                }
            }
        }

        public static byte[] Md5(string str)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            }
        }
    }
}
