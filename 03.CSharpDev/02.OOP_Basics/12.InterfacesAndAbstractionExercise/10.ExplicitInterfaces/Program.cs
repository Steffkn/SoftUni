using System;

public class Program
{
    static void Main()
    {
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var personArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var person = new Citizen(personArgs[0], personArgs[1], int.Parse(personArgs[2]));
            Console.WriteLine(((IPerson)person).GetName());
            Console.WriteLine(((IResident)person).GetName());
        }
    }
}
