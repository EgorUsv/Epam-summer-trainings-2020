using Egor_Usachev_Task3.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egor_Usachev_Task3.Shapes
{
    public class Square : Rectangle
    {
        public double Side { get; private set; }
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
            return GetType().FullName + " " + Side;
        }
    }
}
