namespace P07.CustomList.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using P07.CustomList.Interfaces;

    public class CustomList<T> : ICustomList<T>
        where T : IComparable
    {
        private T[] array;

        public CustomList(int count = 2)
        {
            this.array = new T[count];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.Count)
                {
                    return this.array[index];
                }

                throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < this.Count)
                {
                    this.array[index] = value;
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public void Add(T item)
        {
            if (this.array.Length > this.Count)
            {
                this.array[this.Count] = item;
            }
            else
            {
                var tempArray = new T[this.array.Length * 2];
                for (int i = 0; i < array.Length; i++)
                {
                    tempArray[i] = array[i];
                }

                this.array = tempArray;
                this.array[this.Count] = item;
            }

            this.Count++;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= this.array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            T result = default(T);
            var tempArray = this.Count < (this.array.Length / 4) ?
                new T[this.array.Length / 2] :
                new T[this.array.Length];

            for (int i = 0, j = 0; i < this.array.Length; i++, j++)
            {
                if (i == index)
                {
                    j--;
                    this.Count--;
                    result = this.array[i];
                }
                else
                {
                    tempArray[j] = this.array[i];
                }
            }

            this.array = tempArray;
            return result;
        }

        public bool Contains(T element)
        {
            bool containsItem = false;
            foreach (T item in this.array)
            {
                if (item.CompareTo(element) == 0)
                {
                    containsItem = true;
                    break;
                }
            }

            return containsItem;
        }

        public void Swap(int from, int to)
        {
            var temp = this.array[from];
            this.array[from] = this.array[to];
            this.array[to] = temp;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            return this.array.Max();
        }

        public T Min()
        {
            return this.array.Min();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
