using Egor_Usachev_Task3.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egor_Usachev_Task3.Shapes
{
    class Circle : BaseShape
    {
        public double Radius { get; private set; }
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
            return GetType().FullName + " " + Radius;
        }
    }
}
