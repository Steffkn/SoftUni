namespace P01.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database<T>
    {
        private const int ArrayCapacity = 16;
        private T[] data;
        private int currentIndex;

        public Database(params T[] initialIntegers)
        {
            this.InitData(initialIntegers);
        }

        public IReadOnlyCollection<T> Data => Array.AsReadOnly(this.data.Take(this.currentIndex).ToArray());

        private void InitData(T[] elements)
        {
            if (elements.Length > ArrayCapacity)
            {
                throw new InvalidOperationException();
            }

            if (elements.Length > 0)
            {
                this.data = new T[ArrayCapacity];
                for (int i = 0; i < elements.Length; i++)
                {
                    this.data[i] = elements[i];
                }

                this.currentIndex = elements.Length;
            }
            else
            {
                this.data = new T[ArrayCapacity];
                this.currentIndex = 0;
            }
        }

        public virtual void Add(T element)
        {
            if (this.currentIndex >= ArrayCapacity)
            {
                throw new InvalidOperationException();
            }

            this.data[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex <= 0)
            {
                throw new InvalidOperationException();
            }

            this.currentIndex--;
            this.data[this.currentIndex] = default(T);
        }


        public T[] Fetch()
        {
            var result = new T[this.currentIndex];
            Array.Copy(this.data, result, this.currentIndex);
            return result;
        }
    }
}
