using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1.Figures
{
    /// <summary>
    /// Represents a rectangle type shape.
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Stores the sides of the rectangle.
        /// </summary>
        public double[] Sides { get; private set; }

        /// <summary>
        /// Initializes an object of type Rectangle.
        /// </summary>
        /// <param name="sides"></param>
        public Rectangle(double[] sides)
        {
            Sides = sides.Take(2).ToArray();
        }

        public override double Area()
        {
            return Sides[0] * Sides[1];
        }

        /// <summary>
        /// Compares two figures. Shapes are considered equal 
        /// if they have equal sides.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Rectangle && Enumerable
                .SequenceEqual(Sides, (obj as Rectangle).Sides))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override double Perimeter()
        {
            return 2 * Sides.Sum();
        }

        public override string ToString()
        {
            return "This is Rectangle";
        }
    }
}
