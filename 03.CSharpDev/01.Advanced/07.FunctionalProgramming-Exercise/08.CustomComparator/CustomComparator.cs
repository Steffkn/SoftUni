using System;
using System.Collections.Generic;
using System.Linq;

public class CustomComparator
{
    public static void Main()
    {
        var numbers = Console.ReadLine()?
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var comparer = new Comparer();
        Array.Sort(numbers, comparer);
        Console.WriteLine(String.Join(" ", numbers));
    }

    private class Comparer : IComparer<int>
    {
        Predicate<int> isEven = number => number % 2 == 0;

        public int Compare(int x, int y)
        {
            if (isEven(x) && !isEven(y))
            {
                return -1;
            }
            else if(!isEven(x) && isEven(y))
            {
                return 1;
            }

            return x.CompareTo(y);
        }
    }

}
