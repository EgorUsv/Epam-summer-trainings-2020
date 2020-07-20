using System;
using System.Collections.Generic;
using System.Text;
using Task3.Colors;

namespace Task3.Interfaces
{
    public interface IPaintableMaterial : IMaterial
    {
        public MaterialColors Colour { get; set; }
        public void PaintMaterial(MaterialColors colour)
        {
            if (Colour == MaterialColors.None)
                Colour = colour;
            else
                throw new Exception("This figure is already painted.");
        }
    }
}
