using System;
using Xunit;
using Client;
using Server;
using System.Net;
using System.Threading;
using CollectionOfMessages;
using Server.Messages;
using System.Net.Sockets;
using Client.Handlers;

namespace Tests
{
    public class ServerTests
    {
        public const int TimeDelay = 5;
        [Fact]
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
            Assert.Equal(expected, actual);

            MyTcpClient client2 = new MyTcpClient("NewUser2");
            client2.ConnectToServer(IPAddress.Loopback, 100);
            Thread.Sleep(TimeDelay);
            client2.SendMessage("TestMessage2");
            Thread.Sleep(TimeDelay);
            var expected2 = new MessageEventArgs("NewUser2", "TestMessage2").ToString();
            var actual2 = MessagesCollection<MessageEventArgs>.ElementAt(1);
            Assert.Equal(expected2, actual2);
            privateServer.StopServer();
        }
        [Fact]
        public void StopServerTest()
        {
            MyTcpServer server = new MyTcpServer(IPAddress.Loopback, 200);
            server.StartServer();
            Thread.Sleep(TimeDelay);
            server.StopServer();
            Thread.Sleep(TimeDelay);
            try
            {
                if(new MyTcpClient("User").ConnectToServer(IPAddress.Loopback, 200))
                    Assert.True(false);
            }
            catch (SocketException)
            {
                Assert.True(true);
            }
        }
        [Fact]
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
            Assert.Equal("Тест", MessageConverter.LastConvertedMessage);
        }
    }
}
