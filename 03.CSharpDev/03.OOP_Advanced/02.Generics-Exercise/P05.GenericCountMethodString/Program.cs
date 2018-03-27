namespace P05.GenericCountMethodString
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
            var list = new List<GenericBox<string>>();
            for (int i = 0; i < n; i++)
            {
                var box = new GenericBox<string>(Console.ReadLine());
                list.Add(box);
            }

            var item = Console.ReadLine();
            Console.WriteLine(CountOfGreaterElements(list, item));
        }

        private static int CountOfGreaterElements<T>(List<GenericBox<T>> elements, T from)
            where T : IComparable
        {
            return elements.Count(x => x.Value.CompareTo(from) > 0);
        }
    }
}
