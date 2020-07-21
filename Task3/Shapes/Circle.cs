using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractClasses;

namespace Task3.Shapes
{
    /// <summary>
    /// Represents a circle type shape.
    /// </summary>
    public class Circle : BaseShape
    {
        /// <summary>
        /// Stores the radius of the circle.
        /// </summary>
        public double Radius { get; private set; }
        /// <summary>
        /// Initializes an object of type Circle.
        /// </summary>
        /// <param name="sides"></param>
        public Circle(double radius)
        {
            if (radius > 0)
                Radius = radius;
            else
                throw new ArgumentException("Radius can not be negative");
        }
        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Circle && (obj as Circle)?.Radius == Radius)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode();
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return GetType().AssemblyQualifiedName + " " + Radius;
        }
    }
}
