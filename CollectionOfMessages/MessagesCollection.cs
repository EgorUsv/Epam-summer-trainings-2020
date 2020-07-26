using Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionOfMessages
{
    public static class MessagesCollection<T>
    {
        private static List<T> Collection { get; } = new List<T>();
        public static MessageWork AddMessage = (message) =>
        {
            if (message != null)
                Collection.Add((T)message);
        };
        public static int GetCountOfMessages()
        {
            return Collection.Count;
        }
        public static string ElementAt(int index)
        {
            if (index < Collection.Count)
                return Collection[index].ToString();
            return null;
        }
    }
}
