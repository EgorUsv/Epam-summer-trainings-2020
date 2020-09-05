using SessionDatabase.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.Interfaces
{
    /// <summary>
    /// Reflects a class that has basic crud operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDbCollection<T>
    {
        /// <summary>
        /// Returns an item from the collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Read(long id);
        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);
        /// <summary>
        /// Updates an item in the collection.
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);
        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
    }
}
