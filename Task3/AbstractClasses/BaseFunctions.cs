using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.AbstractClasses
{
    public abstract class BaseFunctions
    {
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract override string ToString();
    }
}
