using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3.BaseModels
{
    /// <summary>
    /// Represents the product category.
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// Contains category name.
        /// </summary>
        public string CategoryName { get; private set; }
        /// <summary>
        /// Creates a new product category.
        /// </summary>
        /// <param name="name"></param>
        public ProductCategory(string name)
        {
            if (name != null)
                CategoryName = name.ToLower();
            else
                throw new ArgumentNullException();
        }
        /// <summary>
        /// An object is considered equal to this if it is of type ProductCategory 
        /// and has the same name.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is ProductCategory && (obj as ProductCategory)
                .CategoryName == CategoryName)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a string containing the name of the category.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CategoryName;
        }
        /// <summary>
        /// Returns a hash code from a string with a category name.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return CategoryName.GetHashCode();
        }
    }
}
