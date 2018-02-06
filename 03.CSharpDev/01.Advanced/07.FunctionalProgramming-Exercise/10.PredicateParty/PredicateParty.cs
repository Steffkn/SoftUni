using System;
using System.Collections.Generic;
using System.Linq;

public class PredicateParty
{
    public static void Main()
    {
        var people = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Func<string, string, string, bool> filter = (condition, attr, person) =>
        {
            switch (condition.ToLower())
            {
                case "startswith":
                    return person.StartsWith(attr);
                case "length":
                    return person.Length == int.Parse(attr);
                case "endswith":
                    return person.EndsWith(attr);
                default:
                    throw new InvalidOperationException();
            }
        };

        Func<string, string, bool> removeFilter = (s1, s2) => s1.Equals(s2);

        var tockens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (!tockens[0].Equals("Party!"))
        {
            var person = people.Where(p => filter(tockens[1], tockens[2], p)).ToList();
            if (tockens[0] == "Double")
            {
                foreach (string s in person)
                {
                    int nameIndex = people.IndexOf(s);
                    people.Insert(nameIndex, s);
                }
            }
            else
            {
                foreach (string p in person)
                {
                    people.RemoveAll(s => removeFilter(p, s));
                }
            }

            tockens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        if (people.Count == 0)
        {
            Console.WriteLine("Nobody is going to the party!");
        }
        else
        {
            Console.WriteLine("{0} are going to the party!", String.Join(", ", people));
        }
    }
}
