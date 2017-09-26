namespace _03.GreeetingByName
{
    using System;

    class GreeetingByName
    {
        static void Main()
        {
            var name = Console.ReadLine();
            Console.WriteLine(string.Format("Hello, {0}!", name));
        }
    }
}
