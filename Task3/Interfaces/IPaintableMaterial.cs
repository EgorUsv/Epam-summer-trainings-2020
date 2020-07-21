using System;
using System.Collections.Generic;
using System.Text;
using Task3.Colors;

namespace Task3.Interfaces
{
    /// <summary>
    /// Represents a paintable material.
    /// </summary>
    public interface IPaintableMaterial : IMaterial
    {
        /// <summary>
        /// Contains the color of the material.
        /// </summary>
        public MaterialColors Colour { get; set; }
        /// <summary>
        /// Method allows to paint the material if it 
        /// is not already painted.
        /// </summary>
        /// <param name="colour"></param>
        public void PaintMaterial(MaterialColors colour)
        {
            if (Colour == MaterialColors.None)
                Colour = colour;
            else
                throw new Exception("This figure is already painted.");
        }
    }
}
