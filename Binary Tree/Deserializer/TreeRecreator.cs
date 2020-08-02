using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree.Deserializer
{
    public static class TreeRecreator<T> where T : IComparable<T>
    {
        public static BinaryTreeClass<T> Deserializer(List<T> tree)
        {
            BinaryTreeClass<T> binaryTree = new BinaryTreeClass<T>();
            foreach (T value in tree)
                binaryTree.AddValue(value);
            return binaryTree;
        }
    }
}
