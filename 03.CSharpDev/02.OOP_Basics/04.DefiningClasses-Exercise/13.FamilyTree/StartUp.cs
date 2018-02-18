using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        string personString = Console.ReadLine().Trim();
        var people = new List<Person>();
        var instructions = new Queue<KeyValuePair<string, string>>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var inputArgs = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (inputArgs.Length > 1)
            {
                var parentInfo = inputArgs[0].Trim();
                var childInfo = inputArgs[1].Trim();

                instructions.Enqueue(new KeyValuePair<string, string>(parentInfo, childInfo));
            }
            else
            {
                var personInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person() { Name = $"{personInfo[0]} {personInfo[1]}", BirthDay = personInfo[2] });
            }
        }

        while (instructions.Count > 0)
        {
            var kvp = instructions.Dequeue();
            var parentInfo = kvp.Key;
            var childInfo = kvp.Value;

            if (IsDate(parentInfo))
            {
                var parent = people.First(x => x.BirthDay.Equals(parentInfo));

                if (IsDate(childInfo))
                {
                    var child = people.First(x => x.BirthDay.Equals(childInfo));

                    parent.Children.Add(child);
                    child.Parents.Add(parent);
                }
                else
                {
                    var child = people.First(x => x.Name.Equals(childInfo));

                    parent.Children.Add(child);
                    child.Parents.Add(parent);
                }
            }
            else
            {
                var parent = people.First(x => x.Name.Equals(parentInfo));
                if (IsDate(childInfo))
                {
                    var child = people.First(x => x.BirthDay.Equals(childInfo));

                    parent.Children.Add(child);
                    child.Parents.Add(parent);
                }
                else
                {
                    var child = people.First(x => x.Name.Equals(childInfo));

                    parent.Children.Add(child);
                    child.Parents.Add(parent);
                }
            }
        }

        Console.Write(IsDate(personString)
            ? people.First(x => x.BirthDay.Equals(personString))
            : people.First(x => x.Name.Equals(personString)));
    }

    public static bool IsDate(string input)
    {
        return input.Contains("/");
    }
}
