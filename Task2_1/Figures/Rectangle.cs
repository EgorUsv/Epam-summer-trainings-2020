using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1.Figures
{
    public class Rectangle : Figure
    {
        public double[] Sides { get; private set; }

        public Rectangle(double[] sides)
        {
            Sides = sides.Take(2).ToArray();
        }
        public override double Area()
        {
            return Sides[0] * Sides[1];
        }
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
