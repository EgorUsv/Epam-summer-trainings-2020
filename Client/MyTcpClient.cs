using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    /// <summary>
    /// Сlient message handler delegate.
    /// </summary>
    /// <param name="message"></param>
    public delegate void MessageTranslator(string message);
    /// <summary>
    /// Represents the type of client.
    /// </summary>
    public class MyTcpClient
    {
        /// <summary>
        /// Calls handlers when a message is received.
        /// </summary>
        private event MessageTranslator ReceiveMessage;
        /// <summary>
        /// Contains the client's name.
        /// </summary>
        private string Name { get; }
        /// <summary>
        /// Contains a token to control the listening stream.
        /// </summary>
        CancellationTokenSource StopMessageListener { get; } = new CancellationTokenSource();
        /// <summary>
        /// Object of type TcpClient.
        /// </summary>
        TcpClient Client { get; set; }
        /// <summary>
        /// Initializes an object of type MyTcpClient.
        /// </summary>
        /// <param name="name"></param>
        public MyTcpClient(string name)
        {
            if (name != null)
                Name = name;
            else
                throw new ArgumentNullException();
        }
        /// <summary>
        /// Connects a client to a specific server.
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool ConnectToServer(IPAddress ip,int port)
        {
            try
            {
                Client = new TcpClient();
                Client.Connect(ip, port);
                SendMessage(Name);
                new Thread(() => MessageListener(StopMessageListener.Token)).Start();
                return true;
            }
            catch(SocketException)
            {
                return false;
            }
        }
        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            Client.GetStream().Write(Encoding.UTF8.GetBytes(message));
        }
        /// <summary>
        /// A thread to listen for messages from the server.
        /// </summary>
        /// <param name="obj"></param>
        public void MessageListener(object obj)
        {
            StringBuilder message = new StringBuilder();
            var token = (CancellationToken)obj;
            while(!token.IsCancellationRequested)
            {
                message.Clear();
                if (Client.GetStream().DataAvailable)
                {
                    byte[] bytes = new byte[Client.Available];
                    Client.GetStream().Read(bytes, 0, Client.Available);
                    message.Append(Encoding.UTF8.GetString(bytes));
                }
                if(message.Length > 0)
                    ReceiveMessage?.Invoke(message.ToString());
            }
        }
        /// <summary>
        /// Method for subscribing to an event.
        /// </summary>
        /// <param name="subscriber"></param>
        public void SubscribeToReceiveMessage(MessageTranslator subscriber)
        {
            ReceiveMessage += subscriber;
        }
        /// <summary>
        /// Method for unsubscribing from an event.
        /// </summary>
        /// <param name="subscriber"></param>
        public void UnsubscribeFromReceiveMessage(MessageTranslator subscriber)
        {
            ReceiveMessage -= subscriber;
        }
        /// <summary>
        /// Method for unsubscribing from all handlers.
        /// </summary>
        private void UnsubcribeAll()
        {
            foreach (Delegate handler in ReceiveMessage.GetInvocationList())
                ReceiveMessage -= (MessageTranslator)handler;
        }
        /// <summary>
        /// Disconnect client from server.
        /// </summary>
        public void CloseConnection()
        {
            StopMessageListener.Cancel();
            SendMessage($"--{Name} disconnected--");
            Client.Close();
            UnsubcribeAll();
        }

    }
}
