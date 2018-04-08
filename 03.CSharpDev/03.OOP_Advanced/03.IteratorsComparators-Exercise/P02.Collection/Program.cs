using System;
using System.Linq;

namespace P01.ListyIterator
{
    public class Program
    {
        static void Main()
        {
            string[] createArgs = Console.ReadLine().Split(' ');

            var listyIterator = new ListyIterator<string>(createArgs.Skip(1).ToList());

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    switch (input)
                    {
                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;
                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;
                        case "Print":
                            listyIterator.Print();
                            break;
                        case "PrintAll":
                            Console.WriteLine(string.Join(" ", listyIterator));
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
