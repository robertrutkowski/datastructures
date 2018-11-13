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
                foreach (var item in this)
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
                node.Next = null;
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

        public void AddLast(LinkedListNode<T> node)
        {
            node.Next = null;

            if (this.Count == 0)
            {
                this.Head = this.Tail = node;
            }
            else
            {
                this.Tail.Next = node;
                this.Tail = node;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            this.AddLast(new LinkedListNode<T>(item));
        }

        public void RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List has no elements.");
            }
            else if (this.Count == 1)
            {
                this.Head = this.Tail = null;
            }
            else
            {
                this.Head = this.Head.Next;
            }
            this.Count--;
        }

        public void RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List has no elements.");
            }
            else if (this.Count == 1)
            {
                this.Head = this.Tail = null;
            }
            else
            {
                LinkedListNode<T> current = this.Head;
                while (current != null)
                {
                    if (current.Next == this.Tail)
                    {
                        current.Next = null;
                        this.Tail = current;
                    }

                    current = current.Next;
                }
            }
            this.Count--;
        }

        public void Add(LinkedListNode<T> node)
        {
            this.AddLast(node);
        }

        public void Add(T item)
        {
            this.Add(new LinkedListNode<T>(item));
        }

        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var listItem in this)
            {
                if (item.Equals(listItem))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
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

        public void Remove(LinkedListNode<T> node)
        {
            if (node == this.Head)
            {
                this.RemoveFirst();
            }
            else if (node == this.Tail)
            {
                this.RemoveLast();
            }
            else
            {
                node.Item = node.Next.Item;
                node.Next = node.Next.Next;
                if (node.Next == null)
                {
                    this.Tail = node;
                }
                this.Count--;
            }
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Parameter 'item' is null");
            }

            LinkedListNode<T> current = this.Head;
            while (current != null)
            {
                if (item.Equals(current.Item))
                {
                    this.Remove(current);
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
