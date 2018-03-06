using System;

class StartUp
{
    static void Main(string[] args)
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();
        var modifier = new DateModifier();
        Console.WriteLine(modifier.CaclulateDifference(firstDate, secondDate));
    }
}
