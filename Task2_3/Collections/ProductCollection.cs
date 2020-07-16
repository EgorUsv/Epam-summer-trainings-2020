using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_3.BaseModels;

namespace Task2_3.Collections
{
    class ProductCollection
    {
        private List<Product> Products { get; set; }

        public ProductCollection(List<Product> products)
        {
            if (products != null)
                Products = products;
            else
                throw new ArgumentNullException();
        }
        public ProductCollection()
        {
            Products = new List<Product>();
        }
        public void AddNewProduct(Product newProduct)
        {
            if (newProduct == null)
                throw new ArgumentNullException();
            if (!Products.Contains(newProduct))
                Products.Add(newProduct);
        }
        public void DeleteProduct(Product delProduct)
        {
            if (delProduct == null)
                throw new ArgumentNullException();
            if (Products.Contains(delProduct))
                Products.Remove(delProduct);
        }
        public void UpdateProduct(Product oldProduct, Product newProduct)
        {
            if (oldProduct == null || newProduct == null)
                throw new ArgumentNullException();
            if (Products.Contains(oldProduct))
                Products.Find(x => x == oldProduct)
                    .UpdateProductInfo(newProduct.Name, newProduct.Price,
                    newProduct.Description, newProduct.ProductType);
            else
                throw new Exception("Old type was not found");
        }
        public List<Product> GetProductsCopy()
        {
            return Products.Take(Products.Count).ToList();
        }
        public void FilterProducts(Predicate<Product> delMatch)
        {
            Products.RemoveAll(delMatch);
        }
        public override bool Equals(object obj)
        {
            if (obj is ProductCollection && Enumerable
                .SequenceEqual((obj as ProductCollection).Products, Products))
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return Products.GetHashCode();
        }
    }
}
