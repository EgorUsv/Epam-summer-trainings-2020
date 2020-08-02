using Serializer.AbstractClasses;
using Serializer.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Serializer.Classes
{
    public class MyJsonSerializer<T> : BaseSerializer<T>
        where T : class, ISerialize
    {
        public MyJsonSerializer(string path) : base(path)
        { }
        public override bool Deserialize(out T data)
        {
            try
            {
                using Stream stream = new FileStream(Path, FileMode.OpenOrCreate);
                data = (T)new DataContractJsonSerializer(typeof(T)).ReadObject(stream);
                return true;
            }
            catch (SerializationException)
            {
                data = null;
                return false;
            }
        }

        public override bool Deserialize(out ICollection<T> data)
        {
            try
            {
                using Stream stream = new FileStream(Path, FileMode.OpenOrCreate);
                data = (List<T>)new DataContractJsonSerializer(typeof(List<T>))
                    .ReadObject(stream);
                return true;
            }
            catch (SerializationException)
            {
                data = null;
                return false;
            }
        }

        public override void Serialize(T data)
        {
            using Stream stream = new FileStream(Path, FileMode.OpenOrCreate);
            new DataContractJsonSerializer(typeof(T)).WriteObject(stream, data);
        }

        public override void Serialize(ICollection<T> collection)
        {
            using Stream stream = new FileStream(Path, FileMode.OpenOrCreate);
            new DataContractJsonSerializer(typeof(List<T>)).WriteObject(stream, collection);
        }
    }
}
