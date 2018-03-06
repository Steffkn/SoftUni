using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class StartUp
{
    static void Main()
    {
        try
        {
            var people = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                    {
                        var args = x.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        return new KeyValuePair<string, decimal>(args[0], decimal.Parse(args[1]));
                    })
                .ToDictionary(x => x.Key, v => new Person(v.Key, v.Value));

            var products = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                    {
                        var args = x.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        return new KeyValuePair<string, decimal>(args[0], decimal.Parse(args[1]));
                    })
                .ToDictionary(x => x.Key, v => new Product(v.Key, v.Value));

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var personName = inputArgs[0];
                var productName = inputArgs[1];

                if (people.ContainsKey(personName) && products.ContainsKey(productName))
                {
                    if (people[personName].Money >= products[productName].Cost)
                    {
                        people[personName].Products.Add(products[productName]);
                        people[personName].Money -= products[productName].Cost;
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.Value.Products.Count == 0
                    ? $"{person.Key} - Nothing bought"
                    : $"{person.Key} - {String.Join(", ", person.Value.Products)}");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
