using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree.AbstractClasses
{
    public abstract class BaseFunctions
    {
        protected int GetStringHashCode(string str, int shift = 0)
        {
            int hash = 0;
            for (int i = 0; i < str.Length; i++)
                hash += str[i] << shift;
            return hash;
        }
        public abstract override int GetHashCode();
        public abstract override bool Equals(object obj);
    }
}
