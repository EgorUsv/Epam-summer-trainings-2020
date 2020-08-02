using System;
using System.Collections.Generic;
using System.Text;

namespace Serializer.Classes
{
    [Serializable]
    public class Wrapper<T>
    {
        public T Data { get; set; }
        public int HashCode { get; set; }
        public Wrapper(T data, int hashCode)
        {
            Data = data;
            HashCode = hashCode;
        }
        public Wrapper()
        { }
    }
}
