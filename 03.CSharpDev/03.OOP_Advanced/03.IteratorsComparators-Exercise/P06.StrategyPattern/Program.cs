namespace P06.StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var peopleByName = new SortedSet<Person>(new PersonNameComparer());
            var peopleByAge = new SortedSet<Person>(new PersonAgeComparer());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine().Split();
                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);
                var newPerson = new Person(name, age);
                peopleByName.Add(newPerson);
                peopleByAge.Add(newPerson);
            }

            foreach (var person in peopleByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in peopleByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
