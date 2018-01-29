namespace _02.BasicStackOperations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class BasicStackOperations
    {
        static void Main()
        {
            var tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var numbersArray = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var numbersStack = new Stack<int>();

            for (int i = 0; i < tokens[0]; i++)
            {
                numbersStack.Push(numbersArray[i]);
            }

            for (int i = 0; i < tokens[1]; i++)
            {
                numbersStack.Pop();
            }

            if (numbersStack.Contains(tokens[2]))
            {
                Console.WriteLine("true");
            }
            else if (numbersStack.Count > 0)
            {
                Console.WriteLine(numbersStack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
