using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1.Figures
{
    public class Square : Figure
    {
        public double Side { get; private set; }
        public Square(double side)
        {
            Side = side;
        }
        public override double Area()
        {
            return Math.Pow(Side, 2);
        }
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
