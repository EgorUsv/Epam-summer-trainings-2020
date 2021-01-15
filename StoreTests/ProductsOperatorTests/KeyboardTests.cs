using Store.StoreProducts.ComputerComponents;
using Store.StoreProducts.Periphery;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreTests.ProductsOperatorTests
{
    public class KeyboardTests
    {
        [Fact]
        public void SumOperatorTest()
        {
            Keyboard keyboard1 = new Keyboard("Genesis Thor 300", 100, 26);
            Keyboard keyboard2 = new Keyboard("Logitech TGX 100", 90, 26);
            Keyboard sum = keyboard1 + keyboard2;
            Assert.Equal(new Keyboard("Genesis Thor 300-Logitech TGX 100", 85, 52), sum);
        }
        [Fact]
        public void CastToMotherboardOperatorTest()
        {
            Keyboard keyboard = new Keyboard("Genesis Thor 300", 100, 26);
            Motherboard motherboard = (Motherboard)keyboard;
            Assert.Equal(new Motherboard("Genesis Thor 300", 100, 26), motherboard);
        }
        [Fact]
        public void CastToProssesorOperatorTest()
        {
            Keyboard keyboard = new Keyboard("Genesis Thor 300", 100, 26);
            Prossesor prossesor = (Prossesor)keyboard;
            Assert.Equal(new Prossesor("Genesis Thor 300", 100, 26), prossesor);
        }
        [Fact]
        public void CastToMouseOperatorTest()
        {
            Keyboard keyboard = new Keyboard("Genesis Thor 300", 100, 26);
            Mouse mouse = (Mouse)keyboard;
            Assert.Equal(new Mouse("Genesis Thor 300", 100, 26), mouse);
        }
    }
}
