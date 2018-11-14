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

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
