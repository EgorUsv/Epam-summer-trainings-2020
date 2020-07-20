using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3.AbstractClasses;

namespace Task3.Shapes
{
    public class Rectangle : BaseShape
    {
        public double[] Sides { get; private set; } = new double[2];
        public Rectangle(double[] sides)
        {
            if (sides != null && sides.Length >= 2)
                Sides = sides.Take(2).ToArray();
            else
                throw new ArgumentException("Array should have positive values (>=2).");
        }
        public override double Area()
        {
            return Sides[0] * Sides[1];
        }

        public override bool Equals(object obj)
        {
            if (obj is Rectangle && Enumerable
                .SequenceEqual(Sides, (obj as Rectangle)?.Sides))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (Sides[0], Sides[1]).GetHashCode();
        }

        public override double Perimeter()
        {
            return 2 * Sides.Sum();
        }

        public override string ToString()
        {
            return GetType().AssemblyQualifiedName + " " + Sides[0] + 
                " " + Sides[1];
        }
    }
}
