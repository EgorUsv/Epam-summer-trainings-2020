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
    public class Square : Figure
    {
        /// <summary>
        /// Stores the sides of the rectangle.
        /// </summary>
        public double Side { get; private set; }

        /// <summary>
        /// Initializes an object of type Square.
        /// </summary>
        /// <param name="side"></param>
        public Square(double side)
        {
            Side = side;
        }
        public override double Area()
        {
            return Math.Pow(Side, 2);
        }

        /// <summary>
        /// Compares two figures. Shapes are considered equal 
        /// if they have equal sides.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Square && Side == (obj as Square).Side)
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
            return 4 * Side;
        }

        public override string ToString()
        {
            return "This is Square";
        }
    }
}
