namespace _10.Diamond
{
    using System;

    public class Diamond
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            if (N == 1)
            {
                Console.WriteLine("*");
                return;
            }
            else if (N == 2)
            {
                Console.WriteLine("**");
                return;
            }

            for (int i = 0; i < (N + 1) / 2 - 1; i++)
            {
                Console.Write(new string('-', (N - 1) / 2));

                var mid = N - 2 * ((N - 1) / 2) - 2;

                if (mid > 0)
                {
                    Console.Write("*");
                    Console.Write(new string('-', mid));
                }

                Console.Write("*");
                Console.WriteLine(new string('-', (N - 1) / 2));
            }
        }
    }
}
