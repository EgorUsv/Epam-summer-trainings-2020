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
    /// <summary>
    /// Server message handler delegate.
    /// </summary>
    /// <param name="args"></param>
    public delegate void MessageWork(object args);
    /// <summary>
    /// Represents the server class.
    /// </summary>
    public class MyTcpServer
    {
        /// <summary>
        /// Calls handlers when a message is received.
        /// </summary>
        private event MessageWork ReceiveMessage;
        /// <summary>
        /// Contains a list of clients.
        /// </summary>
        private Dictionary<string,TcpClient> Clients { get; } = new Dictionary<string, TcpClient>();
        /// <summary>
        /// Contains a token to control the listening stream.
        /// </summary>
        CancellationTokenSource StopConnectionListener { get; } = new CancellationTokenSource();
        /// <summary>
        /// Object of type TcpListener.
        /// </summary>
        private TcpListener Server { get; }
        /// <summary>
        /// Initializes the object.
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public MyTcpServer(IPAddress ip, int port)
        {
            if (ip != null)
                Server = new TcpListener(ip, port);
            else
                throw new ArgumentNullException();
        }
        /// <summary>
        /// Starts the server.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Stream for listening to connections from clients.
        /// </summary>
        /// <param name="obj"></param>
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
        /// <summary>
        /// Adds a client to the list.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        private bool AddNewClient(string Name,TcpClient client)
        {
            if(client != null && !Clients.ContainsKey(Name))
            {
                Clients.Add(Name, client);
                return true;
            }
            return false;
        }
        /// <summary>
        /// A thread for listening to messages from each individual client.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="client"></param>
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
        /// <summary>
        /// Sends the message sent to the server to the handler.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="client"></param>
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
        /// <summary>
        /// Sends a message to a connected client.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="message"></param>
        public void SendMessageToClient(string Name,string message)
        {
            try
            {
                Clients[Name].GetStream().Write(Encoding.UTF8.GetBytes(message));
            }
            catch { }
        }
        /// <summary>
        /// Sends a broadcast message.
        /// </summary>
        /// <param name="message"></param>
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
        /// <summary>
        /// Method for subscribing to an event.
        /// </summary>
        /// <param name="subscriber"></param>
        public void SubscribeToReceiveMessage(MessageWork subscriber)
        {
            ReceiveMessage += subscriber;
        }
        /// <summary>
        /// Method for unsubscribing from an event.
        /// </summary>
        /// <param name="subscriber"></param>
        public void UnsubscribeFromReceiveMessage(MessageWork subscriber)
        {
            ReceiveMessage -= subscriber;
        }
        /// <summary>
        /// Method for unsubscribing from all handlers.
        /// </summary>
        private void UnsubscribeAll()
        {
            if (ReceiveMessage != null)
                foreach (Delegate handler in ReceiveMessage.GetInvocationList())
                    ReceiveMessage -= (MessageWork)handler;
        }
        /// <summary>
        /// Stops the server.
        /// </summary>
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
