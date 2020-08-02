using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree.TreeClasses
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }
    }
}
