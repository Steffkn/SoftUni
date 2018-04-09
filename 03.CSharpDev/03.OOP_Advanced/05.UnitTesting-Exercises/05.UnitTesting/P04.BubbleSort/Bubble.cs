namespace P04.BubbleSort
{
    using System;

    public static class Bubble<T>
        where T : IComparable
    {
        public static void Sort(T[] items)
        {
            int n = items.Length;
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 1; i <= n - 1; i++)
                {
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        var temp = items[i - 1];
                        items[i - 1] = items[i];
                        items[i] = temp;
                        swapped = true;
                    }
                }

                n = n - 1;
            }
        }
    }
}
