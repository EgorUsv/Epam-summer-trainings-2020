using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Shapes
{
    /// <summary>
    /// Represents a square type shape.
    /// </summary>
    public class Square : Rectangle
    {
        /// <summary>
        /// Stores the side of the Square.
        /// </summary>
        public double Side { get; private set; }
        /// <summary>
        /// Initializes an object of type Square.
        /// </summary>
        /// <param name="side"></param>
        public Square(double side) : base(new[] { side, side })
        {
            Side = side;
        }
        public override bool Equals(object obj)
        {
            if (obj is Square && Side == (obj as Square)?.Side)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return Side.GetHashCode();
        }
        public override string ToString()
        {
            return GetType().AssemblyQualifiedName + " " + Side;
        }
    }
}
