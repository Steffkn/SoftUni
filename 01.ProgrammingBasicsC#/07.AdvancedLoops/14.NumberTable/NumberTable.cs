namespace _14.NumberTable
{
    using System;

    public class NumberTable
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {

                for (int j = 0; j < N; j++)
                {
                    if (j < N - i)
                    {
                        Console.Write(string.Format("{0} ", i + j + 1));
                    }
                    else
                    {
                        Console.Write(string.Format("{0} ", 2 * N - (i + j + 1)));
                    }
                }
                Console.WriteLine();
            }
        }
    }
}