using System.Collections;

namespace P01.ListyIterator
{
    using System;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private IReadOnlyList<T> list;
        private int index;

        public ListyIterator(IReadOnlyList<T> elements)
        {
            this.list = elements;
        }

        public bool Move()
        {
            if (!this.HasNext())
            {
                return false;
            }

            this.index++;
            return true;
        }

        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine(list[index]);
        }

        public bool HasNext()
        {
            return this.index < this.list.Count - 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
