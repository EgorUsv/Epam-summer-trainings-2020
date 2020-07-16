using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_3.BaseModels;

namespace Task2_3.Collections
{
    class CategoryCollection
    {
        private Dictionary<ProductCategory, TypeCollection> AllCategories { get; set; }
        private static CategoryCollection categories;
        public static CategoryCollection GetObject()
        {
            if (categories == null)
                categories = new CategoryCollection();
            return categories;
        }
        private CategoryCollection()
        {
            AllCategories = new Dictionary<ProductCategory, TypeCollection>();
        }
        public void AddNewCategory(ProductCategory newCategory, TypeCollection types)
        {
            if (newCategory == null)
                throw new ArgumentNullException();
            if (!AllCategories.ContainsKey(newCategory))
                AllCategories.Add(newCategory, types);
        }
        public void DeleteCategory(ProductCategory delCategory)
        {
            if (AllCategories.TryGetValue(delCategory, out TypeCollection types)
                && types.GetTypesCount() == 0)
                AllCategories.Remove(delCategory);
        }
        public TypeCollection GetProducts(ProductCategory category)
        {
            AllCategories.TryGetValue(category, out TypeCollection products);
            return products;
        }
        public bool SequenceEqual(Dictionary<ProductCategory, TypeCollection> obj)
        {
            if (Enumerable.SequenceEqual(AllCategories, obj))
                return true;
            else
                return false;
        }
    }
}
