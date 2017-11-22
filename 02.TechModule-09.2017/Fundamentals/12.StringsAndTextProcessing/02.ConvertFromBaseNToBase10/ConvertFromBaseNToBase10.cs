namespace _02.ConvertFromBaseNToBase10
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class ConvertFromBaseNToBase10
    {
        static void Main()
        {
            var inputs = Console.ReadLine().Split(new char[] { ' ' }).Select(BigInteger.Parse).ToArray();

            BigInteger fromBase = inputs[0];
            BigInteger number = inputs[1];

            var result = ConverFromNTo10(number, fromBase);

            Console.WriteLine(result);
        }

        public static BigInteger ConverFromNTo10(BigInteger number, BigInteger fromBase)
        {
            var result = new BigInteger();
            result = 0;
            BigInteger multiplier = 1;

            while (number > 0)
            {
                var digit = number % 10;
                result += digit * multiplier;
                multiplier *= fromBase;
                number /= 10;
            }

            return result;
        }
    }
}