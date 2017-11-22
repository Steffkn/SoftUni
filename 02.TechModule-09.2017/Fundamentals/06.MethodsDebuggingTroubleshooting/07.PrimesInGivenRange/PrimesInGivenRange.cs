
namespace _07.PrimesInGivenRange
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    public class PrimesInGivenRange
    {
        static void Main()
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            var listOfNumbers = new List<int>();

            if (startNum < 2)
            {
                startNum = 2;
            }

            listOfNumbers = FindPrimesInRange(startNum, endNum);

            PrintList(listOfNumbers);
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

        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            var listOfPrimes = new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                {
                    listOfPrimes.Add(i);
                }
            }
            return listOfPrimes;
        }

        static void PrintList(List<int> list)
        {
            StringBuilder sb = new StringBuilder();

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    sb.AppendFormat($"{list[i]}, ");
                }

                sb.Append(list[list.Count - 1]);

                Console.WriteLine(sb.ToString());
            }
        }
    }
}
