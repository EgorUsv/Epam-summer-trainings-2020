using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3.BaseModels
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Count { get; private set; }
        public string Description { get; private set; }
        public ProductType ProductType { get; private set; }
        public Product(string name, decimal price, string description, ProductType type, int count = 1)
        {
            InitializeProduct(name, price, description, type, count);
        }
        private void InitializeProduct(string name, decimal price, string description, ProductType type, int count = 1)
        {
            Name = name != null ? name : throw new ArgumentNullException("New name");
            Price = price >= 0 ? price : throw new Exception("Price cannot have negative value.");
            Description = description != null ? description : throw new ArgumentNullException("New category");
            ProductType = type != null ? type : throw new ArgumentNullException("New type");
            Count = count >= 1 ? count : throw new Exception("Count must be greater than or equal to one");
        }
        public void UpdateProductInfo(string name, decimal price, string description, ProductType type)
        {
            InitializeProduct(name, price, description, type);
        }
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
        public void CastTo(ProductType newProductType)
        {
            if (newProductType != null)
                ProductType = newProductType;
        }
        public static explicit operator int(Product product)
        {
            int intPart = (int)product.Price;
            return (int)(intPart * 100 + product.Price % intPart * 100);
        }
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
        public override int GetHashCode()
        {
            return (Name, Price, Description, ProductType).GetHashCode();
        }
        public override string ToString()
        {
            return Name + "\n" + Price + "\n" + Count +
                "\n" + Description + "\n" + ProductType.ToString();
        }
    }
}
