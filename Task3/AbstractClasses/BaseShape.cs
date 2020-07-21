using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.AbstractClasses
{
    /// <summary>
    /// Describes basic shape methods.
    /// </summary>
    public abstract class BaseShape : BaseFunctions
    {
        /// <summary>
        /// Returns the area of figure.
        /// </summary>
        /// <returns></returns>
        public abstract double Area();
        /// <summary>
        /// Returns the perimeter of a shape.
        /// </summary>
        /// <returns></returns>
        public abstract double Perimeter();
        /// <summary>
        /// Cuts out a new one from the current shape 
        /// if the new one is smaller.
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public BaseShape TryCutShape(BaseShape shape)
        {
            if (Area() > shape.Area())
                return shape;
            else
                throw new Exception("You cannot cut a large shape from a smaller one");
        }
    }
}
