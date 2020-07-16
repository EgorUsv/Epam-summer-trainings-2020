using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_3.BaseModels;

namespace Task2_3.Collections
{
    /// <summary>
    /// Introduces a product container.
    /// </summary>
    public class ProductCollection
    {
        /// <summary>
        /// Contains a list of products.
        /// </summary>
        private List<Product> Products { get; set; }
        /// <summary>
        /// Creates an object.
        /// </summary>
        /// <param name="products"></param>
        public ProductCollection(List<Product> products)
        {
            if (products != null)
                Products = products;
            else
                throw new ArgumentNullException();
        }
        /// <summary>
        /// Creates an object with an empty product list.
        /// </summary>
        public ProductCollection()
        {
            Products = new List<Product>();
        }
        /// <summary>
        /// Adds a new product to the list.
        /// </summary>
        /// <param name="newProduct"></param>
        public void AddNewProduct(Product newProduct)
        {
            if (newProduct == null)
                throw new ArgumentNullException();
            if (!Products.Contains(newProduct))
                Products.Add(newProduct);
        }
        /// <summary>
        /// Removes a product from the list.
        /// </summary>
        /// <param name="delProduct"></param>
        public void DeleteProduct(Product delProduct)
        {
            if (delProduct == null)
                throw new ArgumentNullException();
            if (Products.Contains(delProduct))
                Products.Remove(delProduct);
        }
        /// <summary>
        /// Updates product information.
        /// </summary>
        /// <param name="oldProduct"></param>
        /// <param name="newProduct"></param>
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
        /// <summary>
        /// Returns a copy of the product list.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductsCopy()
        {
            return Products.Take(Products.Count).ToList();
        }
        /// <summary>
        /// Removes products from the list by the 
        /// specified condition.
        /// </summary>
        /// <param name="delMatch"></param>
        public void FilterProducts(Predicate<Product> delMatch)
        {
            Products.RemoveAll(delMatch);
        }
        /// <summary>
        /// Returns true if the object is a ProductCollection type and 
        /// has the same product list.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is ProductCollection && Enumerable
                .SequenceEqual((obj as ProductCollection).Products, Products))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a hash from a list of products.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Products.GetHashCode();
        }
    }
}
