namespace _13.GameOfNumbers
{
    using System;

    public class GameOfNumbers
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            string result = string.Empty;
            int combinations = 0;

            for (int i = N; i <= M; i++)
            {
                for (int j = N; j <= M; j++)
                {
                    combinations++;

                    if (i + j == magicNumber)
                    {
                        result = string.Format($"{i} + {j} = {magicNumber}");
                    }
                }
            }

            if (result != string.Empty)
            {
                Console.WriteLine($"Number found! {result}");
            }
            else
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNumber}");
            }
        }
    }
}