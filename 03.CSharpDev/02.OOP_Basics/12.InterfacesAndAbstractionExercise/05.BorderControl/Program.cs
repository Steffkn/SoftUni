using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string input = string.Empty;
        List<IEntity> entities = new List<IEntity>();

        while ((input = Console.ReadLine()) != "End")
        {
            var entityArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (entityArgs.Length == 2)
            {
                entities.Add(new Robot(entityArgs[0], entityArgs[1]));
            }
            else
            {
                entities.Add(new Person(entityArgs[0], entityArgs[2], int.Parse(entityArgs[1])));
            }
        }

        var invalidIds = Console.ReadLine().Trim();

        var invalidEntitiesIds = entities.Where(e => e.Id.EndsWith(invalidIds)).Select(e => e.Id);

        foreach (var invalidEntitiesId in invalidEntitiesIds)
        {
            Console.WriteLine(invalidEntitiesId);
        }
    }
}