using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public delegate void MessageTranslator(string message);
    public class MyTcpClient
    {
        public event MessageTranslator ReceiveMessage;
        private string Name { get; }
        CancellationTokenSource StopMessageListener { get; } = new CancellationTokenSource();
        TcpClient Client { get; set; }
        public MyTcpClient(string name)
        {
            if (name != null)
                Name = name;
            else
                throw new ArgumentNullException();
        }
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
        public void SendMessage(string message)
        {
            Client.GetStream().Write(Encoding.UTF8.GetBytes(message));
        }
        public void MessageListener(object obj)
        {
            StringBuilder message = new StringBuilder();
            var token = (CancellationToken)obj;
            while(!token.IsCancellationRequested)
            {
                if(Client.GetStream().DataAvailable)
                {
                    message.Clear();
                    byte[] bytes = new byte[Client.Available];
                    Client.GetStream().Read(bytes, 0, Client.Available);
                    message.Append(Encoding.UTF8.GetString(bytes));
                }
                if(message.Length > 0)
                    ReceiveMessage?.Invoke(message.ToString());
            }
        }
        public void SubscribeToReceiveMessage(MessageTranslator subscriber)
        {
            ReceiveMessage += subscriber;
        }
        public void UnsubscribeFromReceiveMessage(MessageTranslator subscriber)
        {
            ReceiveMessage -= subscriber;
        }
        private void UnsubcribeAll()
        {
            foreach (Delegate handler in ReceiveMessage.GetInvocationList())
                ReceiveMessage -= (MessageTranslator)handler;
        }
        public void CloseConnection()
        {
            StopMessageListener.Cancel();
            SendMessage($"--{Name} disconnected--");
            Client.Close();
            UnsubcribeAll();
        }

    }
}
