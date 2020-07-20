using System;
using System.Collections.Generic;
using System.Text;
using Task3.Colors;

namespace Task3.Interfaces
{
    public interface IPaintableMaterial
    {
        public MaterialColors Color { get; set; }
        public void PaintMaterial(MaterialColors color)
        {
            if (Color == MaterialColors.None)
                Color = color;
            else
                throw new Exception("This figure is already painted.");
        }
    }
}
