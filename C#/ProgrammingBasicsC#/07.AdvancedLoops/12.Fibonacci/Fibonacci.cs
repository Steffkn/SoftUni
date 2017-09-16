namespace _12.Fibonacci
{
    using System;

    public class Fibonacci
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            int f0 = 0;
            int f1 = 1;

            if (N < 2)
            {
                Console.WriteLine(1);
                return;
            }

            for (int i = 1; i <= N; i++)
            {
                var sum = f0 + f1;

                f0 = f1;
                f1 = sum;
            }

            Console.WriteLine(f1);
        }
    }
}
