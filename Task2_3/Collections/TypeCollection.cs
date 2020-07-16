using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_3.BaseModels;

namespace Task2_3.Collections
{
    public class TypeCollection
    {
        private Dictionary<ProductType, ProductCollection> TypeProducts { get; set; }
        public TypeCollection(Dictionary<ProductType, ProductCollection> typeProducts)
        {
            if (typeProducts != null)
                TypeProducts = typeProducts;
            else
                throw new ArgumentNullException();
        }
        public TypeCollection()
        {
            TypeProducts = new Dictionary<ProductType, ProductCollection>();
        }
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
        public void DeleteType(ProductType delType)
        {
            if (delType == null)
                throw new ArgumentNullException();
            if (TypeProducts.TryGetValue(delType, out ProductCollection products)
                && products.GetProductsCopy().Count == 0)
                TypeProducts.Remove(delType);
        }
        public int GetTypesCount()
        {
            return TypeProducts.Count;
        }
        public override bool Equals(object obj)
        {
            if (obj is TypeCollection && Enumerable
                .SequenceEqual((obj as TypeCollection).TypeProducts, TypeProducts))
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return TypeProducts.GetHashCode();
        }
        public bool SequenceEqual(Dictionary<ProductType, ProductCollection> obj)
        {
            if (Enumerable.SequenceEqual(TypeProducts, obj))
                return true;
            else
                return false;
        }
    }
}
