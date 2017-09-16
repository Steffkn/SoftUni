namespace _05.SquareFrame
{
    using System;

    public class SquareFrame
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());


            Console.Write("+ ");
            for (int a = 0; a < N - 2; a++)
            {
                Console.Write("- ");
            }
            Console.WriteLine('+');

            for (int i = 0; i < N - 2; i++)
            {
                Console.Write("| ");
                for (int a = 0; a < N - 2; a++)
                {
                    Console.Write("- ");
                }
                Console.WriteLine('|');
            }

            Console.Write("+ ");
            for (int a = 0; a < N - 2; a++)
            {
                Console.Write("- ");
            }
            Console.WriteLine('+');
        }
    }
}
