using System;
using System.Collections.Generic;

namespace Binary_Tree.TreeClasses
{
    /// <summary>
    /// Reflects a binary tree object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class BinaryTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Contains tree root.
        /// </summary>
        public Node<T> Root { get; private set; }
        /// <summary>
        /// Adds a value to a binary tree.
        /// </summary>
        /// <param name="value"></param>
        public void AddValue(T value)
        {
            if (Root == null)
                Root = new Node<T>(value);
            else
                Root.AddValue(value, Root);
            RecalculateHeights(Root);
            Root = BalanceNode(Root);
        }
        /// <summary>
        /// Removes a binary tree element.
        /// </summary>
        /// <param name="value"></param>
        public void DeleteValue(T value)
        {
            if (SearchValue(value) != null)
            {
                if (Root.Value.Equals(value))
                    DeleteRoot();
                else
                    DeleteValue(value, Root);
                RecalculateHeights(Root);
                Root = BalanceNode(Root);
            }
        }
        /// <summary>
        /// Returns a list of items, following a forward traversal.
        /// </summary>
        /// <returns></returns>
        public List<T> GetTreeInList()
        {
            List<T> treeList = new List<T>();
            TreeTraversalPreOrder(Root, treeList);
            return treeList;
        }
        /// <summary>
        /// Searches for an element in a binary tree.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T SearchValue(T value)
        {
            return TreeSearch(value, Root);
        }
    }
}
