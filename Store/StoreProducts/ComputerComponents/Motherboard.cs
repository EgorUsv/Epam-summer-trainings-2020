
using Store.BaseClasses;
using Store.StoreProducts.Periphery;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.StoreProducts.ComputerComponents
{
    /// <summary>
    /// Represents an item of type motherboard.
    /// </summary>
    public class Motherboard : BaseProduct
    {
        /// <summary>
        /// Contains the name of the manufacturer of the product.
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Contains the name of the processor manufacturer.
        /// </summary>
        public string ProcessorManufacturer { get; set; }
        /// <summary>
        /// Contains the number of available slots for RAM.
        /// </summary>
        public int CountOfMemorySlots { get; set; }
        /// <summary>
        /// Initializes a new object of type motherboard.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="count"></param>
        public Motherboard(string productName,decimal price,int count)
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
        public static Motherboard operator +(Motherboard left, Motherboard right)
        {
            return new Motherboard(left.Name + "-" + right.Name, (left.Price + right.Price) / 2 ,left.Count + right.Count);
        }
        /// <summary>
        /// Overload the cast operator to type processor.
        /// </summary>
        /// <param name="motherboard"></param>
        public static explicit operator Prossesor(Motherboard motherboard)
        {
            return new Prossesor(motherboard.Name, motherboard.Price, motherboard.Count);
        }
        /// <summary>
        /// Overload the cast operator to type keyboard.
        /// </summary>
        /// <param name="motherboard"></param>
        public static explicit operator Keyboard(Motherboard motherboard)
        {
            return new Keyboard(motherboard.Name, motherboard.Price, motherboard.Count);
        }
        /// <summary>
        /// Overload the cast operator to type mouse.
        /// </summary>
        /// <param name="motherboard"></param>
        public static explicit operator Mouse(Motherboard motherboard)
        {
            return new Mouse(motherboard.Name, motherboard.Price, motherboard.Count);
        }
        /// <summary>
        /// Returns true if the object is of type motherboard and has the same name.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Motherboard && (obj as Motherboard)
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
                $"Manufacturer: {Manufacturer}, CPU Manufaturer: {ProcessorManufacturer}, " +
                $"CountOfMemorySlots: {CountOfMemorySlots}";
        }
    }
}
