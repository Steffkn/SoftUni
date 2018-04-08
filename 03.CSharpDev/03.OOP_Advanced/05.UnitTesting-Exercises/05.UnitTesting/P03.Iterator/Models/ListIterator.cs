namespace P03.Iterator.Models
{
    using System;
    using System.Collections.Generic;
    using P03.Iterator.Interfaces;

    public class ListIterator : IListIterator
    {
        private IList<string> items;
        private int currentIndex;

        public ListIterator(params string[] inputItems)
        {
            this.items = new List<string>();
            foreach (string inputItem in inputItems)
            {
                if (inputItem == null)
                {
                    throw new ArgumentNullException(nameof(inputItem), "Empty values are not allowed!");
                }

                this.items.Add(inputItem);
            }

            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentIndex += 1;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return this.currentIndex < this.items.Count - 1;
        }

        public string Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            if (this.items.Count <= this.currentIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(this.currentIndex), "Index is out of bounds of the list!");
            }

            return this.items[this.currentIndex];
        }
    }
}
