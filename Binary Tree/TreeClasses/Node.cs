using System;

namespace Binary_Tree.TreeClasses
{
    /// <summary>
    /// Represents a node object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T> where T : IComparable<T>
    {
        /// <summary>
        /// Stores a reference to the left node object.
        /// </summary>
        public Node<T> Left { get; set; }
        /// <summary>
        /// Stores a reference to the right node object.
        /// </summary>
        public Node<T> Right { get; set; }
        /// <summary>
        /// Contains the height of this node.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Contains the node value.
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        /// Initializes an object of type node.
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            Value = value;
        }
        /// <summary>
        /// Adds value to the node.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="node"></param>
        /// <param name="prevNode"></param>
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
        /// <summary>
        /// Returns the difference between the left and right subtree.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Returns the height of this node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int GetHeight(Node<T> node)
        {
            if (node == null)
                return 0;
            else
                return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }
        /// <summary>
        /// Makes a superficial adjustment to the height of this node.
        /// </summary>
        /// <param name="node"></param>
        public static void ShallowHeightCorrection(Node<T> node)
        {
            int heightLeft = node.Left != null ? node.Left.Height : 0;
            int heightRight = node.Right != null ? node.Right.Height : 0;
            node.Height = heightLeft > heightRight ? heightLeft + 1 : heightRight + 1;
        }
    }
}
