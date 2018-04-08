using System;
using System.Linq;
using P03.Iterator.Models;

namespace P03.Iterator
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string[] listArgs = input.Split(' ').Skip(1).ToArray();
            var listIterator = new ListIterator(listArgs);

            var engine = new Engine(listIterator);
            engine.Run();
        }
    }
}
