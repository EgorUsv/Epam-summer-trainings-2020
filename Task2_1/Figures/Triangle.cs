using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1.Figures
{
    public class Triangle : Figure
    {
        public double[] Sides { get; protected set; }
        public Triangle(double[] sides)
        {
            Sides = sides.Take(3).ToArray();
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
                Enumerable.SequenceEqual(Sides, (obj as Triangle).Sides))
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
            return Sides.Sum();
        }

        public override string ToString()
        {
            return "This is Triangle";
        }
    }
}
