using Store.StoreProducts.ComputerComponents;
using Store.StoreProducts.Periphery;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreTests.ProductsOperatorTests
{
    public class MouseTests
    {
        [Fact]
        public void SumOperatorTest()
        {
            Mouse mouse1 = new Mouse("Genesis Thor 300", 100, 26);
            Mouse mouse2 = new Mouse("Logitech TGX 100", 90, 26);
            Mouse sum = mouse1 + mouse2;
            Assert.Equal(new Mouse("Genesis Thor 300-Logitech TGX 100", 85, 52), sum);
        }
        [Fact]
        public void CastToMotherboardOperatorTest()
        {
            Mouse mouse = new Mouse("Logitech G102", 58, 43);
            Motherboard motherboard = (Motherboard)mouse;
            Assert.Equal(new Motherboard("Logitech G102", 58, 43), motherboard);
        }
        [Fact]
        public void CastToProssesorOperatorTest()
        {
            Mouse mouse = new Mouse("Logitech G102", 58, 43);
            Prossesor prossesor = (Prossesor)mouse;
            Assert.Equal(new Prossesor("Logitech G102", 58, 43), prossesor);
        }
        [Fact]
        public void CastToKeyboardOperatorTest()
        {
            Mouse mouse = new Mouse("Logitech G102", 58, 43);
            Keyboard keyboard = (Keyboard)mouse;
            Assert.Equal(new Keyboard("Logitech G102", 58, 43), keyboard);
        }
    }
}
