using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_3.BaseModels;

namespace Task2_3.Collections
{
    class TypeCollection
    {
        private Dictionary<ProductType, ProductCollection> TypesAndProducts { get; set; }
        public TypeCollection(Dictionary<ProductType, ProductCollection> pairs)
        {
            if (pairs != null)
                TypesAndProducts = pairs;
            else
                throw new ArgumentNullException();
        }
        public TypeCollection()
        {
            TypesAndProducts = new Dictionary<ProductType, ProductCollection>();
        }
        public void AddNewType(ProductType newType, ProductCollection products)
        {
            if (!TypesAndProducts.ContainsKey(newType))
            {
                if (products == null)
                    TypesAndProducts.Add(newType, new ProductCollection());
                else
                {
                    products.FilterProducts(x => x.ProductType != newType);
                    TypesAndProducts.Add(newType, products);
                }
            }
        }
        public void DeleteType(ProductType delType)
        {
            if (delType == null)
                throw new ArgumentNullException();
            if (TypesAndProducts.TryGetValue(delType, out ProductCollection products)
                && products.GetProductsCopy().Count == 0)
                TypesAndProducts.Remove(delType);
        }
        public int GetTypesCount()
        {
            return TypesAndProducts.Count;
        }
        public override bool Equals(object obj)
        {
            if (obj is TypeCollection && Enumerable
                .SequenceEqual((obj as TypeCollection).TypesAndProducts, TypesAndProducts))
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return TypesAndProducts.GetHashCode();
        }
        public bool SequenceEqual(Dictionary<ProductType, ProductCollection> obj)
        {
            if (Enumerable.SequenceEqual(TypesAndProducts, obj))
                return true;
            else
                return false;
        }
    }
}
