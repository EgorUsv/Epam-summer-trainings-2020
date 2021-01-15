using Store.StoreProducts.ComputerComponents;
using Store.StoreProducts.Periphery;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreTests.ProductsOperatorTests
{
    public class ProssesorTests
    {
        [Fact]
        public void SumOperatorTest()
        {
            Prossesor prossesor1 = new Prossesor("AMD Ryzen 5 3600", 401, 12);
            Prossesor prossesor2 = new Prossesor("Intel Core i5-10400", 401, 12);
            Prossesor sum = prossesor1 + prossesor2;
            Assert.Equal(new Prossesor("AMD Ryzen 5 3600-Intel Core i5-10400", 401, 24), sum);
        }
        [Fact]
        public void CastToMotherboardOperatorTest()
        {
            Prossesor prossesor = new Prossesor("AMD Ryzen 5 3600", 401, 12);
            Motherboard motherboard = (Motherboard)prossesor;
            Assert.Equal(new Motherboard("AMD Ryzen 5 3600", 401, 12), motherboard);
        }
        [Fact]
        public void CastToKeyboardOperatorTest()
        {
            Prossesor prossesor = new Prossesor("AMD Ryzen 5 3600", 401, 12);
            Keyboard keyboard = (Keyboard)prossesor;
            Assert.Equal(new Keyboard("AMD Ryzen 5 3600", 401, 12), keyboard);
        }
        [Fact]
        public void CastToMouseOperatorTest()
        {
            Prossesor prossesor = new Prossesor("AMD Ryzen 5 3600", 401, 12);
            Mouse mouse = (Mouse)prossesor;
            Assert.Equal(new Mouse("AMD Ryzen 5 3600", 401, 12), mouse);
        }
    }
}
