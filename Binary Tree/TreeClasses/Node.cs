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
        public void AddValue(T value, Node<T> node, Node<T> prevNode = null)
        {
            if (node != null)
            {
                if (value.CompareTo(node.Value) > 0)
                    AddValue(value, node.Right, node);
                if (value.CompareTo(node.Value) < 0)
                    AddValue(value, node.Left, node);
            }
            else
            {
                if (value.CompareTo(prevNode.Value) > 0)
                    prevNode.Right = new Node<T>(value);
                else
                    prevNode.Left = new Node<T>(value);
            }
        }
        public int CheckBalance()
        {
            if (Left != null && Right != null)
                return Right.Height - Left.Height;
            if (Left == null && Right == null)
                return 0;
            if (Left == null)
                return Right.Height;
            else
                return -Left.Height;
        }
        public static int GetHeight(Node<T> node)
        {
            if (node == null)
                return 0;
            else
                return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }
        public static void ShallowHeightCorrection(Node<T> node)
        {
            int heightLeft = node.Left != null ? node.Left.Height : 0;
            int heightRight = node.Right != null ? node.Right.Height : 0;
            node.Height = heightLeft > heightRight ? heightLeft + 1 : heightRight + 1;
        }
    }
}
