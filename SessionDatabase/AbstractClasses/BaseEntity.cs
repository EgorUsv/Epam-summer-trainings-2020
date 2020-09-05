using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.AbstractClasses
{
    /// <summary>
    /// Reflects the underlying essence of the model
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Сontains the Id of the entity.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Decomposes an entity into objects.
        /// </summary>
        /// <returns></returns>
        public abstract object[] Deconstruct();
    }
}
