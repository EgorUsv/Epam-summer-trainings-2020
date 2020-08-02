using Serializer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serializer.AbstractClasses
{
    public abstract class BaseSerializer<T>
    {
        protected string Path { get; set; }
        public BaseSerializer(string path)
        {
            Path = path;
        }
        public abstract void Serialize(T data);
        public abstract void Serialize(ICollection<T> collection);
        public abstract bool Deserialize(out T data);
    }
}
