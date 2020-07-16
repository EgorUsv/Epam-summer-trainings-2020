using System;
using System.Collections.Generic;
using System.Text;
using Task2_3.BaseModels;
using Xunit;

namespace Task2_3Tests.BaseModelsTests
{
    public class ProductTests
    {
        [Fact]
        public void ProductTest()
        {
            var product = new Product("Intel Core i5-4460", 150, "CPU", new ProductType("processor"));
            var expected = ("Intel Core i5-4460", 150, "CPU", new ProductType("processor"));
            var actual = (product.Name, product.Price, product.Description, product.ProductType);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void UpdateProductInfoTest()
        {
            var actual = new Product("Intel Core i5-4460", 150, "CPU", new ProductType("processor"));
            actual.UpdateProductInfo("Intel Core i7-4770", 420, "CPU", new ProductType("processor"));
            var expected = new Product("Intel Core i7-4770", 420, "CPU", new ProductType("processor"));
            Assert.True(expected.Equals(actual));
        }
        [Fact]
        public void SumProductOperatorTest()
        {
            var product1 = new Product("Core i5-4460", 150, "Intel CPU", new ProductType("processor"));
            var product2 = new Product("Ryzen 5 3600", 410, "AMD CPU", new ProductType("processor"));
            var actual = product1 + product2;
            var expected = new Product("Core i5-4460-Ryzen 5 3600", 280, "Intel CPU-AMD CPU",
                new ProductType("processor"), 2);
            Assert.True(expected.Equals(actual));
        }
        [Fact]
        public void SumProductOperatorTest1()
        {
            var product1 = new Product("Core i5-4460", 150, "Intel CPU", new ProductType("processor"));
            var product2 = new Product("Ryzen 5 3600", 410, "AMD CPU", new ProductType("Graphics card"));
            var actual = product1 + product2;
            Product expected = null;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ProductCastTest()
        {
            var actual = new Product("Core i5-4460", 150, "Intel CPU", new ProductType("processor"));
            var expected = new Product("Ryzen 5 3600", 410, "AMD CPU", new ProductType("Graphics card"));
            actual.CastTo(new ProductType("Graphics card"));
            Assert.Equal(expected.ProductType, actual.ProductType);
        }
        [Fact]
        public void ProductExplicitToIntTest()
        {
            var product = new Product("Core i5-4460", 150.55M, "Intel CPU", new ProductType("processor"));
            int expected = 15055;
            int actual = (int)product;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ProductExplicitToFloatTest()
        {
            var product = new Product("Core i5-4460", 150.55M, "Intel CPU", new ProductType("processor"));
            float expected = 150.55F;
            var actual = (float)product;
            Assert.Equal(expected, actual);
        }
    }
}
