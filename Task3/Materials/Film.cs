using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractClasses;
using Task3.Interfaces;

namespace Task3.Materials
{
    public class Film : BaseFunctions, IMaterial
    {
        public bool CanBePainted => false;

        public override bool Equals(object obj)
        {
            if (obj is Film)
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
            return GetType().FullName + " " + (CanBePainted ? 1 : 0);
        }
    }
}
