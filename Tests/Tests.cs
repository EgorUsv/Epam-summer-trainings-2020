using Client;
using Client.Handlers;
using CollectionOfMessages;
using NUnit.Framework;
using Server;
using Server.Messages;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Tests2
{
    public class Tests
    {
        public const int TimeDelay = 5;
        [Test,Order(1)]
        public void ReceiveMessageTest()
        {
            MyTcpServer privateServer = new MyTcpServer(IPAddress.Loopback, 100);
            privateServer.SubscribeToReceiveMessage(MessagesCollection<MessageEventArgs>.AddMessage);
            privateServer.StartServer();
            Thread.Sleep(TimeDelay);
            MyTcpClient client = new MyTcpClient("NewUser1");
            client.ConnectToServer(IPAddress.Loopback, 100);
            Thread.Sleep(TimeDelay);
            client.SendMessage("TestMessage1");
            Thread.Sleep(TimeDelay);
            var expected = new MessageEventArgs("NewUser1", "TestMessage1").ToString();
            var actual = MessagesCollection<MessageEventArgs>.ElementAt(0);
            Assert.AreEqual(expected, actual);

            MyTcpClient client2 = new MyTcpClient("NewUser2");
            client2.ConnectToServer(IPAddress.Loopback, 100);
            Thread.Sleep(TimeDelay);
            client2.SendMessage("TestMessage2");
            Thread.Sleep(TimeDelay);
            var expected2 = new MessageEventArgs("NewUser2", "TestMessage2").ToString();
            var actual2 = MessagesCollection<MessageEventArgs>.ElementAt(1);
            Assert.AreEqual(expected2, actual2);
            privateServer.StopServer();
        }
        [Test,Order(2)]
        public void StopServerTest()
        {
            MyTcpServer server = new MyTcpServer(IPAddress.Loopback, 200);
            server.StartServer();
            Thread.Sleep(TimeDelay);
            server.StopServer();
            Thread.Sleep(TimeDelay);
            try
            {
                if (new MyTcpClient("User").ConnectToServer(IPAddress.Loopback, 200))
                    Assert.True(false);
            }
            catch (SocketException)
            {
                Assert.True(true);
            }
        }
        [Test,Order(3)]
        public void SendMessageTest()
        {
            MyTcpServer server = new MyTcpServer(IPAddress.Loopback, 300);
            server.StartServer();
            Thread.Sleep(TimeDelay);
            MyTcpClient tcpClient = new MyTcpClient("Client1");
            tcpClient.SubscribeToReceiveMessage(MessageConverter.StringConveter);
            tcpClient.ConnectToServer(IPAddress.Loopback, 300);
            Thread.Sleep(TimeDelay);
            server.SendMessageToClient("Client1", "Test");
            Thread.Sleep(TimeDelay);
            Assert.AreEqual("Тест", MessageConverter.ConvertedMessages[0]);
            server.StopServer();
        }
        [Test, Order(4)]
        public void SendBroadcastMessageTest()
        {
            MyTcpServer server = new MyTcpServer(IPAddress.Loopback, 400);
            server.StartServer();
            Thread.Sleep(TimeDelay);
            MyTcpClient tcpClient1 = new MyTcpClient("Client1");
            tcpClient1.SubscribeToReceiveMessage(MessageConverter.StringConveter);
            Thread.Sleep(TimeDelay);
            MyTcpClient tcpClient2 = new MyTcpClient("Client2");
            tcpClient2.SubscribeToReceiveMessage(MessageConverter.StringConveter);
            tcpClient2.ConnectToServer(IPAddress.Loopback, 400);
            tcpClient1.ConnectToServer(IPAddress.Loopback, 400);
            Thread.Sleep(TimeDelay);
            server.SendBroadcastMessage("Test");
            Thread.Sleep(TimeDelay);
            Assert.AreEqual("Тест", MessageConverter.ConvertedMessages[0]);
            Thread.Sleep(TimeDelay);
            Assert.AreEqual("Тест", MessageConverter.ConvertedMessages[1]);
        }
    }
}