using System.Collections.Generic;

namespace Serializer.AbstractClasses
{
    /// <summary>
    /// Represents a base class for serializing various file types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseSerializer<T>
    {
        /// <summary>
        /// Stores the path to the file.
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Initializes the base class.
        /// </summary>
        /// <param name="path"></param>
        public BaseSerializer(string path)
        {
            Path = path;
        }
        /// <summary>
        /// Implements a method for serializing an object.
        /// </summary>
        /// <param name="data"></param>
        public abstract void Serialize(T data);
        /// <summary>
        /// Implements a method for serializing a collection of objects.
        /// </summary>
        /// <param name="collection"></param>
        public abstract void Serialize(ICollection<T> collection);
        /// <summary>
        /// Implements a method to deserialize an object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract bool Deserialize(out T data);
        /// <summary>
        /// Implements a method to deserialize a collection of objects.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract bool Deserialize(out ICollection<T> data);
        /// <summary>
        /// Returns a hash code from a collection of objects.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
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
