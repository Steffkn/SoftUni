using System;
using System.Collections.Generic;
using System.Linq;

public class ListOfPredicates
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var dividers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Distinct()
            .Select(int.Parse)
            .OrderByDescending(x => x)
            .Select(divider => (Func<int, bool>)(number => number % divider == 0))
            .ToList();

        var result = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            bool divisableByAll = true;
            foreach (var divider in dividers)
            {
                if (!divider(i))
                {
                    divisableByAll = false;
                    break;
                }
            }
            if (divisableByAll)
            {
                result.Add(i);
            }
        }

        Console.WriteLine(String.Join(" ", result));
    }
}
