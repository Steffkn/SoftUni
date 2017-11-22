namespace _05.Sequence2KPlus1
{
    using System;

    public class Sequence2KPlus1
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i = 2 * i + 1)
            {
                Console.WriteLine(i);
            }
        }
    }
}
