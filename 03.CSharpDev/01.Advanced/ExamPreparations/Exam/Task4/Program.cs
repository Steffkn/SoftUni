using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int infoIndexNeeded = int.Parse(input);
            var people = new Dictionary<string, Dictionary<string, string>>();

            while (!(input = Console.ReadLine()).Equals("end transmissions"))
            {
                var tockens = input.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tockens[0];
                var data = tockens[1].Split(new char[] { ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, new Dictionary<string, string>());
                }

                for (int i = 0; i < data.Length; i += 2)
                {
                    if (!people[name].ContainsKey(data[i]))
                    {
                        people[name].Add(data[i], data[i + 1]);
                    }
                    else
                    {
                        people[name][data[i]] = data[i + 1];
                    }
                }
            }

            var killTarget = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

            if (people.ContainsKey(killTarget))
            {
                Console.WriteLine($"Info on {killTarget}:");
                int infoIndex = 0;
                foreach (var attr in people[killTarget]
                    .OrderBy(x => x.Key))
                {
                    Console.WriteLine($"---{attr.Key}: {attr.Value}");
                    infoIndex += attr.Key.Length;
                    infoIndex += attr.Value.Length;
                }

                Console.WriteLine($"Info index: {infoIndex}");
                if (infoIndexNeeded <= infoIndex)
                {
                    Console.WriteLine("Proceed");
                }
                else
                {
                    Console.WriteLine($"Need {infoIndexNeeded - infoIndex} more info.");
                }
            }
        }
    }
}
