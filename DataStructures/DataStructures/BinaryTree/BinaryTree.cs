using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> head;
        private int count;

        public void Add(T value)
        {
            this.Add(new BinaryTreeNode<T>(value));
        }

        public void Add(BinaryTreeNode<T> node)
        {
            if (this.head == null)
            {
                this.head = node;
            }

            this.AddTo(this.head, node);
            this.count++;
        }

        private void AddTo(BinaryTreeNode<T> parent, BinaryTreeNode<T> newNode)
        {
            BinaryTreeNode<T> next = parent.CompareTo(newNode.Value) < 0 ? parent.Left : parent.Right;

            if (next == null)
            {
                next = newNode;
            }
            else
            {
                this.AddTo(next, newNode);
            }
        }

        public bool Contains(T value)
        {
            return this.Find(value, out BinaryTreeNode<T> parent) != null;
        }

        private BinaryTreeNode<T> Find(T value, out BinaryTreeNode<T> parent)
        {
            parent = null;
            BinaryTreeNode<T> current = this.head;

            while (current != null)
            {
                if (current.CompareTo(value) > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (current.CompareTo(value) < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    return current;
                }
            }

            return null;
        }

        public void Remove(T value)
        {
            BinaryTreeNode<T> nodeToRemoval = this.Find(value, out BinaryTreeNode<T> parent);

            if (nodeToRemoval == null)
            {
                return;
            }

            this.count--;


            if (nodeToRemoval.Right == null)
            {
                if (parent == null)
                {
                    this.head = nodeToRemoval.Left;
                }
                else
                {
                    var nodeToAssign = nodeToRemoval.CompareTo(parent.Value) < 0 ? parent.Left : parent.Right;
                    nodeToAssign = nodeToRemoval.Left;
                }
            }
            else if (nodeToRemoval.Right.Left == null)
            {
                if (parent == null)
                {
                    this.head = nodeToRemoval.Right;
                }
                else
                {
                    var nodeToAssign = nodeToRemoval.CompareTo(parent.Value) < 0 ? parent.Left : parent.Right;
                    nodeToRemoval.Right.Left = nodeToRemoval.Left;
                    nodeToAssign = nodeToRemoval.Right;
                }
            }
            else
            {
                BinaryTreeNode<T> leftMost = nodeToRemoval.Right.Left;
                BinaryTreeNode<T> leftMostParent = nodeToRemoval.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;

                leftMost.Left = nodeToRemoval.Left;
                leftMost.Right = nodeToRemoval.Right;

                if (parent == null)
                {
                    this.head = leftMost;
                }
                else
                {
                    var nodeToAssign = nodeToRemoval.CompareTo(parent.Value) < 0 ? parent.Left : parent.Right;
                    nodeToAssign = leftMost;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();

            if (this.head == null)
            {
                yield break;
            }

            stack.Push(this.head);

            while (stack.Count > 0)
            {
                var current = this.head;

                while (current.Left != null)
                {
                    stack.Push(current.Left);
                    current = current.Left;
                }

                yield return current.Value;

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }
                else
                {
                    current = stack.Pop();
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
