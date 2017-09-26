namespace _05.Diamond
{
    using System;

    public class Diamond
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            Console.Write(new string('.', N));
            Console.Write(new string('*', 3 * N));
            Console.WriteLine(new string('.', N));

            for (int i = 1; i < N; i++)
            {
                Console.Write(new string('.', N - i));
                Console.Write('*');
                Console.Write(new string('.', 3 * N + i * 2 - 2));
                Console.Write('*');
                Console.WriteLine(new string('.', N - i));
            }

            Console.WriteLine(new string('*', 5 * N));

            int asterixIndex = 1;
            for (int row = 0; row < 2 * N; row++)
            {
                for (int col = 0; col < 5 * N; col++)
                {
                    if (col == asterixIndex || col == (5 * N) - asterixIndex - 1)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                asterixIndex++;
                Console.WriteLine();
            }

            Console.Write(new string('.', 2 * N + 1));
            Console.Write(new string('*',  N - 2));
            Console.WriteLine(new string('.', 2 * N + 1));
        }
    }
}
