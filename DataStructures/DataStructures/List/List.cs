using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.List
{
    public class List<T> : ICollection<T>
    {
        private T[] array;

        public List(int capacity = 0)
        {
            this.array = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return array[index];
            }
        }

        public void Add(T item)
        {
            this.EnsureCapacity();
            array[this.Count++] = item;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                this.Add(item);
            }
        }

        public void TrimExcess()
        {
            Array.Resize(ref this.array, this.Count);
        }

        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.array[i] = default(T);
            }
            this.Count = 0;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            this.EnsureCapacity();

            Array.Copy(this.array, index, this.array, index + 1, this.Count - index);

            this.array[index] = item;
            this.Count++;
        }

        public void InsertRange(int index, IEnumerable<T> items)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            int itemsCount = items.Count();

            this.EnsureCapacity(this.Count + itemsCount);

            Array.Copy(this.array, index, this.array, index + itemsCount, this.Count - index);
            foreach (var item in items)
            {
                this.array[index++] = item;
            }

            this.Count += itemsCount;
        }

        public List<T> GetRange(int index, int length)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (length < 0)
            {
                throw new ArgumentException();
            }

            if (index + length > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            List<T> result = new List<T>(length);
            Array.Copy(this.array, index, result.array, 0, length);
            result.Count = length;

            return result;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Array.Copy(this.array, index + 1, this.array, index, this.Count - index - 1);

            this.array[this.Count] = default(T);
            this.Count--;
        }

        public void RemoveRange(int index, int length)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (length < 0)
            {
                throw new ArgumentException();
            }

            if (index + length > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Array.Copy(this.array, index + length, this.array, index, this.Count - index - length);

            for (int i = this.Count - 1; i >= this.Count - length; i--)
            {
                this.array[i] = default(T);
            }
            this.Count -= length;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(this.array, item);
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index >= 0)
            {
                this.RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAll(Predicate<T> predicate)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.array[i]))
                {
                    this.RemoveAt(i--);
                }
            }
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
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureCapacity()
        {
            if (this.Count == this.Capacity)
            {
                Array.Resize(ref this.array, this.Capacity == 0 ? 4 : this.Capacity * 2);
            }
        }

        private void EnsureCapacity(int targetCapacity)
        {
            if (targetCapacity > this.Capacity)
            {
                int doubleCapacity = this.Capacity == 0 ? 4 : this.Capacity * 2;
                Array.Resize(ref this.array, targetCapacity > doubleCapacity ? targetCapacity : doubleCapacity);
            }
        }
    }
}