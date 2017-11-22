namespace _03.SquareOfStars
{
    using System;

    public class SquareOfStars
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N - 1; j++)
                {
                    Console.Write("* ");
                }

                Console.WriteLine("*");
            }
        }
    }
}
