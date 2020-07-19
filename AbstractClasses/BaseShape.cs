using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egor_Usachev_Task3.AbstractClasses
{
    public abstract class BaseShape : BaseFunctions
    {
        public abstract double Area();
        public abstract double Perimeter();
        public BaseShape TryCutShape(BaseShape shape)
        {
            if (Area() > shape.Area())
                return shape;
            else
                throw new Exception("You cannot cut a large " +
                    "shape from a smaller one");
        }
    }
}
