using System;
using System.Linq;

public class AppliedArithmetics
{
    public static void Main()
    {
        var numbers = Console.ReadLine()?
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        Func<string, int, int> filter = (condition, number) =>
        {
            switch (condition.ToLower())
            {
                case "add":
                    return number + 1;
                case "multiply":
                    return number * 2;
                case "subtract":
                    return number - 1;
                default:
                    return number;
            }
        };

        string command = Console.ReadLine();
        while (!command.Equals("end"))
        {
            if (command != "print")
            {
                numbers = numbers.Select(n => filter(command, n)).ToList();
            }
            else
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
            command = Console.ReadLine();
        }

    }
}
