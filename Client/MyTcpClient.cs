using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public delegate string MessageHandler(string message);
    public class MyTcpClient
    {
        public event MessageHandler ReceiveMessage;
        private string Name { get; }
        CancellationTokenSource StopMessageListener { get; } = new CancellationTokenSource();
        TcpClient Client { get; }
        public MyTcpClient(string name)
        {
            if (name != null)
                Name = name;
            else
                throw new ArgumentNullException();
        }
        public void ConnectToServer(IPAddress ip,int port)
        {
            try
            {
                Client.Connect(ip, port);
                SendMessage(Name);
                new Thread(() => MessageListener(StopMessageListener.Token)).Start();
            }
            catch
            {
                Client.Close();
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
                if(Client.ReceiveBufferSize > 0)
                {
                    message.Clear();
                    byte[] bytes = new byte[Client.ReceiveBufferSize];
                    Client.GetStream().Read(bytes, 0, Client.ReceiveBufferSize);
                    message.Append(Encoding.UTF8.GetString(bytes));
                }
                if (message.Length > 0)
                    ReceiveMessage?.Invoke(message.ToString());
            }
        }
        public void SubscribeToReceiveMessage(MessageHandler subscriber)
        {
            ReceiveMessage += subscriber;
        }
        public void UnsubscribeFromReceiveMessage(MessageHandler subscriber)
        {
            ReceiveMessage -= subscriber;
        }
        private void UnsubcribeAll()
        {
            foreach (Delegate handler in ReceiveMessage.GetInvocationList())
                ReceiveMessage -= (MessageHandler)handler;
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
