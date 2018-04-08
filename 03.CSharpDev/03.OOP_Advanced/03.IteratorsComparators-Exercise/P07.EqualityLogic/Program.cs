namespace P07.EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var peopleInSortedSet = new SortedSet<Person>();
            var peopleInHashSet = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split();
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                var newPerson = new Person(name, age);
                peopleInSortedSet.Add(newPerson);
                peopleInHashSet.Add(newPerson);
            }

            Console.WriteLine(peopleInSortedSet.Count);
            Console.WriteLine(peopleInHashSet.Count);
        }
    }
}
