using System;
using System.Collections.Generic;

namespace Binary_Tree.TreeClasses
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public void AddValue(T value)
        {
            if (Root == null)
                Root = new Node<T>(value);
            else
                Root.AddValue(value, Root);
            RecalculateHeights(Root);
            Root = BalanceNode(Root);
        }
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
        private void DeleteRoot()
        {
            if (Root.Left == null && Root.Right == null)
                Root = null;
            else
            {
                var min = GetMinAndPrevElement(Root, null);
                if (min.Item2 == null)
                    Root = Root.Right;
                else
                {
                    var max = GetMaxAndPrevElement(min.Item1, min.Item2);
                    if (Root.Equals(max.Item2))
                    {
                        min.Item1.Right = Root.Right;
                        Root = min.Item1;
                    }
                    else
                    {
                        max.Item2.Right = max.Item1.Left;
                        max.Item1.Left = Root.Left;
                        max.Item1.Right = Root.Right;
                        Root = max.Item1;
                        max.Item2.Left = null;
                    }
                }
            }
        }
        private void DeleteValue(T value, Node<T> currentNode, Node<T> previousNode = null)
        {
            if (value.Equals(currentNode.Value))
            {
                if (currentNode.Left == null && currentNode.Right != null)
                    RemoveRightSubtree(previousNode, currentNode);
                if (currentNode.Left != null && currentNode.Right == null)
                    RemoveLeftSubtree(previousNode, currentNode);
                if (currentNode.Left != null && currentNode.Right != null)
                    RemoveTwoSubtrees(previousNode, currentNode);
                else
                    RemoveList(previousNode, currentNode);
            }
            else
            {
                if (value.CompareTo(currentNode.Value) > 0)
                    DeleteValue(value, currentNode.Right, currentNode);
                else
                    DeleteValue(value, currentNode.Left, currentNode);
            }
        }
        private void RemoveList(Node<T> prevNode, Node<T> currNode)
        {
            if (prevNode.Right != null && prevNode.Right.Value.Equals(currNode.Value))
                prevNode.Right = null;
            if (prevNode.Left != null && prevNode.Left.Value.Equals(currNode.Value))
                prevNode.Left = null;
        }
        private void RemoveLeftSubtree(Node<T> prevNode, Node<T> currNode)
        {
            if (prevNode.Right.Value.Equals(currNode.Value))
                prevNode.Right = currNode.Left;
            if (prevNode.Left.Value.Equals(currNode.Value))
                prevNode.Left = currNode.Left;
        }
        private void RemoveRightSubtree(Node<T> prevNode, Node<T> currNode)
        {
            if (prevNode.Right.Value.Equals(currNode.Value))
                prevNode.Right = currNode.Right;
            if (prevNode.Left.Value.Equals(currNode.Value))
                prevNode.Left = currNode.Right;
        }
        private void RemoveTwoSubtrees(Node<T> prevNode, Node<T> currNode)
        {
            if (currNode.Right.Left != null)
            {
                var rightMin = GetMinAndPrevElement(currNode.Right, currNode);
                rightMin.Item2.Left = rightMin.Item1.Right;
                rightMin.Item1.Left = currNode.Left;
                rightMin.Item1.Right = currNode.Right;
                if (prevNode.Right.Value.Equals(currNode.Value))
                    prevNode.Right = rightMin.Item1;
                if (prevNode.Left.Value.Equals(currNode.Value))
                    prevNode.Left = rightMin.Item1;
            }
            else
            {
                currNode.Right.Left = currNode.Left;
                if (prevNode.Right.Value.Equals(currNode.Value))
                    prevNode.Right = currNode.Right;
                if (prevNode.Left.Value.Equals(currNode.Value))
                    prevNode.Left = currNode.Right;
            }
        }
        private (Node<T>, Node<T>) GetMinAndPrevElement(Node<T> current, Node<T> previous)
        {
            if (current.Left != null)
                return GetMinAndPrevElement(current.Left, current);
            else
                return (current, previous);
        }
        private (Node<T>, Node<T>) GetMaxAndPrevElement(Node<T> current, Node<T> previous)
        {
            if (current.Right != null)
                return GetMinAndPrevElement(current.Right, current);
            else
                return (current, previous);
        }
        private void RecalculateHeights(Node<T> node)
        {
            if (node != null)
            {
                node.Height = Node<T>.GetHeight(node);
                RecalculateHeights(node.Left);
                RecalculateHeights(node.Right);
            }
        }
        public T SearchValue(T value)
        {
            return TreeSearch(value, Root);
        }
        private T TreeSearch(T value, Node<T> node)
        {
            if (node == null)
                return default;
            if (value.CompareTo(node.Value) < 0)
                return TreeSearch(value, node.Left);
            if (value.CompareTo(node.Value) > 0)
                return TreeSearch(value, node.Right);
            else
                return node.Value;
        }
        private static Node<T> RotateRight(Node<T> node)
        {
            Node<T> tempNode = node.Left;
            node.Left = tempNode.Right;
            tempNode.Right = node;
            Node<T>.ShallowHeightCorrection(node);
            Node<T>.ShallowHeightCorrection(tempNode);
            return tempNode;
        }
        private static Node<T> RotateLeft(Node<T> node)
        {
            Node<T> tempNode = node.Right;
            node.Right = tempNode.Left;
            tempNode.Left = node;
            Node<T>.ShallowHeightCorrection(node);
            Node<T>.ShallowHeightCorrection(tempNode);
            return tempNode;
        }
        private Node<T> BalanceNode(Node<T> node)
        {
            if (node?.CheckBalance() == 2)
            {
                if (node.Right.CheckBalance() < 0)
                    node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            if (node?.CheckBalance() == -2)
            {
                if (node.Left.CheckBalance() > 0)
                    node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            return node;
        }
        public List<T> GetTreeInList()
        {
            List<T> treeList = new List<T>();
            TreeTraversalPreOrder(Root, treeList);
            return treeList;
        }
        private void TreeTraversalPreOrder(Node<T> node, List<T> list)
        {
            if (node != null)
            {
                list.Add(node.Value);
                TreeTraversalPreOrder(node.Left, list);
                TreeTraversalPreOrder(node.Right, list);
            }
        }
    }
}
