using System;
using System.Collections.Generic;
using System.Linq;

public class InfernoIII
{
    public static void Main()
    {
        var gemsPower = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Func<string, List<int>, int, int, bool> filter = (condition, gems, gemIndex, attr) =>
        {
            int leftIndex = gemIndex > 0 ? gems[gemIndex - 1] : 0;
            int rightIndex = gemIndex + 1 < gems.Count ? gems[gemIndex + 1] : 0;
            switch (condition.ToLower())
            {
                case "sum left":
                    return leftIndex + gems[gemIndex] == attr;
                case "sum right":
                    return gems[gemIndex] + rightIndex == attr;
                case "sum left right":
                    return (leftIndex + gems[gemIndex] + rightIndex) == attr;
                default:
                    return false;
            }
        };

        var excludions = new Stack<int>();

        var tockens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToArray();
        while (!tockens[0].Equals("Forge"))
        {
            if (tockens[0] == "Exclude")
            {
                for (int i = 0; i < gemsPower.Count; i++)
                {
                    if (filter(tockens[1], gemsPower, i, int.Parse(tockens[2])))
                    {
                        excludions.Push(0);
                    }
                }
            }
            else
            {
                if (excludions.Count > 0)
                {
                    excludions.Pop();
                }
            }

            tockens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
        }

        foreach (int excludion in excludions)
        {
            gemsPower.RemoveAt(excludion);
        }

        Console.WriteLine(String.Join(" ", gemsPower));
    }
}
