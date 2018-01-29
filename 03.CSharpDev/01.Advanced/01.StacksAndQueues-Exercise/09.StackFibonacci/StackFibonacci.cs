
namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFib(n));
        }

        static long GetFib(int n)
        {
            Stack<long> numbers = new Stack<long>();
            numbers.Push(0);
            numbers.Push(1);

            for (int i = 1; i < n; i++)
            {
                long last = numbers.Pop();
                long secondLast = numbers.Peek();
                numbers.Push(last);
                numbers.Push(last + secondLast);
            }

            return numbers.Pop();
        }
    }
}
