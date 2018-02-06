using System;
using System.Linq;

public class PredicateForNames
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Predicate<string> filter = s => s.Length <= n;

        Console.ReadLine()?
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(s => filter(s))
            .ToList()
            .ForEach(s => Console.WriteLine(s));
    }
}
