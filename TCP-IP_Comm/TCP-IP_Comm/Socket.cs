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

    class Socket
    {
        private string serverIP = "127.0.0.1";
        private int serverPort = 3333;
        private SocketMode sMode = SocketMode.Server;

        public event RemoteConnectHandler ConnectionReceived;
        public event RemoteDataHandler DataReceived;
        public event RemoteDisconnectHandler ClientOff;

        private System.Net.Sockets.Socket server;
        private List<System.Net.Sockets.Socket> Clients = new List<System.Net.Sockets.Socket>();

        public Socket(string sIp, int sPort, SocketMode sMode)
        {
            this.serverIP = sIp;
            this.serverPort = sPort;
        }
        public Socket(SocketParam sParameter)
        {
            this.serverIP = sParameter.LocalIP;
            this.serverPort = sParameter.Port;
        }

        /// <summary>
        /// 服务端连接
        /// </summary>
        public void Connect()
        {
            try
            {
                if (null != server) server.Dispose();
                server = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //允许多个socket访问本地同一个IP和端口号
                server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                IPAddress localIP = IPAddress.Parse(serverIP);
                IPEndPoint ipl = new IPEndPoint(localIP, serverPort);

                server.Bind(ipl);
                switch (this.sMode)
                {
                    case SocketMode.Server:
                        server.Listen(10);
                        server.BeginAccept(new AsyncCallback(_Accept), server);
                        break;
                    case SocketMode.Client:

                        break;
                    default:
                        break;
                }
            }
            catch (SocketException ex)
            {
                server = null;
                //C_Error.WriteErrorLog("SeamTraking", ex);
                throw ex;
            }
        }

        private void _Accept(IAsyncResult iar)
        {
            if (server == null) return;
            System.Net.Sockets.Socket client = (System.Net.Sockets.Socket)iar.AsyncState;
            try
            {
                Clients.Add(client.EndAccept(iar));
                StateObject state = new StateObject();
                state.workSocket = Clients[Clients.Count - 1];
                ConnectionReceived(Clients[Clients.Count - 1]);
                Clients[Clients.Count - 1].BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(_OnReceive), state);
                server.BeginAccept(new AsyncCallback(_Accept), client);
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
            System.Net.Sockets.Socket handler = state.workSocket;

            try
            {
                int bytes = handler.EndReceive(ar);
                ar.AsyncWaitHandle.Close();

                if (bytes > 0)
                {
                    DataReceived(state.workSocket, state.buffer, bytes);
                }
                else
                {
                    Clients.Remove(handler);
                    ClientOff(handler);
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
                    ClientOff(handler);
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
            if (server != null)
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

                try { server.Close(); }
                catch (Exception) { return; }
            }
        }

        class StateObject
        {
            public System.Net.Sockets.Socket workSocket = null;
            // Size of receive buffer.     
            public const int BufferSize = 0x500000;
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
