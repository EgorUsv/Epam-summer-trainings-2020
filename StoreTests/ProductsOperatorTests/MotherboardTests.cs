using Store.StoreProducts.ComputerComponents;
using Store.StoreProducts.Periphery;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreTests.ProductsOperatorTests
{
    public class MotherboardTests
    {
        [Fact]
        public void SumOperatorTest()
        {
            Motherboard motherboard1 = new Motherboard("Asus Pro B540", 320, 15);
            Motherboard motherboard2 = new Motherboard("Acer Ultimate A540", 220, 15);
            Motherboard sum = motherboard1 + motherboard2;
            Assert.Equal(new Motherboard("Asus Pro B540-Acer Ultimate A540", 270, 30), sum);
        }
        [Fact]
        public void CastToProssesorOperatorTest()
        {
            Motherboard motherboard = new Motherboard("Asus Pro B540", 320, 15);
            Prossesor prossesor = (Prossesor)motherboard;
            Assert.Equal(new Prossesor("Asus Pro B540", 320, 15), prossesor);
        }
        [Fact]
        public void CastToKeyboardOperatorTest()
        {
            Motherboard motherboard = new Motherboard("Asus Pro B540", 320, 15);
            Keyboard keyboard = (Keyboard)motherboard;
            Assert.Equal(new Keyboard("Asus Pro B540", 320, 15), keyboard);
        }
        [Fact]
        public void CastToMouseOperatorTest()
        {
            Motherboard motherboard = new Motherboard("Asus Pro B540", 320, 15);
            Mouse mouse = (Mouse)motherboard;
            Assert.Equal(new Mouse("Asus Pro B540", 320, 15), mouse);
        }
    }
}
