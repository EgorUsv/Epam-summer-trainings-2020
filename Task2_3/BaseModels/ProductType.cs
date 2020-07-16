using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3.BaseModels
{
    public class ProductType
    {
        public string TypeName { get; private set; }
        public ProductType(string typeName)
        {
            if (typeName != null)
                TypeName = typeName.ToLower();
            else
                throw new ArgumentNullException();
        }
        public static bool operator ==(ProductType left, ProductType right)
        {
            if ((object)left == null && (object)right == null)
                return true;
            if ((object)left != null && left.Equals(right))
                return true;
            else
                return false;
        }
        public static bool operator !=(ProductType left, ProductType right)
        {
            if ((object)left == null && (object)right == null)
                return false;
            if ((object)left != null && left.Equals(right))
                return false;
            else
                return true;
        }
        public override bool Equals(object obj)
        {
            if (obj is ProductType && (obj as ProductType)
                ?.TypeName == TypeName)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return TypeName.GetHashCode();
        }
        public override string ToString()
        {
            return TypeName;
        }
    }
}
