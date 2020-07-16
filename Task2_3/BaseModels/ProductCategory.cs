using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3.BaseModels
{
    public class ProductCategory
    {
        public string CategoryName { get; private set; }
        public ProductCategory(string name)
        {
            if (name != null)
                CategoryName = name.ToLower();
            else
                throw new ArgumentNullException();
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is ProductCategory && (obj as ProductCategory)
                .CategoryName == CategoryName)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return CategoryName;
        }
        public override int GetHashCode()
        {
            return CategoryName.GetHashCode();
        }
    }
}
