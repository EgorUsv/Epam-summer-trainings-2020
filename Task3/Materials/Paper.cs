using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractClasses;
using Task3.Colors;
using Task3.Interfaces;

namespace Task3.Materials
{
    public class Paper : BaseFunctions, IPaintableMaterial
    {
        public bool CanBePainted => true;

        public MaterialColors Colour { get; set; }

        public Paper(MaterialColors colour)
        {
            Colour = colour;
        }

        public override bool Equals(object obj)
        {
            if (obj is Paper && (obj as Paper).Colour == Colour)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return CanBePainted.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().AssemblyQualifiedName + " " + (CanBePainted ? 1 : 0) + 
                " " + (int)Colour;
        }
    }
}
