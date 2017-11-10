
namespace _04.RoliTheCoder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RoliTheCoder
    {
        static void Main()
        {
            var events = new Dictionary<int, Event>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input.Equals("Time for Code"))
                {
                    break;
                }

                var args = input.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();


                int id = int.Parse(args[0]);

                if (!args[1].Contains('#'))
                {
                    continue;
                }

                string eventName = args[1].Replace("#", "");

                if (args.Skip(2).ToList().Any(x => !x.StartsWith("@")))
                {
                    continue;
                }

                if (!events.ContainsKey(id))
                {
                    events.Add(id, new Event(eventName));
                    events[id].people.AddRange(args.Skip(2).ToList());
                }
                else
                {
                    if (events[id].name.CompareTo(eventName) == 0)
                    {
                        events[id].people.AddRange(args.Skip(2).ToList());
                        events[id].people = events[id].people.Distinct().ToList();
                    }
                }
            }

            foreach (var eventt in events
                .OrderByDescending(x => x.Value.people.Count)
                .ThenBy(x => x.Value.name)
                )
            {
                Console.WriteLine($"{eventt.Value.name} - {eventt.Value.people.Count}");
                foreach (var person in eventt.Value.people.OrderBy(x => x))
                {
                    Console.WriteLine(person);
                }
            }

        }

        public class Event
        {
            public string name;
            public List<string> people = new List<string>();

            public Event(string name)
            {
                this.name = name;
            }
        }
    }
}
