namespace _07.ChristmasTree
{
    using System;

    public class ChristmasTree
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i <= N; i++)
            {
                Console.Write(new string(' ', N - i));
                Console.Write(new string('*', i));
                Console.Write(" | ");
                Console.Write(new string('*', i));
                Console.WriteLine(new string(' ', N - i));
            }
        }
    }
}
