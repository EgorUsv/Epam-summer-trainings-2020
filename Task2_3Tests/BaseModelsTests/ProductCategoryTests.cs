using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Task2_3.BaseModels;

namespace Task2_3Tests.BaseModelsTests
{
    public class ProductCategoryTests
    {
        [Fact]
        public void ProductCategoryTest()
        {
            var expected = "hardware";
            var actual = new ProductCategory(expected).CategoryName;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ProductCategoryEqualsTest()
        {
            var expected = new ProductCategory("category");
            var actual = new ProductCategory("category");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ProductCategoryToStringTest()
        {
            var expected = new ProductCategory("category").ToString();
            var actual = new ProductCategory("category").ToString();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ProductCategoryGetHashCodeTest()
        {
            var expected = new ProductCategory("category").GetHashCode();
            var actual = new ProductCategory("category").GetHashCode();
            Assert.Equal(expected, actual);
        }
    }
}
