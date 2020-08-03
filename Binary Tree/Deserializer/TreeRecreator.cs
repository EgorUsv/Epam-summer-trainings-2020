using Binary_Tree.TreeClasses;
using System;
using System.Collections.Generic;

namespace Binary_Tree.Deserializer
{
    /// <summary>
    /// Used to deserialize a binary tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class TreeRecreator<T> where T : IComparable<T>
    {
        /// <summary>
        /// Gathers tree from a collection of elements.
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static BinaryTree<T> Deserializer(ICollection<T> tree)
        {
            BinaryTree<T> binaryTree = new BinaryTree<T>();
            foreach (T value in tree)
                binaryTree.AddValue(value);
            return binaryTree;
        }
    }
}
