using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Task 3
        // PrintOldestPerson();

        // Task 4
        PrintMembersOlderThan30();
    }

    private static void PrintMembersOlderThan30()
    {
        int n = int.Parse(Console.ReadLine());
        var family = new Family();
        for (int i = 0; i < n; i++)
        {
            var tockens = Console.ReadLine().Split();

            family.AddMember(new Person()
            {
                Name = tockens[0],
                Age = int.Parse(tockens[1])
            });
        }

        var olderThan30 = family.FamilyMembers.Where(x => x.Age > 30).OrderBy(x => x.Name);

        foreach (var person in olderThan30)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }

    private static void PrintOldestPerson()
    {
        int n = int.Parse(Console.ReadLine());
        var family = new Family();
        for (int i = 0; i < n; i++)
        {
            var tockens = Console.ReadLine().Split();

            family.AddMember(new Person()
            {
                Name = tockens[0],
                Age = int.Parse(tockens[1])
            });
        }

        var oldesPerson = family.GetOldestMember();
        Console.WriteLine($"{oldesPerson.Name} {oldesPerson.Age}");
    }
}
