using System;

public class Program
{
    static void Main()
    {
        var phoneNumbers = Console.ReadLine().Split(' ');
        var webSites = Console.ReadLine().Split(' ');

        var smartphone = new Smartphone();
        foreach (var phoneNumber in phoneNumbers)
        {
            Console.WriteLine(smartphone.Call(phoneNumber));
        }
        foreach (var webSite in webSites)
        {
            Console.WriteLine(smartphone.Browse(webSite));
        }
    }
}
