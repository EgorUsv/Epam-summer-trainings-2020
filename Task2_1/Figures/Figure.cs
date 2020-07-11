using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1.Figures
{
    /// <summary>
    /// Base class for figures.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Returns the area of figure.
        /// </summary>
        /// <returns></returns>
        public abstract double Area();

        /// <summary>
        /// Returns the perimeter of a shape.
        /// </summary>
        /// <returns></returns>
        public abstract double Perimeter();

        /// <summary>
        /// Returns a string representing the current object.
        /// </summary>
        /// <returns></returns>
        public abstract override string ToString();
    }
}
