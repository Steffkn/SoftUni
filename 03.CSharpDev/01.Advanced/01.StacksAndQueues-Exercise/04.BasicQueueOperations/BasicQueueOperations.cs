namespace _04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueueOperations
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
            var numbersStack = new Queue<int>();

            for (int i = 0; i < tokens[0]; i++)
            {
                numbersStack.Enqueue(numbersArray[i]);
            }

            for (int i = 0; i < tokens[1]; i++)
            {
                numbersStack.Dequeue();
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
