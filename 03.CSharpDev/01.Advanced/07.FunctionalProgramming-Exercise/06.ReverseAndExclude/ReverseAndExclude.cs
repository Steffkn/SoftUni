using System;
using System.Linq;

public class ReverseAndExclude
{
    public static void Main()
    {
        var numbers = Console.ReadLine()?
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        var n = int.Parse(Console.ReadLine());

        Func<int, int, bool> filter = (number, devider) => number % devider == 0;

        var result = numbers?.Where(number => !filter(number, n)).Reverse().ToList();

        Console.WriteLine(String.Join(" ", result));
    }
}
