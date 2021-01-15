using Store.BaseClasses;
using Store.StoreProducts.Periphery;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.StoreProducts.ComputerComponents
{
    /// <summary>
    /// Represents an item of type рrossesor.
    /// </summary>
    public class Prossesor : BaseProduct
    {
        /// <summary>
        /// Contains the name of the manufacturer of the product.
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Contains the number of processor cores.
        /// </summary>
        public int CountOfCores { get; set; }
        /// <summary>
        /// Contains the socket type.
        /// </summary>
        public string Socket { get; set; }
        /// <summary>
        /// Initializes a new object of type prossesor.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="count"></param>
        public Prossesor(string productName, decimal price, int count)
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
        public static Prossesor operator +(Prossesor left, Prossesor right)
        {
            return new Prossesor(left.Name + "-" + right.Name, (left.Price + right.Price) / 2, left.Count + right.Count);
        }
        /// <summary>
        /// Overload the cast operator to type motherboard.
        /// </summary>
        /// <param name="motherboard"></param>
        public static explicit operator Motherboard(Prossesor prossesor)
        {
            return new Motherboard(prossesor.Name, prossesor.Price, prossesor.Count);
        }
        /// <summary>
        /// Overload the cast operator to type keyboard.
        /// </summary>
        /// <param name="motherboard"></param>
        public static explicit operator Keyboard(Prossesor prossesor)
        {
            return new Keyboard(prossesor.Name, prossesor.Price, prossesor.Count);
        }
        /// <summary>
        /// Overload the cast operator to type mouse.
        /// </summary>
        /// <param name="motherboard"></param>
        public static explicit operator Mouse(Prossesor prossesor)
        {
            return new Mouse(prossesor.Name, prossesor.Price, prossesor.Count);
        }
        public override bool Equals(object obj)
        {
            if (obj is Prossesor && (obj as Prossesor)
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
            return $"{Name}, Price: {Price}, Count : {Count}, " +
                $"Manufacturer: {Manufacturer}, CountOfCores: {CountOfCores}, " +
                $"Socket: {Socket}";
        }
    }
}
