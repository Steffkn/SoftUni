using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string input = string.Empty;
        List<IBirthable> entities = new List<IBirthable>();

        while ((input = Console.ReadLine()) != "End")
        {
            var entityArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (entityArgs[0])
            {
                case "Pet":
                    entities.Add(new Pet(entityArgs[1], entityArgs[2]));
                    break;
                case "Citizen":
                    entities.Add(new Person(entityArgs[1], entityArgs[3], int.Parse(entityArgs[2]), entityArgs[4]));
                    break;
            }
        }

        var birthDate = Console.ReadLine().Trim();

        var birthDates = entities.Where(e => e.BirthDate.EndsWith(birthDate)).Select(e => e.BirthDate);

        foreach (var bd in birthDates)
        {
            Console.WriteLine(bd);
        }
    }
}