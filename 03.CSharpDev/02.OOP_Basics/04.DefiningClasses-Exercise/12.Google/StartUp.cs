using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        var people = new Dictionary<string, Person>();
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var personInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var personName = personInfo[0];

            if (!people.ContainsKey(personName))
            {
                people.Add(personName, new Person(personName));
            }

            switch (personInfo[1])
            {
                case "company":
                    people[personName].Company = new Company(personInfo[2], personInfo[3], decimal.Parse(personInfo[4]));
                    break;
                case "car":
                    people[personName].Car = new Car(personInfo[2], int.Parse(personInfo[3]));
                    break;
                case "pokemon":
                    people[personName].Pokemons.Add(new Pokemon(personInfo[2], personInfo[3]));
                    break;
                case "parents":
                    people[personName].Parents.Add(new Relative(personInfo[2], personInfo[3]));
                    break;
                case "children":
                    people[personName].Children.Add(new Relative(personInfo[2], personInfo[3]));
                    break;
            }
        }

        var person = Console.ReadLine().Trim();

        Console.Write(people[person]);
    }
}
