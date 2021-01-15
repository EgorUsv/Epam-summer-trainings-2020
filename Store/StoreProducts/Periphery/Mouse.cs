using Store.BaseClasses;
using Store.StoreProducts.ComputerComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.StoreProducts.Periphery
{
    /// <summary>
    /// Represents an item of type mouse.
    /// </summary>
    public class Mouse : BaseProduct
    {
        /// <summary>
        /// Сontains the connection interface.
        /// </summary>
        public string ConnectionInterface { get; set; }
        /// <summary>
        /// Contains the maximum resolution of the sensor.
        /// </summary>
        public int Dpi { get; set; }
        /// <summary>
        /// Initializes a new object of type mouse.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="count"></param>
        public Mouse(string productName, decimal price, int count)
        {
            if (productName != null)
                Name = productName;
            if (price > 0)
                Price = price;
            if (count >= 1)
                Count = count;
        }
        /// <summary>
        /// Overloads the sum operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Mouse operator +(Mouse left, Mouse right)
        {
            return new Mouse(left.Name + "-" + right.Name, (left.Price + right.Price) / 2, left.Count + right.Count);
        }
        /// <summary>
        /// Overload the cast operator to type motherboard.
        /// </summary>
        /// <param name="mouse"></param>
        public static explicit operator Motherboard(Mouse mouse)
        {
            return new Motherboard(mouse.Name, mouse.Price, mouse.Count);
        }
        /// <summary>
        /// Overload the cast operator to type processor.
        /// </summary>
        /// <param name="mouse"></param>
        public static explicit operator Prossesor(Mouse mouse)
        {
            return new Prossesor(mouse.Name, mouse.Price, mouse.Count);
        }
        /// <summary>
        /// Overload the cast operator to type keyboard.
        /// </summary>
        /// <param name="mouse"></param>
        public static explicit operator Keyboard(Mouse mouse)
        {
            return new Keyboard(mouse.Name, mouse.Price, mouse.Count);
        }
        public override bool Equals(object obj)
        {
            if (obj is Mouse && (obj as Mouse)
                .Name == Name)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name}, Price: {Price}, Count: {Count}, " +
                $"Connection interface: {ConnectionInterface}, DPI: {Dpi}";
        }
    }
}
