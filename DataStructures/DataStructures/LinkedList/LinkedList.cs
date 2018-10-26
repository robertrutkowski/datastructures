using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public T this[int i]
        {
            get
            {
                int index = 0;
                LinkedListNode<T> current = this.Head;
                while (current != null)
                {
                    if (index == i)
                    {
                        return current.Item;
                    }

                    index++;
                    current = current.Next;
                }

                throw new IndexOutOfRangeException($"Value {i} is out of range.");
            }
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            if (this.Count == 0)
            {
                this.Head = this.Tail = node;
            }
            else
            {
                node.Next = this.Head;
                this.Head = node;
            }

            this.Count++;
        }

        public void AddFirst(T item)
        {
            this.AddFirst(new LinkedListNode<T>(item));
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = this.Head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
