namespace _01.ConvertFromBase10ToBaseN
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class ConvertFromBase10ToBaseN
    {
        static void Main()
        {
            var inputs = Console.ReadLine().Split(new char[] { ' ' }).Select(BigInteger.Parse).ToArray();

            BigInteger newBase = inputs[0];
            BigInteger number = inputs[1];

            string result = ConverFrom10ToN(newBase, number);
            
            Console.WriteLine(result);
        }

        public static string ConverFrom10ToN(BigInteger newBase, BigInteger number)
        {
            StringBuilder result = new StringBuilder();

            if (number == 0)
            {
                result.Append(number);
            }

            while (number > 0)
            {
                result.Append(number % newBase);
                number /= newBase;
            }

            char[] array = result.ToString().ToCharArray();
            Array.Reverse(array);

            return String.Join("",array);
        }
    }
}