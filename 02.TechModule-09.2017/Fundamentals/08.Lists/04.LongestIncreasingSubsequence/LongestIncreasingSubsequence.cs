namespace _04.LongestIncreasingSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] len = new int[numbers.Length];
            int[] prev = new int[numbers.Length];
            int maxLen = 0;
            int lastIndex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] < numbers[i] && len[j] >= len[i])
                    {
                        len[i] = 1 + len[j];
                        prev[i] = j;
                    }
                }

                if (len[i] > maxLen)
                {
                    maxLen = len[i];
                    lastIndex = i;
                }
            }

            var longestSeq = new List<int>();
            for (int i = 0; i < maxLen; i++)
            {
                longestSeq.Add(numbers[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSeq.Reverse();
            Console.WriteLine(String.Join(" ", longestSeq));
        }
    }
}
