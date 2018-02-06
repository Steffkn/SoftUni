using System;
using System.Collections.Generic;
using System.Linq;

public class FindEvensOrOdds
{
    public static void Main()
    {
        var ranges = Console.ReadLine()?
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        string conditionInput = Console.ReadLine();

        Predicate<int> predicate = number => number % 2 == 0;
        Func<string, int, bool> filter = (condition, number) =>
        {
            switch (condition.ToLower())
            {
                case "odd":
                    return !predicate(number);
                case "even":
                    return predicate(number);
                default:
                    throw new InvalidOperationException();
            }
        };

        var numbers = Enumerable.Range(ranges[0], ranges[1] - ranges[0] + 1)
            .Where(x => filter(conditionInput, x))
            .ToList();

        Console.WriteLine(String.Join(" ", numbers));
    }
}
