namespace _08.OddEvenSum
{
    using System;

    public class OddEvenSum
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int eveSum = 0;
            int oddSum = 0;

            for (int i = 1; i <= N; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    eveSum += input;
                }
                else
                {
                    oddSum += input;
                }
            }

            if (eveSum == oddSum)
            {
                Console.WriteLine("yes sum " + eveSum);
            }
            else
            {
                Console.WriteLine("no diff " + Math.Abs(eveSum - oddSum));
            }
        }
    }
}
