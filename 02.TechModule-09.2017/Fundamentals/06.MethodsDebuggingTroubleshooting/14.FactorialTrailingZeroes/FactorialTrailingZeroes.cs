namespace _14.FactorialTrailingZeroes
{
    using System;
    using System.Numerics;

    public class FactorialTrailingZeroes
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = GetFactorialOfN(n);

            int trailingZeros = GetTrailingZeros(factorial.ToString());

            Console.WriteLine(trailingZeros);
        }

        private static int GetTrailingZeros(string number)
        {
            int count = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                var num = number[i];
                if (num == '0')
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private static BigInteger GetFactorialOfN(int n)
        {
            BigInteger result = new BigInteger();
            result = 1;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
