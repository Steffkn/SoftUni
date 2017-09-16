namespace _06.RhombusOfStars
{
    using System;
    using System.Linq;

    public class RhombusOfStars
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 1; i < N; i++)
            {
                Console.Write(new string(' ', N - i));

                for (int a = 1; a <= i; a++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine(new string(' ', N - i - 1));
            }

            Console.WriteLine(String.Concat(Enumerable.Repeat("* ", N)).TrimEnd());

            for (int i = N; i > 1; i--)
            {
                Console.Write(new string(' ', N - i + 1));

                for (int a = 1; a < i; a++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine(new string(' ', N - i));
            }
        }
    }
}
