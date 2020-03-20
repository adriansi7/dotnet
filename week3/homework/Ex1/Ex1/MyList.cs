using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Ex1
{
    public class MyList<T>: IEnumerable<T>
    {
        private const int defaultCapacity = 4;

        private T[] items;

        public MyList(int capacity = defaultCapacity)
        {
            this.items = new T[capacity];
        }

        public int Count { get; set; }

        public int Capacity
        {
            get { return this.items.Length; }

            set
            {
                if (value < this.Count) value = this.Count;

                if (value != this.items.Length)
                {
                    T[] newItems = new T[value];
                    Array.Copy(this.items, 0, newItems, 0, this.Count);
                    this.items = newItems;
                }
            }
        }
        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Capacity = this.Count * 2;
            }

            this.items[this.Count] = item;

            this.Count++;
        }

        public T this[int index]
        {
            get
            {
                return this.items[index];
            }
            set
            {
                this.items[index] = value;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            this.Count--;

            if (index < this.Count)
            {
                Array.Copy(this.items, index + 1, this.items, index, this.Count - index);
            }

            this.items[this.Count] = default(T);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (object.Equals(item, this.items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach(T item in this.items)
            {
                yield return item;
            }
        }
    }
}
