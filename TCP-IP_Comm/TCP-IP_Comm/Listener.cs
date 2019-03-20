using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_IP_Comm
{
    public delegate void RemoteConnectHandler(Socket RemSoc);
    public delegate void RemoteDataHandler(Socket RemSoc, byte[] buffer, int Length);
    public delegate void RemoteDisconnectHandler(Socket RemSoc);

    class Listener
    {
        private string serverIP = "127.0.0.1";
        private int serverPort = 3333;

        public event RemoteConnectHandler ConnectionReceived;
        public event RemoteDataHandler DataReceived;
        public event RemoteDisconnectHandler ClientOff;

        private Socket server;
        private List<Socket> Clients = new List<Socket>();

        public Listener(string sIp, int sPort)
        {
            this.serverIP = sIp;
            this.serverPort = sPort;
        }
        public Listener(ListenerParam sParameter)
        {
            this.serverIP = sParameter.ServerIP;
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
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //允许多个socket访问本地同一个IP和端口号
                server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                IPAddress localIP = IPAddress.Parse(serverIP);
                IPEndPoint ipl = new IPEndPoint(localIP, serverPort);

                server.Bind(ipl);
                server.Listen(10);
                server.BeginAccept(new AsyncCallback(Accept), server);
            }
            catch (SocketException ex)
            {
                server = null;
                //C_Error.WriteErrorLog("SeamTraking", ex);
                throw ex;
            }
        }

        private void Accept(IAsyncResult iar)
        {
            if (server == null) return;
            Socket client = (Socket)iar.AsyncState;
            try
            {
                Clients.Add(client.EndAccept(iar));
                StateObject state = new StateObject();
                state.workSocket = Clients[Clients.Count - 1];
                ConnectionReceived(Clients[Clients.Count - 1]);
                Clients[Clients.Count - 1].BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(OnReceive), state);
                server.BeginAccept(new AsyncCallback(Accept), client);
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException) return;
                //C_Error.WriteErrorLog("DamperData", ex);
                throw;
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

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
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(OnReceive), state);
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
        public void DisConnect()
        {
            if (server != null)
            {
                foreach (Socket client in Clients)
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
            public Socket workSocket = null;
            // Size of receive buffer.     
            public const int BufferSize = 1024;
            // Receive buffer.     
            public byte[] buffer = new byte[BufferSize];
        }
    }
}
