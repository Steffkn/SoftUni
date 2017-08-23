namespace _04.SumNumbers
{
    using System;

    public class SumNumbers
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                sum += int.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}
