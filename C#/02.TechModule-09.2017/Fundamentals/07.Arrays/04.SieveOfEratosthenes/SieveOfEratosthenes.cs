namespace _04.SieveOfEratosthenes
{
    using System;
    using System.Text;

    public class SieveOfEratosthenes
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n + 1];

            bool[] isPrime = new bool[n + 1];

            for (int i = 2; i < isPrime.Length; i++)
            {
                isPrime[i] = true;
            }

            isPrime[0] = false;
            isPrime[1] = false;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    result.AppendFormat("{0} ", i);
                    MarkAsNotPrime(isPrime, i);
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static void MarkAsNotPrime(bool[] isPrime, int index)
        {
            for (int i = 2 * index; i < isPrime.Length; i = i + index)
            {
                isPrime[i] = false;
            }
        }
    }
}
