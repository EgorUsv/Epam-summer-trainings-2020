using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.AbstractClasses
{
    /// <summary>
    /// Describes the basic functions of the classes.
    /// </summary>
    public abstract class BaseFunctions
    {
        /// <summary>
        /// Compares two figures. Shapes are considered equal 
        /// if they have equal sides (side).
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract override string ToString();
    }
}
