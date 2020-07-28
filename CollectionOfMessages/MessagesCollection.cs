using Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionOfMessages
{
    /// <summary>
    /// Represents a class for handling various types of messages.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class MessagesCollection<T>
    {
        /// <summary>
        /// Represents a class for storing messages.
        /// </summary>
        private static List<T> Collection { get; } = new List<T>();
        public static MessageWork AddMessage = (message) =>
        {
            if (message != null)
                Collection.Add((T)message);
        };
        /// <summary>
        /// Returns the number of messages.
        /// </summary>
        /// <returns></returns>
        public static int GetCountOfMessages()
        {
            return Collection.Count;
        }
        /// <summary>
        /// Returns the item at index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ElementAt(int index)
        {
            if (index < Collection.Count)
                return Collection[index].ToString();
            return null;
        }
    }
}
