using Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionOfMessages
{
    public static class MessagesCollection<T>
    {
        private static List<T> Collection { get; }
        public static MessageWork AddMessage = (message) =>
        {
            if (message != null)
                Collection.Add((T)message);
        };
        public static int GetCountOfMessages()
        {
            return Collection.Count;
        }
    }
}
