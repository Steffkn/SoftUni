namespace _09.SumDigits
{
    using System;

    public class SumDigits
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var sum = 0;
            while (N > 0)
            {
                sum += N % 10;
                N = N / 10;
            }
            Console.WriteLine(sum);
        }
    }
}
