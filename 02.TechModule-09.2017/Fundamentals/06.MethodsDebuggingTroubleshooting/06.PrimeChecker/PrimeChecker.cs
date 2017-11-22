    using System;
    using System.Numerics;

    namespace _06.PrimeChecker
    {
        class PrimeChecker
        {
            static void Main()
            {
                BigInteger number = BigInteger.Parse(Console.ReadLine());

                if (number < 2)
                {
                    Console.WriteLine(false);
                    return;
                }
                else if (number == 2)
                {
                    Console.WriteLine(true);
                    return;
                }

                Console.WriteLine(IsPrime(number));
            }

        private static bool IsPrime(BigInteger number)
        {
            if (number == 2)
            {
                return true;
            }

            double interval = Math.Sqrt(double.Parse(number.ToString()));

            for (int i = 2; i <= interval; i++)
            {
                if (number % i == 0 || number.IsEven)
                {
                    return false;
                }
            }

            return true;
        }
    }
    }
