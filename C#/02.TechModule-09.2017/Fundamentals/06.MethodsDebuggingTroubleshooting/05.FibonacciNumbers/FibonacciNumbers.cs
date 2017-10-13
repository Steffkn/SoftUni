using System;

namespace _05.FibonacciNumbers
{
    class FibonacciNumbers
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            if (N == 0 || N == 1)
            {
                Console.WriteLine(1);
                return;
            }

            Console.WriteLine(Fib(N));
        }

        private static long Fib(int nthNumber)
        {
            long fibN1 = 1;
            long fibN2 = 1;
            long fibN3 = 0;
            for (int i = 2; i <= nthNumber; i++)
            {
                fibN3 = fibN1 + fibN2;
                fibN1 = fibN2;
                fibN2 = fibN3;
            }

            return fibN3;
        }
    }
}
