namespace _02.DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long[,] matrix = new long[n, n];

            for (long i = 0; i < n; i++)
            {
                long[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                for (long j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            long primaryD = 0;
            long secondaryD = 0;
            for (long i = 0; i < n; i++)
            {
                primaryD += matrix[i, i];
                secondaryD += matrix[n - i - 1, i];
            }

            Console.WriteLine(Math.Abs(primaryD - secondaryD));
        }
    }
}
