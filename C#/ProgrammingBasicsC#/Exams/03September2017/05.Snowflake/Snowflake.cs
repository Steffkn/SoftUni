namespace _05.Snowflake
{
    using System;

    public class Snowflake
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N - 1; i++)
            {
                Console.Write(new string('.', i));
                Console.Write("*");
                Console.Write(new string('.', N - i));
                Console.Write("*");
                Console.Write(new string('.', N - i));
                Console.Write("*");
                Console.Write(new string('.', i));
                Console.WriteLine();
            }
            Console.Write(new string('.', N - 1));
            Console.Write(new string('*', 5));
            Console.WriteLine(new string('.', N - 1));

            Console.WriteLine(new string('*', 2 * N + 3));

            Console.Write(new string('.', N - 1));
            Console.Write(new string('*', 5));
            Console.WriteLine(new string('.', N - 1));

            for (int i = N-2; i >= 0; i--)
            {
                Console.Write(new string('.', i));
                Console.Write("*");
                Console.Write(new string('.', N - i));
                Console.Write("*");
                Console.Write(new string('.', N - i));
                Console.Write("*");
                Console.Write(new string('.', i));
                Console.WriteLine();
            }

        }
    }
}
