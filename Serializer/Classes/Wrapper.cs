using System;

namespace Serializer.Classes
{
    /// <summary>
    /// Represents a class for serializing an object 
    /// and its hash code.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Wrapper<T>
    {
        /// <summary>
        /// Stores data.
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Stores data hashcode.
        /// </summary>
        public int HashCode { get; set; }
        /// <summary>
        /// Initialize an object.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hashCode"></param>
        public Wrapper(T data, int hashCode)
        {
            Data = data;
            HashCode = hashCode;
        }
        /// <summary>
        /// Initialize an object.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hashCode"></param>
        public Wrapper()
        { }
    }
}
