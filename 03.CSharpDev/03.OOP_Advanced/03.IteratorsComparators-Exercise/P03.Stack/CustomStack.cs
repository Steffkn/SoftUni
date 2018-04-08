using System.Collections;

namespace P03.Stack
{
    using System;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable<T>
    {
        private LinkedList<T> items;

        public CustomStack()
        {
            this.items = new LinkedList<T>();
        }

        public CustomStack(IEnumerable<T> array)
        {
            this.items = new LinkedList<T>(array);
        }

        public T Pop()
        {
            if (this.items.Count > 0)
            {
                var item = items.Last.Value;
                items.RemoveLast();
                return item;
            }

            throw new ArgumentException("No elements");
        }
        public void Push(T element)
        {
            this.items.AddLast(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = items.Last;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
