using Egor_Usachev_Task3.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egor_Usachev_Task3.Shapes
{
    public class Triangle : BaseShape
    {
        public double[] Sides { get; private set; }
        public Triangle(double[] sides)
        {
            if (sides != null && sides.Length >= 3)
                Sides = sides.Take(3).ToArray();
            else
                throw new ArgumentException("Array length is less than 3.");
        }
        public override double Area()
        {
            double halfPer = Perimeter() / 2.0;
            return Math.Sqrt(halfPer * (halfPer - Sides[0]) * (halfPer - Sides[1])
                * (halfPer - Sides[2]));
        }

        public override bool Equals(object obj)
        {
            if (obj is Triangle &&
                Enumerable.SequenceEqual(Sides, (obj as Triangle)?.Sides))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (Sides[0], Sides[1], Sides[2]).GetHashCode();
        }

        public override double Perimeter()
        {
            return Sides.Sum();
        }

        public override string ToString()
        {
            return GetType().FullName + " " + Sides[0] + " " +
                Sides[1] + " " + Sides[2];
        }
    }
}
