using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Messages
{
    public static class MessagesCollection
    {
        private static List<MessageEventArgs> Collection { get; }
        public static MessageWork AddMessage = (message) =>
        {
            if (message != null)
                Collection.Add(message);
        };
        public static int GetCountOfMessages()
        {
            return Collection.Count;
        }
    }
}
