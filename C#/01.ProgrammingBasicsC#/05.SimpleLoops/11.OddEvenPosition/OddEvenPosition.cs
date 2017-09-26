namespace _11.OddEvenPosition
{
    using System;

    public class OddEvenPosition
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            double evenSum = 0.0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;
            double oddSum = 0.0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;

            for (int i = 1; i <= N; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += input;
                    if (evenMin > input)
                    {
                        evenMin = input;
                    }
                    if (evenMax < input)
                    {
                        evenMax = input;
                    }
                }
                else
                {
                    oddSum += input;

                    if (oddMin > input)
                    {
                        oddMin = input;
                    }
                    if (oddMax < input)
                    {
                        oddMax = input;
                    }
                }
            }

            if (N == 0)
            {
                Console.WriteLine("OddSum=" + oddSum);
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");

                Console.WriteLine("EvenSum=" + evenSum);
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else if (N < 2)
            {
                Console.WriteLine("OddSum=" + oddSum);
                Console.WriteLine("OddMin=" + oddMin + ",");
                Console.WriteLine("OddMax=" + oddMax + ",");

                Console.WriteLine("EvenSum=" + evenSum);
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine("OddSum=" + oddSum);
                Console.WriteLine("OddMin=" + oddMin + ",");
                Console.WriteLine("OddMax=" + oddMax + ",");

                Console.WriteLine("EvenSum=" + evenSum);
                Console.WriteLine("EvenMin=" + evenMin + ",");
                Console.WriteLine("EvenMax=" + evenMax + ",");
            }
        }
    }
}
