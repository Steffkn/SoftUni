namespace P07.CustomList.Models
{
    using System;
    using P07.CustomList.Interfaces;

    public static class Sorter<T> where T : IComparable<T>
    {
        private const int low = 0;

        public static void Sort(ICustomList<T> collection)
        {
            int high = collection.Count;
            QuickSort(collection, low, high);
        }

        private static void QuickSort(ICustomList<T> collection, int low, int high)
        {
            if (low < high)
            {
                int pivotLocation = Partition(collection, low, high);
                QuickSort(collection, low, pivotLocation);
                QuickSort(collection, pivotLocation + 1, high);
            }
        }

        private static int Partition(ICustomList<T> collection, int low, int high)
        {
            T pivot = collection[low];
            int leftWall = low;
            for (int i = low + 1; i < high; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    leftWall++;
                    collection.Swap(i, leftWall);
                }
            }
            collection.Swap(low, leftWall);
            return leftWall;
        }
    }
}
