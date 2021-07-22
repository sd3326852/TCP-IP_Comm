using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_IP_Comm
{
    public delegate void RemoteConnectHandler(System.Net.Sockets.Socket RemSoc);
    public delegate void RemoteDataHandler(System.Net.Sockets.Socket RemSoc, byte[] buffer, int Length);
    public delegate void RemoteDisconnectHandler(System.Net.Sockets.Socket RemSoc);

    class ConvenientSocket
    {
        private string _LocalIP = "127.0.0.1";
        private string _RemoteIP = "127.0.0.1";
        private ushort _WorkingPort = 3333;
        private SocketMode _WorkingMode = SocketMode.Server;

        public event RemoteConnectHandler ConnectionReceived;
        public event RemoteDataHandler DataReceived;
        public event RemoteDisconnectHandler ClientOff;

        private System.Net.Sockets.Socket _Socket;
        private List<System.Net.Sockets.Socket> Clients = new List<System.Net.Sockets.Socket>();

        public ConvenientSocket(string sIp, ushort sPort, SocketMode sMode)
        {
            this._LocalIP = sIp;
            this._WorkingPort = sPort;
        }
        public Socket(SocketParam sParameter)
        {
            this._LocalIP = sParameter.LocalIP;
            this._RemoteIP = sParameter.RemoteIP;
            this._WorkingPort = sParameter.Port;
            this._WorkingMode = sParameter.SocketMode;
        }

        /// <summary>
        /// 服务端连接
        /// </summary>
        public void Connect()
        {
            try
            {
                if (null != _Socket) _Socket.Dispose();
                _Socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //允许多个socket访问本地同一个IP和端口号
                _Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                switch (this._WorkingMode)
                {
                    case SocketMode.Server:
                        IPAddress localIP = IPAddress.Parse(_LocalIP);
                        IPEndPoint ipl = new IPEndPoint(localIP, _WorkingPort);
                        _Socket.Bind(ipl);
                        _Socket.Listen(10);
                        _Socket.BeginAccept(new AsyncCallback(_Accept), _Socket);
                        break;
                    case SocketMode.Client:
                        _Socket.Connect(new IPEndPoint(IPAddress.Parse(_RemoteIP), _WorkingPort));
                        StateObject state = new StateObject();
                        _Socket.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(_OnReceive), state);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                _Socket = null;
                //C_Error.WriteErrorLog("SeamTraking", ex);
                throw;
            }
        }

        private void _Accept(IAsyncResult iar)
        {
            if (_Socket == null) return;
            System.Net.Sockets.Socket client = (System.Net.Sockets.Socket)iar.AsyncState;
            try
            {
                Clients.Add(client.EndAccept(iar));
                StateObject state = new StateObject();
                state.workSocket = Clients[Clients.Count - 1];
                ConnectionReceived?.Invoke(Clients[Clients.Count - 1]);
                Clients[Clients.Count - 1].BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(_OnReceive), state);
                _Socket.BeginAccept(new AsyncCallback(_Accept), client);
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException) return;
                //C_Error.WriteErrorLog("DamperData", ex);
                throw;
            }
        }

        private void _OnReceive(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            System.Net.Sockets.Socket handler = state.workSocket ?? this._Socket;

            try
            {
                int bytes = handler.EndReceive(ar);
                ar.AsyncWaitHandle.Close();

                if (bytes > 0)
                {
                    DataReceived?.Invoke(state.workSocket, state.buffer, bytes);
                }
                else
                {
                    switch (this._WorkingMode)
                    {
                        case SocketMode.Server:
                            Clients.Remove(handler);
                            ClientOff?.Invoke(handler);
                            break;
                        case SocketMode.Client:
                            ClientOff?.Invoke(handler);
                            break;
                        default:
                            break;
                    }

                    try
                    {
                        handler.Shutdown(SocketShutdown.Both);
                    }
                    catch (ObjectDisposedException ex)
                    {
                        if (ex.InnerException is SocketException)
                        {
                            throw ex;
                        }
                    }

                    handler.Close();
                    return;
                }
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(_OnReceive), state);
            }
            catch (Exception ex)
            {

                if (ex is ObjectDisposedException) return;
                if (ex is SocketException)
                {
                    Clients.Remove(handler);
                    ClientOff?.Invoke(handler);
                    return;
                }
                //C_Error.WriteErrorLog("DamperData", ex);
                throw;
            }

        }

        /// <summary>
        /// 服务端断开
        /// </summary>
        public void Disconnect()
        {
            if (_Socket != null)
            {
                foreach (System.Net.Sockets.Socket client in Clients)
                {
                    if (client.Connected)
                    {
                        try
                        {
                            client.Shutdown(SocketShutdown.Both);
                        }
                        catch (ObjectDisposedException ex)
                        {
                            if (ex.InnerException is SocketException)
                            {
                                //C_Error.WriteErrorLog("DamperData", ex);
                                throw;
                            }
                        }
                        //client.Disconnect(false);
                        client.Close();
                    }
                }
                Clients.Clear();

                try
                {
                    _Socket.Disconnect(true);
                    _Socket.Close();
                }
                catch (Exception) { return; }
            }
        }

        class StateObject
        {
            public System.Net.Sockets.Socket workSocket = null;
            // Size of receive buffer.     
            public const int BufferSize = 0x400;
            // Receive buffer.     
            public byte[] buffer = new byte[BufferSize];
        }


    }

    public enum SocketMode : byte
    {
        Server = 0,
        Client = 1
    }
}
