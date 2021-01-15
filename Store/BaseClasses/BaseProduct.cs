using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BaseClasses
{
    /// <summary>
    /// Represents the base product type.
    /// </summary>
    public abstract class BaseProduct : BaseFunctions
    {
        /// <summary>
        /// Contains the name of the product.
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// Contains the price of product.
        /// </summary>
        public decimal Price { get; protected set; }
        /// <summary>
        /// Contains the amount of product.
        /// </summary>
        public int Count { get; protected set; }
        public void UpdateInfo(string newProductName,decimal newPrice,int newCount)
        {
            if (newProductName != null)
                Name = newProductName;
            if (newPrice > 0)
                Price = newPrice;
            if (newCount >= 1)
                Count = newCount;
        }
        /// <summary>
        /// Overload of the cast operator to translate the price into pennies.
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator int(BaseProduct product)
        {
            int intPart = (int)product.Price;
            return (int)(intPart * 100 + product.Price % intPart * 100);
        }
        /// <summary>
        /// Overloading the cast operator to convert the price to the float type.
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator float(BaseProduct product)
        {
            return (float)product.Price;
        }
        /// <summary>
        /// Returns a hash code from a string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        protected int GetStringHashCode(string str,int shift)
        {
            int hash = 0;
            for (int i = 0; i < Name.Length; i++)
                hash += Name[i] << shift;
            return hash;
        }
        /// <summary>
        /// Serves as a custom method to return a hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetStringHashCode(Name,3) ^ ((int)Price << 2) ^ Count;
        }
    }
}
