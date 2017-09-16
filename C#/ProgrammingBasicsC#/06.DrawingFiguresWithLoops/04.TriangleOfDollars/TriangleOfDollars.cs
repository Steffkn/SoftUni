namespace _04.TriangleOfDollars
{
    using System;

    public class TriangleOfDollars
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("$ ");
                }

                Console.WriteLine("$");
            }
        }
    }
}
