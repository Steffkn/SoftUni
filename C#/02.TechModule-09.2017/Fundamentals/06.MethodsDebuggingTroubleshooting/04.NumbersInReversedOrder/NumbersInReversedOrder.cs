using System;

namespace _04.NumbersInReversedOrder
{
    class NumbersInReversedOrder
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());

            decimal reversedNumber = ReverceNumber(number);

            Console.WriteLine(reversedNumber);
        }

        private static decimal ReverceNumber(decimal number)
        {
            string strNumber = number.ToString();
            string result = string.Empty;

            for (int i = strNumber.Length - 1; i >= 0; i--)
            {
                result += strNumber[i];
            }

            return decimal.Parse(result);
        }
    }
}
