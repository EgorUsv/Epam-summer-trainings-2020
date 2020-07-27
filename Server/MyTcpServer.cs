using Server.Messages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public delegate void MessageWork(object args);
    public class MyTcpServer
    {
        private event MessageWork ReceiveMessage;
        private Dictionary<string,TcpClient> Clients { get; } = new Dictionary<string, TcpClient>();
        CancellationTokenSource StopConnectionListener { get; } = new CancellationTokenSource();
        private TcpListener Server { get; }
        public MyTcpServer(IPAddress ip, int port)
        {
            if (ip != null)
                Server = new TcpListener(ip, port);
            else
                throw new ArgumentNullException();
        }
        public bool StartServer()
        {
            try
            {
                Server.Start();
                new Task(() => ListenConnections(StopConnectionListener.Token)).Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void ListenConnections(object obj)
        {
            var token = (CancellationToken)obj;
            while(!token.IsCancellationRequested)
            {
                try
                {
                    TcpClient client = Server.AcceptTcpClient();
                    byte[] buffer = new byte[client.Available];
                    client.GetStream().Read(buffer, 0, buffer.Length);
                    string name = Encoding.UTF8.GetString(buffer);
                    if (AddNewClient(name, client))
                        new Thread(() => ListenMessages(name,client)).Start();
                }
                catch
                {
                    Server.Stop();
                }
            }
        }
        private bool AddNewClient(string Name,TcpClient client)
        {
            if(client != null && !Clients.ContainsKey(Name))
            {
                Clients.Add(Name, client);
                return true;
            }
            return false;
        }
        private void ListenMessages(string Name, TcpClient client)
        {
            bool working = true;
            while(working)
            {
                try
                {
                    if (!client.Connected)
                    {
                        working = false;
                        Clients.Remove(Name);
                    }
                    if (client.Available != 0)
                        GetMessage(Name, client);
                }
                catch { }
            }
        }
        public void GetMessage(string Name, TcpClient client)
        {
            StringBuilder message = new StringBuilder();
            while(client.GetStream().DataAvailable)
            {
                byte[] buffer = new byte[client.Available];
                client.GetStream().Read(buffer, 0, buffer.Length);
                message.Append(Encoding.UTF8.GetString(buffer));
            }
            if (message.Length != 0)
                ReceiveMessage?.Invoke(new MessageEventArgs(Name, message.ToString()));
        }
        public void SendMessageToClient(string Name,string message)
        {
            try
            {
                Clients[Name].GetStream().Write(Encoding.UTF8.GetBytes(message));
            }
            catch { }
        }
        public void SendBroadcastMessage(string message)
        {
            var clients = Clients.Values;
            foreach (TcpClient client in clients)
            {
                try
                {
                    client.GetStream().Write(Encoding.UTF8.GetBytes(message));
                }
                catch { }
            }
        }
        public void SubscribeToReceiveMessage(MessageWork subscriber)
        {
            ReceiveMessage += subscriber;
        }
        public void UnsubscribeFromReceiveMessage(MessageWork subscriber)
        {
            ReceiveMessage -= subscriber;
        }
        private void UnsubscribeAll()
        {
            if (ReceiveMessage != null)
                foreach (Delegate handler in ReceiveMessage.GetInvocationList())
                    ReceiveMessage -= (MessageWork)handler;
        }
        public void StopServer()
        {
            StopConnectionListener.Cancel();
            foreach (var client in Clients)
                client.Value.Close();
            Server.Stop();
            UnsubscribeAll();
        }
    }
}
