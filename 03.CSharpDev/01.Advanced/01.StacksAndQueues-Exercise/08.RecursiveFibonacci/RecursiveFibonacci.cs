namespace _08.RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;

    public class RecursiveFibonacci
    {
        static Dictionary<int, long> memo = new Dictionary<int, long>();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFib(n));
        }

        static long GetFib(int n)
        {
            if (n == 2 || n == 1)
            {
                return 1;
            }

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            long node = GetFib(n - 2) + GetFib(n - 1);
            memo.Add(n, node);
            return node;
        }
    }
}
