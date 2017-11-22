namespace _12.TestNumbers
{
    using System;

    public class TestNumbers
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int maxSum = int.Parse(Console.ReadLine());
            int totalSum = 0;
            int count = 0;

            for (int i = N; i >= 1; i--)
            {
                for (int k = 1; k <= M; k++)
                {
                    totalSum += i * k * 3;
                    count++;
                    if (totalSum >= maxSum)
                    {
                        break;
                    }
                }

                if (totalSum >= maxSum)
                {
                    Console.WriteLine($"{count} combinations");
                    Console.WriteLine($"Sum: {totalSum} >= {maxSum}");
                    return;
                }
            }

            Console.WriteLine($"{count} combinations");
            Console.WriteLine($"Sum: {totalSum}");
        }
    }
}