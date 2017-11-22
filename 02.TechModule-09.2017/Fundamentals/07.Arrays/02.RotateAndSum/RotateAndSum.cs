namespace _02.RotateAndSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RotateAndSum
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            int shiftCount = int.Parse(Console.ReadLine());

            var shifts = new List<long[]>();

            for (int i = 0; i < shiftCount; i++)
            {
                numbers = ShiftRight(numbers);
                shifts.Add(numbers.Clone() as long[]);
            }

            long[] sum = new long[numbers.Length];

            sum = SumArrayList(shifts, sum.Length);

            string result = string.Empty;
            foreach (var number in sum)
            {
                result += number + " ";
            }

            Console.WriteLine(result.Trim());
        }

        private static long[] SumArrayList(List<long[]> shifts, int lenght)
        {
            long[] sum = new long[lenght];

            for (int i = 0; i < shifts.Count; i++)
            {
                for (int j = 0; j < sum.Length; j++)
                {
                    sum[j] += shifts[i][j];
                }
            }

            return sum;
        }

        private static long[] ShiftRight(long[] numbers)
        {
            long last = numbers[numbers.Length - 1];

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                numbers[i] = numbers[i - 1];
            }
            numbers[0] = last;

            return numbers;
        }
    }
}
