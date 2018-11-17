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
            return Array.IndexOf(this.array, item, 0, this.Count);
        }

        public int LastIndexOf(T item)
        {
            return Array.LastIndexOf(this.array, item, this.Count - 1, this.Count);
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
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }

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
            return this.IndexOf(item) >= 0;
        }

        public bool Exists(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.array[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public T Find(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.array[i]))
                {
                    return this.array[i];
                }
            }
            return default(T);
        }

        public int FindIndex(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public T FindLast(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (predicate(this.array[i]))
                {
                    return this.array[i];
                }
            }
            return default(T);
        }

        public int FindLastIndex(Predicate<T> predicate)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (predicate(this.array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public List<T> FindAll(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }

            List<T> result = new List<T>();

            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.array[i]))
                {
                    result.Add(this.array[i]);
                }
            }

            return result;
        }

        public bool TrueForAll(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (!predicate(this.array[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public List<U> ConvertAll<U>(Converter<T, U> converter)
        {
            List<U> result = new List<U>(this.Count);
            for (int i = 0; i < this.Count; i++)
            {
                result.array[i] = converter(this.array[i]);
            }
            result.Count = this.Count;
            return result;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            Array.Copy(this.array, result, this.Count);
            return result;
        }

        public void CopyTo(T[] array)
        {
            Array.Copy(this.array, array, this.Count);
        }

        public void ForEach(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < this.Count; i++)
            {
                action(this.array[i]);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.array, 0, array, arrayIndex, this.Count);
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