using System;
using System.Collections.Generic;

namespace _05.SequenceWithQueue
{
    class SequenceWithQueue
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            var numbersQueue = new Queue<long>();
            var trackQueue = new Queue<long>();

            numbersQueue.Enqueue(n);

            while (numbersQueue.Count + trackQueue.Count <= 50)
            {
                long currentNumber = numbersQueue.Dequeue();
                numbersQueue.Enqueue(currentNumber + 1);
                numbersQueue.Enqueue(2 * currentNumber + 1);
                numbersQueue.Enqueue(currentNumber + 2);
                trackQueue.Enqueue(currentNumber);
            }

            while (trackQueue.Count < 50)
            {
                trackQueue.Enqueue(numbersQueue.Dequeue());
            }

            Console.WriteLine(String.Join(" ", trackQueue));
        }
    }
}
