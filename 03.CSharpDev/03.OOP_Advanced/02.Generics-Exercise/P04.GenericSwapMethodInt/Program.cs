namespace P04.GenericSwapMethodInt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P00.GenericBox;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<GenericBox<int>>();
            for (int i = 0; i < n; i++)
            {
                var box = new GenericBox<int>(int.Parse(Console.ReadLine()));
                list.Add(box);
            }

            var indexesArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var from = indexesArray[0];
            var to = indexesArray[1];

            SwapElements(list, from, to);

            foreach (var genericBox in list)
            {
                Console.WriteLine(genericBox.ToString());
            }
        }

        private static void SwapElements<T>(List<GenericBox<T>> elements, int from, int to)
            where T : IComparable
        {
            var temp = elements[from];
            elements[from] = elements[to];
            elements[to] = temp;
        }
    }
}
