using Serializer.AbstractClasses;
using Serializer.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Serializer.Classes
{
    public class MyXmlSerializer<T> : BaseSerializer<T>
        where T : class, ISerialize
    {
        public MyXmlSerializer(string path) : base(path)
        { }
        public override bool Deserialize(out T data)
        {
            try
            {
                using FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
                var wrapper = (Wrapper<T>)new XmlSerializer(typeof(Wrapper<T>)).Deserialize(fs);
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
                var wrapper = (Wrapper<List<T>>)new XmlSerializer(typeof(Wrapper<List<T>>)).Deserialize(fs);
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
            using TextWriter tw = new StreamWriter(Path);
            new XmlSerializer(typeof(Wrapper<T>)).Serialize(tw, wrapper);
        }

        public override void Serialize(ICollection<T> collection)
        {
            var wrapper = new Wrapper<List<T>>((List<T>)collection, GetCollectionHashCode(collection));
            using TextWriter tw = new StreamWriter(Path);
            new XmlSerializer(typeof(Wrapper<List<T>>)).Serialize(tw, wrapper);
        }
    }
}
