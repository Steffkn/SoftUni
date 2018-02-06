using System;
using System.Linq;

public class CustomMinFunction
{
    public static void Main()
    {
        int smallest = int.MaxValue;
        Func<int, int, int> tester = (a, b) => a < b ? a : b;

        Console.ReadLine()?
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .ForEach(number => smallest = tester(number, smallest));
        Console.WriteLine(smallest);
    }
}
