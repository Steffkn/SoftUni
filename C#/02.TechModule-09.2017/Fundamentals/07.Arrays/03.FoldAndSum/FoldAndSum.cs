namespace _03.FoldAndSum
{
    using System;
    using System.Linq;

    public class FoldAndSum
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            int k = numbers.Length / 4;

            long[] firstRow = new long[2 * k];
            long[] secondRow = new long[2 * k];

            for (int i = 0, j = k - 1; i < k; i++, j--)
            {
                firstRow[j] = numbers[i];
            }

            for (int i = 3 * k, j = 2 * k - 1; i < 4 * k; i++, j--)
            {
                firstRow[j] = numbers[i];
            }

            for (int i = k, j = 0; i < 3 * k; i++, j++)
            {
                secondRow[j] = numbers[i];
            }
            string result = string.Empty;
            for (int i = 0; i < 2 * k; i++)
            {
                result += (firstRow[i] + secondRow[i]) + " ";
            }

            Console.WriteLine(result.Trim());
        }
    }
}
