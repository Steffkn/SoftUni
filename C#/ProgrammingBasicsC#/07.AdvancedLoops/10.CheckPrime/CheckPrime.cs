namespace _10.CheckPrime
{
    using System;

    public class CheckPrime
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            if (N < 2)
            {
                Console.WriteLine("Not Prime");
                return;
            }

            for (int i = 2; i <= Math.Sqrt(N); i++)
            {
                if (N % i == 0)
                {
                    Console.WriteLine("Not Prime");
                    return;
                }
            }

            Console.WriteLine("Prime");
        }
    }
}
