using Store.StoreProducts.ComputerComponents;
using Store.StoreProducts.Periphery;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreTests
{
    public partial class ProductsTests
    {
        public static IEnumerable<object[]> ConstructorData()
        {
            yield return new object[] { "Asus Pro B540", 320M, 15, new Motherboard("Asus Pro B540", 320, 15) };
            yield return new object[] { "AMD Ryzen 3600", 401M, 12, new Prossesor("AMD Ryzen 3600", 401, 12) };
            yield return new object[] { "Genesis Thor 300", 100, 26, new Keyboard("Genesis Thor 300", 100, 26) };
            yield return new object[] { "Logitech G102", 58, 43, new Mouse("Logitech G102", 58, 43) };
        }
        public static IEnumerable<object[]> EqualsData()
        {
            yield return new object[] { new Motherboard("Asus Pro B540", 320, 15), new Motherboard("Asus Pro B540", 320, 15) };
            yield return new object[] { new Prossesor("AMD Ryzen 3600", 401, 12), new Prossesor("AMD Ryzen 3600", 401, 12) };
            yield return new object[] { new Keyboard("Genesis Thor 300", 100, 26), new Keyboard("Genesis Thor 300", 100, 26) };
            yield return new object[] { new Mouse("Logitech G102", 58, 43), new Mouse("Logitech G102", 58, 43) };
        }
        public static IEnumerable<object[]> GetHashCodeData()
        {
            yield return new object[] { new Motherboard("Asus Pro B540", 320, 15), new Motherboard("Asus B550", 800, 13) };
            yield return new object[] { new Prossesor("AMD Ryzen 3600", 401, 12), new Prossesor("AMD Ryzen 4800", 410, 12) };
            yield return new object[] { new Keyboard("Genesis Thor 300", 100, 26), new Keyboard("Genesis Thor 320", 100, 26) };
            yield return new object[] { new Mouse("Logitech G102", 58, 43), new Mouse("Logitech G107", 58, 43) };
        }
        public static IEnumerable<object[]> ToStringData()
        {
            string motherboardToString = "Asus Pro B550, Price: 320, Count: 15, Manufacturer: , CPU Manufaturer: , " +
                $"CountOfMemorySlots: 0";
            yield return new object[] { motherboardToString, new Motherboard("Asus Pro B550", 320, 15) };
            string prossesorToString = $"AMD Ryzen 3600, Price: 410, Count : 12, Manufacturer: , CountOfCores: 0, " +
                $"Socket: ";
            yield return new object[] { prossesorToString, new Prossesor("AMD Ryzen 3600", 410, 12) };
            string keyboardToString = $"Genesis Thor 320, Price: 100, Count: 26, Connection interface: , SwitchTechnology: ";
            yield return new object[] { keyboardToString, new Keyboard("Genesis Thor 320", 100, 26) };
            string mouseToString = $"Logitech G107, Price: 58, Count: 43, Connection interface: , DPI: 0";
            yield return new object[] { mouseToString, new Mouse("Logitech G107", 58, 43) };
        }
    }
}
