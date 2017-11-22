namespace _12.MasterNumber
{
    using System;

    public class MasterNumber
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (HasEvenDigit(i) && IsPalindrom(i) && SumOfDigitsDividsBySeven(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool HasEvenDigit(int number)
        {
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }

        private static bool SumOfDigitsDividsBySeven(int number)
        {
            long sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsPalindrom(int number)
        {
            if (number < 10)
            {
                return true;
            }
            else
            {
                string numberStr = number.ToString();

                for (int i = 0; i < (numberStr.Length / 2); i++)
                {
                    if (numberStr[i] != numberStr[numberStr.Length - i - 1])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
