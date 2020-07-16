using System;
using System.Collections.Generic;
using System.Text;
using Task2_3.BaseModels;
using Task2_3.Collections;
using Xunit;

namespace Task2_3Tests.CollectionsTests
{
    public class ProductCollectionTests
    {
        [Fact]
        public void ProductsTest()
        {
            var productsType = new ProductType("Phone");
            List<Product> productsList = new List<Product>();
            productsList.Add(new Product("Xiaomi Redmi Note 8", 540, "Smartphone", productsType));
            productsList.Add(new Product("Apple Iphone 11", 1200, "Smartphone", productsType));
            productsList.Add(new Product("Huawei P30", 1120, "Smartphone", productsType));
            productsList.Add(new Product("Google Pixel 3a", 870, "Smartphone", productsType));
            var products = new ProductCollection(productsList);
            Assert.Equal(productsList, products.GetProductsCopy());
        }
        [Fact]
        public void ProductsAddNewProductTest()
        {
            var productsType = new ProductType("Phone");
            var products = new ProductCollection();
            products.AddNewProduct(new Product("Xiaomi Redmi Note 8", 540, "Smartphone", productsType));
            products.AddNewProduct(new Product("Apple Iphone 11", 1200, "Smartphone", productsType));
            var productList = new List<Product>();
            productList.Add(new Product("Xiaomi Redmi Note 8", 540, "Smartphone", productsType));
            productList.Add(new Product("Apple Iphone 11", 1200, "Smartphone", productsType));
            Assert.Equal(productList, products.GetProductsCopy());
        }
        [Fact]
        public void ProductsAddNewProductTest1()
        {
            var productsType = new ProductType("Phone");
            var products = new ProductCollection();
            products.AddNewProduct(new Product("Xiaomi Redmi Note 8", 540, "Smartphone", productsType));
            products.AddNewProduct(new Product("Xiaomi Redmi Note 8", 540, "Smartphone", productsType));
            var productList = new List<Product>();
            productList.Add(new Product("Xiaomi Redmi Note 8", 540, "Smartphone", productsType));
            Assert.Equal(productList, products.GetProductsCopy());
        }
        [Fact]
        public void ProductsDeleteTest()
        {
            var products = new ProductCollection();
            var product = new Product("Xiaomi Redmi Note 8", 540, "Smartphone", new ProductType("Phone"));
            products.AddNewProduct(product);
            products.DeleteProduct(product);
            Assert.Equal(new List<Product>(), products.GetProductsCopy());
        }
        [Fact]
        public void ProductsUpdateTest()
        {
            var products = new ProductCollection();
            var product = new Product("Xiaomi Redmi Note 8", 540, "Smartphone", new ProductType("Phone"));
            products.AddNewProduct(product);
            var expected = new Product("Xiaomi Redmi 8A", 350, "Smartphone", new ProductType("Phone"));
            products.UpdateProduct(product, expected);
            Assert.Equal(expected, products.GetProductsCopy()[0]);
        }
    }
}
