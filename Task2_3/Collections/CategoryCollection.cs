using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_3.BaseModels;

namespace Task2_3.Collections
{
    /// <summary>
    /// Represents a collection of all products and all types.
    /// </summary>
    public class CategoryCollection
    {
        /// <summary>
        /// Contains all products.
        /// </summary>
        private Dictionary<ProductCategory, TypeCollection> AllCategories { get; set; }
        /// <summary>
        /// Single instance of an object.
        /// </summary>
        private static CategoryCollection categories;
        /// <summary>
        /// Instance access.
        /// </summary>
        /// <returns></returns>
        public static CategoryCollection GetObject()
        {
            if (categories == null)
                categories = new CategoryCollection();
            return categories;
        }
        /// <summary>
        /// Creating a single instance of a class.
        /// </summary>
        private CategoryCollection()
        {
            AllCategories = new Dictionary<ProductCategory, TypeCollection>();
        }
        /// <summary>
        /// Adding a new category.
        /// </summary>
        /// <param name="newCategory"></param>
        /// <param name="types"></param>
        public void AddNewCategory(ProductCategory newCategory, TypeCollection types)
        {
            if (newCategory == null)
                throw new ArgumentNullException();
            if (!AllCategories.ContainsKey(newCategory))
                AllCategories.Add(newCategory, types);
        }
        /// <summary>
        /// Removing a category from the list.
        /// </summary>
        /// <param name="delCategory"></param>
        public void DeleteCategory(ProductCategory delCategory)
        {
            if (AllCategories.TryGetValue(delCategory, out TypeCollection types)
                && types.GetTypesCount() == 0)
                AllCategories.Remove(delCategory);
        }
        /// <summary>
        /// Getting a list of product types by category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public TypeCollection GetProducts(ProductCategory category)
        {
            AllCategories.TryGetValue(category, out TypeCollection products);
            return products;
        }
        /// <summary>
        /// Сompares the contents of an object with a dictionary.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool SequenceEqual(Dictionary<ProductCategory, TypeCollection> obj)
        {
            if (Enumerable.SequenceEqual(AllCategories, obj))
                return true;
            else
                return false;
        }
    }
}
