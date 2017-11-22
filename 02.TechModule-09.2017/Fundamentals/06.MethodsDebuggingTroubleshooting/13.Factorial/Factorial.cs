namespace _13.Factorial
{
    using System;
    using System.Numerics;

    public class Factorial
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = new BigInteger();

            factorial = GetFactorialOfN(n);

            Console.WriteLine(factorial);
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
