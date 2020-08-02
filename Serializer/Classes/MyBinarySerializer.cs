using Serializer.AbstractClasses;
using Serializer.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializer.Classes
{
    public class MyBinarySerializer<T> : BaseSerializer<T>
        where T : class, ISerialize
    {
        public MyBinarySerializer(string path) : base(path)
        { }

        public override bool Deserialize(out T data)
        {
            try
            {
                using FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
                var wrapper = (Wrapper<T>)new BinaryFormatter().Deserialize(fs);
                if (wrapper.Data.GetHashCode() == wrapper.HashCode)
                {
                    data = wrapper.Data;
                    return true;
                }
                else
                    data = null;
                return false;
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
                using FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
                var wrapper = (Wrapper<List<T>>)new BinaryFormatter().Deserialize(fs);
                if (GetCollectionHashCode(wrapper.Data) == wrapper.HashCode)
                {
                    data = wrapper.Data;
                    return true;
                }
                else
                    data = null;
                return false;
            }
            catch (SerializationException)
            {
                data = null;
                return false;
            }
        }

        public override void Serialize(T data)
        {
            var wrapper = new Wrapper<T>(data, data.GetHashCode());
            using FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
            new BinaryFormatter().Serialize(fs, wrapper);
        }

        public override void Serialize(ICollection<T> collection)
        {
            var wrapper = new Wrapper<List<T>>((List<T>)collection, GetCollectionHashCode(collection));
            using FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
            new BinaryFormatter().Serialize(fs, wrapper);
        }
    }
}
