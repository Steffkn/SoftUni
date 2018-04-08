using System.Collections.Generic;
using System.Linq;

namespace P05.ComparingObjects
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var people = new List<Person>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] personArgs = command.Split().ToArray();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                string town = personArgs[2];

                Person newPerson = new Person(name, age, town);
                people.Add(newPerson);
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person seekPerson = people[index];
            var equalPeople = people.Count(x => x.CompareTo(seekPerson) == 0);

            if (equalPeople < 2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int notEqualPeople = people.Count - equalPeople;
                Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
            }

        }
    }
}
