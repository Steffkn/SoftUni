namespace _09.House
{
    using System;

    public class House
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());


            for (int i = 1; i < (N + 1) / 2; i++)
            {
                if (N % 2 == 0)
                {
                    Console.Write(new string('-', (N + 1) / 2 - i));

                    Console.Write(new string('*', i * 2));

                    Console.WriteLine(new string('-', (N + 1) / 2 - i));
                }
                else
                {
                    Console.Write(new string('-', (N + 1) / 2 - i));

                    Console.Write(new string('*', i * 2 - 1));

                    Console.WriteLine(new string('-', (N + 1) / 2 - i));
                }
            }

            Console.WriteLine(new string('*', N));

            for (int j = 0; j < (N / 2); j++)
            {
                Console.Write('|');
                Console.Write(new string('*', N - 2));
                Console.WriteLine('|');
            }
        }
    }
}
