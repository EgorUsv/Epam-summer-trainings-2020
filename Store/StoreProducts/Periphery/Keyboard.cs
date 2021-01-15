using Store.BaseClasses;
using Store.StoreProducts.ComputerComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.StoreProducts.Periphery
{
    /// <summary>
    /// Represents an item of type keyboard.
    /// </summary>
    public class Keyboard : BaseProduct
    {
        /// <summary>
        /// Сontains the connection type.
        /// </summary>
        public string ConnectionInterface { get; set; }
        /// <summary>
        /// Contains the names of the keyboard type.
        /// </summary>
        public string SwitchTechnology { get; set; }
        /// <summary>
        /// Initializes a new object of type keyboard.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="count"></param>
        public Keyboard(string productName, decimal price, int count)
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
        public static Keyboard operator +(Keyboard left, Keyboard right)
        {
            return new Keyboard(left.Name + "-" + right.Name, (left.Price + right.Price) / 2, left.Count + right.Count);
        }
        /// <summary>
        /// Overload the cast operator to type motherboard.
        /// </summary>
        /// <param name="keyboard"></param>
        public static explicit operator Motherboard(Keyboard keyboard)
        {
            return new Motherboard(keyboard.Name, keyboard.Price, keyboard.Count);
        }
        /// <summary>
        /// Overload the cast operator to type processor.
        /// </summary>
        /// <param name="keyboard"></param>
        public static explicit operator Prossesor(Keyboard keyboard)
        {
            return new Prossesor(keyboard.Name, keyboard.Price, keyboard.Count);
        }
        /// <summary>
        /// Overload the cast operator to type mouse.
        /// </summary>
        /// <param name="keyboard"></param>
        public static explicit operator Mouse(Keyboard keyboard)
        {
            return new Mouse(keyboard.Name, keyboard.Price, keyboard.Count);
        }
        public override bool Equals(object obj)
        {
            if (obj is Keyboard && (obj as Keyboard)
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
                $"Connection interface: {ConnectionInterface}, SwitchTechnology: {SwitchTechnology}";
        }
    }
}
