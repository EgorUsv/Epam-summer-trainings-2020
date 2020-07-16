using System;
using System.Collections.Generic;
using System.Text;
using Task2_3.BaseModels;
using Xunit;

namespace Task2_3Tests.BaseModelsTests
{
    public class ProductTypeTests
    {
        [Fact]
        public void ProductCategoryTest()
        {
            var expected = "prossesor";
            var actual = new ProductType(expected).TypeName;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void EqualsOperatorTest()
        {
            var expected = new ProductType("Graphics card");
            var actual = new ProductType("Graphics card");
            Assert.True(actual == expected);
        }
        [Fact]
        public void EqualsOperatorTest1()
        {
            var expected = new ProductType("Graphics card");
            ProductType actual = null;
            Assert.False(actual == expected);
        }
        [Fact]
        public void EqualsOperatorTest2()
        {
            var expected = new ProductType("Graphics card");
            ProductType actual = null;
            Assert.False(expected == actual);
        }
        [Fact]
        public void NotEqualsOperatorTest()
        {
            var expected = new ProductType("Graphics card");
            ProductType actual = null;
            Assert.True(expected != actual);
        }
        [Fact]
        public void NotEqualsOperatorTest1()
        {
            var expected = new ProductType("Graphics card");
            ProductType actual = null;
            Assert.True(actual != expected);
        }
    }
}
