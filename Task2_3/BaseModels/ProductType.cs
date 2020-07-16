using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3.BaseModels
{
    /// <summary>
    /// Represents the product type.
    /// </summary>
    public class ProductType
    {
        /// <summary>
        /// Contains a type name.
        /// </summary>
        public string TypeName { get; private set; }
        /// <summary>
        /// Create a new type of products.
        /// </summary>
        /// <param name="typeName"></param>
        public ProductType(string typeName)
        {
            if (typeName != null)
                TypeName = typeName.ToLower();
            else
                throw new ArgumentNullException();
        }
        /// <summary>
        /// Overloading the equality operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ProductType left, ProductType right)
        {
            if ((object)left == null && (object)right == null)
                return true;
            if ((object)left != null && left.Equals(right))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Overloading the inequality operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ProductType left, ProductType right)
        {
            if ((object)left == null && (object)right == null)
                return false;
            if ((object)left != null && left.Equals(right))
                return false;
            else
                return true;
        }
        /// <summary>
        /// Objects are considered equal if they have the same name.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is ProductType && (obj as ProductType)
                ?.TypeName == TypeName)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a hash code from a string containing the type name.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return TypeName.GetHashCode();
        }
        /// <summary>
        /// Returns a string containing the type name.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TypeName;
        }
    }
}
