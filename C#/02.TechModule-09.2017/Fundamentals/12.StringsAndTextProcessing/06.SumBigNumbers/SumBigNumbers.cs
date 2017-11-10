namespace _06.SumBigNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumBigNumbers
    {
        static void Main()
        {
            var a = Console.ReadLine().Reverse().ToArray();
            var b = Console.ReadLine().Reverse().ToArray();

            string result = AddTwoBigNumbers(a, b);
            Console.WriteLine(result.TrimStart(new char[] { ' ', '0' }));
        }

        private static string AddTwoBigNumbers(char[] a, char[] b)
        {
            int i = 0;
            char reminder = '0';
            List<char> result = new List<char>();

            for (i = 0; i < a.Length && i < b.Length; i++)
            {
                string sum = Sum2Numbers(a[i], b[i], reminder);
                result.Add(sum[1]);
                reminder = sum[0];
            }

            for (; i < a.Length; i++)
            {
                string sum = Sum2Numbers(a[i], '0', reminder);
                result.Add(sum[1]);
                reminder = sum[0];
            }

            for (; i < b.Length; i++)
            {
                string sum = Sum2Numbers(b[i], '0', reminder);
                result.Add(sum[1]);
                reminder = sum[0];
            }

            if (reminder != '0')
            {
                result.Add(reminder);
            }
            result.Reverse();

            return String.Join("", result.ToArray());
        }

        private static string Sum2Numbers(char a, char b, char reminder)
        {
            var balance = (int)'0' * (int)3;
            var sum = (int)a + (int)b + (int)reminder - balance;
            string result = string.Format("{0:D2}", sum);

            return result;
        }
    }
}