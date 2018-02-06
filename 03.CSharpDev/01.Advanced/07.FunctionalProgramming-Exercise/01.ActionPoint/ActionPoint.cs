using System;
using System.Linq;

public class ActionPoint
{
    public static void Main()
    {
        Action<string> print = (message) => Console.WriteLine(message);
        var names = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        names.ForEach(x => print(x));
    }
}
