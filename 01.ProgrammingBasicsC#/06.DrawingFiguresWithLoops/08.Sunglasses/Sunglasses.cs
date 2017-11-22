namespace _08.Sunglasses
{
    using System;

    public class Sunglasses
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            Console.Write(new string('*', N * 2));
            Console.Write(new string(' ', N));
            Console.WriteLine(new string('*', N * 2));

            for (int i = 0; i < N - 2; i++)
            {
                Console.Write('*');
                Console.Write(new string('/', 2 * N - 2));
                Console.Write('*');

                if (i == ((N - 1) / 2) - 1)
                {
                    Console.Write(new string('|', N));
                }
                else
                {
                    Console.Write(new string(' ', N));
                }

                Console.Write('*');
                Console.Write(new string('/', 2 * N - 2));
                Console.WriteLine('*');
            }

            Console.Write(new string('*', N * 2));
            Console.Write(new string(' ', N));
            Console.WriteLine(new string('*', N * 2));
        }
    }
}
