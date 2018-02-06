using System;
using System.Linq;

public class PartyReservationFilterModule
{
    public static void Main()
    {
        var people = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => new Person(x))
            .ToList();

        Func<string, string, string, bool> filter = (condition, attr, person) =>
        {
            switch (condition.ToLower())
            {
                case "starts with":
                    return person.StartsWith(attr);
                case "length":
                    return person.Length == int.Parse(attr);
                case "ends with":
                    return person.EndsWith(attr);
                case "contains":
                    return person.Contains(attr);
                default:
                    return person.Length == -1;
            }
        };

        var tockens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToArray();
        while (!tockens[0].Equals("Print"))
        {
            var ppl = people.Where(p => filter(tockens[1], tockens[2], p.Name))
                .Select(p => p.Name)
                .ToList();

            if (tockens[0] == "Add filter")
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (filter(tockens[1], tockens[2], people[i].Name))
                    {
                        people[i].Filtered = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (filter(tockens[1], tockens[2], people[i].Name))
                    {
                        people[i].Filtered = false;
                    }
                }
            }

            tockens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
        }

        Console.WriteLine(String.Join(" ", people.Where(p => p.Filtered == false).Select(p => p.Name).ToList()));
    }

    public class Person
    {
        public string Name { get; set; }

        public bool Filtered { get; set; }

        public Person(string name)
        {
            this.Name = name;
            this.Filtered = false;
        }
    }
}
