using Binary_Tree.TreeClasses;
using System;
using System.Collections.Generic;

namespace Binary_Tree.Deserializer
{
    public static class TreeRecreator<T> where T : IComparable<T>
    {
        public static BinaryTree<T> Deserializer(ICollection<T> tree)
        {
            BinaryTree<T> binaryTree = new BinaryTree<T>();
            foreach (T value in tree)
                binaryTree.AddValue(value);
            return binaryTree;
        }
    }
}
