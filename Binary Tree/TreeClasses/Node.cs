using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree.TreeClasses
{
    public class Node<T> where T : IComparable<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public int Height { get; set; }
        public T Value { get; set; }
        public Node(T value)
        {
            Value = value;
        }
    }
}
