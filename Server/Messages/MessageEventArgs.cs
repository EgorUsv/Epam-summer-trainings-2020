using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Messages
{
    /// <summary>
    /// Represents a class for receiving / sending messages.
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Contains client's name
        /// </summary>
        public string From { get; }
        /// <summary>
        /// Contains message.
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// Initializes the object.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="message"></param>
        public MessageEventArgs(string from, string message)
        {
            From = from;
            Message = message;
        }
        public override string ToString()
        {
            return $"{From}: {Message}";
        }
    }
}
