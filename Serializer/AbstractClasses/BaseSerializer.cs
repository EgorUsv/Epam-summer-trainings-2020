using System.Collections.Generic;

namespace Serializer.AbstractClasses
{
    public abstract class BaseSerializer<T>
    {
        public string Path { get; set; }
        public BaseSerializer(string path)
        {
            Path = path;
        }
        public abstract void Serialize(T data);
        public abstract void Serialize(ICollection<T> collection);
        public abstract bool Deserialize(out T data);
        public abstract bool Deserialize(out ICollection<T> data);
        protected int GetCollectionHashCode(ICollection<T> collection)
        {
            int hashCode = 0;
            int itemsCount = collection.Count;
            foreach (T item in collection)
            {
                if (hashCode != 0)
                    hashCode ^= item.GetHashCode() << itemsCount;
                else
                    hashCode += item.GetHashCode() << itemsCount;
                itemsCount--;
            }
            return hashCode;
        }
    }
}
