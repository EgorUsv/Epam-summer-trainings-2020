using System;
using System.Collections.Generic;
using System.Text;
using Task2_3.BaseModels;
using Task2_3.Collections;
using Xunit;

namespace Task2_3Tests.CollectionsTests
{
    public class TypeCollectionTests
    {
        public TypeCollection ProductsType { get; set; }
        public ProductCollection TestProducts { get; set; }
        Dictionary<ProductType, ProductCollection> TestDictionary { get; set; }
        public TypeCollectionTests()
        {
            ProductsType = new TypeCollection();
            TestDictionary = new Dictionary<ProductType, ProductCollection>();
            List<Product> productsList = new List<Product>();
            TestProducts = new ProductCollection(productsList);
            productsList.Add(new Product("usb hub 4", 14.32M, "NoName", new ProductType("periphery")));
            productsList.Add(new Product("mouse pad", 10.1M, "NoName", new ProductType("periphery")));
            ProductsType.AddNewType(new ProductType("periphery"), TestProducts);
            TestDictionary.Add(new ProductType("periphery"), TestProducts);
        }
        [Fact]
        public void TypesTest()
        {
            var products = new TypeCollection();
            Assert.Equal(0, products.GetTypesCount());
        }
        [Fact]
        public void TypesTest1()
        {
            var products = new TypeCollection(TestDictionary);
            Assert.True(products.SequenceEqual(TestDictionary));
        }
        [Fact]
        public void AddNewTypeTest()
        {
            var products = new TypeCollection();
            var expected = new Dictionary<ProductType, ProductCollection>();
            expected.Add(new ProductType("periphery"), TestProducts);
            products.AddNewType(new ProductType("periphery"), TestProducts);
            Assert.True(products.SequenceEqual(expected));
        }
        [Fact]
        public void DeleteTypeTest()
        {
            var actual = new TypeCollection();
            var expected = new Dictionary<ProductType, ProductCollection>();
            expected.Add(new ProductType("periphery"), TestProducts);
            actual.AddNewType(new ProductType("periphery"), TestProducts);
            actual.DeleteType(new ProductType("periphery"));
            Assert.True(actual.SequenceEqual(expected));
        }
        [Fact]
        public void DeleteTypeTest1()
        {
            var expected = new Dictionary<ProductType, ProductCollection>();
            var actual = new TypeCollection();
            actual.AddNewType(new ProductType("periphery"), null);
            actual.DeleteType(new ProductType("periphery"));
            Assert.True(actual.SequenceEqual(expected));
        }
    }
}
