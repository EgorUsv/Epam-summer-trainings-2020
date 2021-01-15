using Store.BaseClasses;
using Store.StoreProducts.ComputerComponents;
using Store.StoreProducts.Periphery;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace StoreTests
{
    public partial class ProductsTests
    {
        [Theory]
        [MemberData(nameof(ConstructorData))]
        public void ConstructorTest(string Name,decimal price,int count,BaseProduct product)
        {
            Assert.Equal(Name, product.Name);
            Assert.Equal(price, product.Price);
            Assert.Equal(count, product.Count);
        }
        [Theory]
        [MemberData(nameof(EqualsData))]
        public void EqualsTest(BaseProduct a, BaseProduct b)
        {
            Assert.True(a.Equals(b));
        }
        [Theory]
        [MemberData(nameof(GetHashCodeData))]
        public void GetHashCodeTest(BaseProduct a, BaseProduct b)
        {
            Assert.True(a.GetHashCode() == a.GetHashCode());
            Assert.True(a.GetHashCode() != b.GetHashCode());
        }
        [Theory]
        [MemberData(nameof(ToStringData))]
        public void ToStringTest(string expected, BaseProduct actual)
        {
            Assert.Equal(expected, actual.ToString());
        }
    }
}
