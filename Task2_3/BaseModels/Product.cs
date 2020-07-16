using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3.BaseModels
{
    /// <summary>
    /// Represents the Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Contains product name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Сontains the price of the product.
        /// </summary>
        public decimal Price { get; private set; }
        /// <summary>
        /// Сontains the number of products.
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Сontains a description of the product.
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Сontains the type of product.
        /// </summary>
        public ProductType ProductType { get; private set; }
        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="count"></param>
        public Product(string name, decimal price, string description, ProductType type, int count = 1)
        {
            InitializeProduct(name, price, description, type, count);
        }
        /// <summary>
        /// Initializes product fields.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="count"></param>
        private void InitializeProduct(string name, decimal price, string description, ProductType type, int count = 1)
        {
            Name = name != null ? name : throw new ArgumentNullException("New name");
            Price = price >= 0 ? price : throw new Exception("Price cannot have negative value.");
            Description = description != null ? description : throw new ArgumentNullException("New category");
            ProductType = type != null ? type : throw new ArgumentNullException("New type");
            Count = count >= 1 ? count : throw new Exception("Count must be greater than or equal to one");
        }
        /// <summary>
        /// updates product information.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        public void UpdateProductInfo(string name, decimal price, string description, ProductType type)
        {
            InitializeProduct(name, price, description, type);
        }
        /// <summary>
        /// Operator overload. Fields are initialized in accordance with the task.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Product operator +(Product left, Product right)
        {
            if (left.ProductType == right.ProductType)
            {
                return new Product(left.Name + "-" + right.Name,
                    (left.Price + right.Price) / 2,
                    left.Description + "-" + right.Description,
                    right.ProductType
                    , left.Count + right.Count);
            }
            else
                return default;
        }
        /// <summary>
        /// Сasting the product to a different type.
        /// </summary>
        /// <param name="newProductType"></param>
        public void CastTo(ProductType newProductType)
        {
            if (newProductType != null)
                ProductType = newProductType;
        }
        /// <summary>
        /// Overload of the cast operator to translate the price into pennies.
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator int(Product product)
        {
            int intPart = (int)product.Price;
            return (int)(intPart * 100 + product.Price % intPart * 100);
        }
        /// <summary>
        /// Overloading the cast operator to convert the price to the float type.
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator float(Product product)
        {
            return (float)product.Price;
        }
        public override bool Equals(object obj)
        {
            if (obj is Product && (obj as Product)
                .Name == Name && (obj as Product).Price == Price &&
                (obj as Product).ProductType == ProductType)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a hash from a tuple that contains all the product fields.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (Name, Price, Description, ProductType).GetHashCode();
        }
        /// <summary>
        /// Returns a string that contains all the fields of this object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + "\n" + Price + "\n" + Count +
                "\n" + Description + "\n" + ProductType.ToString();
        }
    }
}
