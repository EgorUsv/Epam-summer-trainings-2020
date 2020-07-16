using System;
using System.Collections.Generic;
using System.Text;
using Task2_3.BaseModels;
using Task2_3.Collections;
using Xunit;

namespace Task2_3Tests.CollectionsTests
{
    public class CategoryCollectionTests
    {
        [Fact]
        public void CategoriesTest()
        {
            var category = new ProductCategory("cars");
            CategoryCollection categories = CategoryCollection.GetObject();
            categories.AddNewCategory(category, new TypeCollection());
            Assert.Equal(new TypeCollection(), categories.GetProducts(category));
        }
        [Fact]
        public void DeleteCategoryTest()
        {
            var category = new ProductCategory("cars");
            CategoryCollection categories = CategoryCollection.GetObject();
            categories.AddNewCategory(category, new TypeCollection());
            categories.DeleteCategory(category);
            Assert.True(categories.SequenceEqual(new Dictionary<ProductCategory, 
                TypeCollection>()));
        }
    }
}
