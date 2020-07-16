using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_3.BaseModels;

namespace Task2_3.Collections
{
    /// <summary>
    /// Represents a container for product types.
    /// </summary>
    public class TypeCollection
    {
        /// <summary>
        /// Contains a key - product type, value - a list of products of this type.
        /// </summary>
        private Dictionary<ProductType, ProductCollection> TypeProducts { get; set; }
        /// <summary>
        /// Initializes an object of type TypeCollection.
        /// </summary>
        /// <param name="typeProducts"></param>
        public TypeCollection(Dictionary<ProductType, ProductCollection> typeProducts)
        {
            if (typeProducts != null)
                TypeProducts = typeProducts;
            else
                throw new ArgumentNullException();
        }
        /// <summary>
        /// Initializes an object with an empty list.
        /// </summary>
        public TypeCollection()
        {
            TypeProducts = new Dictionary<ProductType, ProductCollection>();
        }
        /// <summary>
        /// Adds a new type of product to the collection.
        /// </summary>
        /// <param name="newType"></param>
        /// <param name="products"></param>
        public void AddNewType(ProductType newType, ProductCollection products)
        {
            if (!TypeProducts.ContainsKey(newType))
            {
                if (products == null)
                    TypeProducts.Add(newType, new ProductCollection());
                else
                {
                    products.FilterProducts(x => x.ProductType != newType);
                    TypeProducts.Add(newType, products);
                }
            }
        }
        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="delType"></param>
        public void DeleteType(ProductType delType)
        {
            if (delType == null)
                throw new ArgumentNullException();
            if (TypeProducts.TryGetValue(delType, out ProductCollection products)
                && products.GetProductsCopy().Count == 0)
                TypeProducts.Remove(delType);
        }
        /// <summary>
        /// Returns the number of objects in the list.
        /// </summary>
        /// <returns></returns>
        public int GetTypesCount()
        {
            return TypeProducts.Count;
        }
        /// <summary>
        /// Returns true if the object is a TypeCollection and 
        /// has the same collection.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is TypeCollection && Enumerable
                .SequenceEqual((obj as TypeCollection).TypeProducts, TypeProducts))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns the hash code of the collection.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return TypeProducts.GetHashCode();
        }
        /// <summary>
        /// Compares two collections by value.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool SequenceEqual(Dictionary<ProductType, ProductCollection> obj)
        {
            if (Enumerable.SequenceEqual(TypeProducts, obj))
                return true;
            else
                return false;
        }
    }
}
