using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Messages
{
    public class MessageEventArgs : EventArgs
    {
        public string From { get; }
        public string Message { get; }
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
