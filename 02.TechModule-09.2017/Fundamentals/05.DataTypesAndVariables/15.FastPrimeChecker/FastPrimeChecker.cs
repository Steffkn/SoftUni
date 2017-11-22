namespace _15.FastPrimeChecker
{
    using System;

    public class FastPrimeChecker
    {
        static void Main()
        {
            int maxNumber = int.Parse(Console.ReadLine());
            for (int number = 2; number <= maxNumber; number++)
            {
                bool isPrime = true;
                for (int devider = 2; devider <= Math.Sqrt(number); devider++)
                {
                    if (number % devider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine($"{number} -> {isPrime}");
            }
        }
    }
}
