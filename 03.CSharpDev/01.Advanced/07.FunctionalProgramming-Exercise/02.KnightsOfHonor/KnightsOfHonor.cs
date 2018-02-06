using System;
using System.Linq;

public class KnightsOfHonor
{
    public static void Main()
    {
        Action<string> print = (message) => Console.WriteLine("Sir {0}", message);
        var names = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        names.ForEach(x => print(x));
    }
}
