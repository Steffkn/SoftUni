using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var peopleDict = new Dictionary<string, IBuyer>();

        for (int i = 0; i < n; i++)
        {
            var inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (inputArgs.Length == 4)
            {
                peopleDict.Add(inputArgs[0], new Person(inputArgs[0], inputArgs[2], int.Parse(inputArgs[1]), inputArgs[3]));
            }
            else
            {
                peopleDict.Add(inputArgs[0], new Rebel(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]));
            }
        }

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            if (peopleDict.ContainsKey(input))
            {
                peopleDict[input].BuyFood();
            }
        }

        Console.WriteLine(peopleDict.Values.Sum(v => v.Food));
    }
}