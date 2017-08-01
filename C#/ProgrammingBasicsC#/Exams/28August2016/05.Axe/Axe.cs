namespace _05.Axe
{
    using System;

    public class Axe
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Console.Write(new string('-', N * 3));
                Console.Write("*");
                Console.Write(new string('-', i));
                Console.Write("*");
                Console.WriteLine(new string('-', 2 * N - i - 2));
            }

            for (int i = 0; i < N / 2; i++)
            {
                Console.Write(new string('*', N * 3));
                Console.Write("*");
                Console.Write(new string('-', N - 1));
                Console.Write("*");
                Console.WriteLine(new string('-', N - 1));
            }

            for (int i = 0; i <= N / 2 - 1; i++)
            {
                Console.Write(new string('-', N * 3 - i));
                Console.Write("*");

                if (i != N / 2 - 1)
                {
                    Console.Write(new string('-', N - 1 + i * 2));
                }
                else
                {
                    Console.Write(new string('*', N - 1 + i * 2));
                }

                Console.Write("*");
                Console.WriteLine(new string('-', N - 1 - i));
            }
        }
    }
}
