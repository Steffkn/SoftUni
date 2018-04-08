using System;
using System.Linq;

namespace P03.Stack
{
    public class Program
    {
        static void Main()
        {
            var customStack = new CustomStack<int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commandArgs = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    string command = commandArgs[0];

                    switch (command)
                    {
                        case "Push":
                            foreach (int item in commandArgs.Skip(1).Select(int.Parse))
                            {
                                customStack.Push(item);
                            }
                            break;
                        case "Pop":
                            customStack.Pop();
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (int element in customStack)
            {
                Console.WriteLine(element);
            }

            foreach (int element in customStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
