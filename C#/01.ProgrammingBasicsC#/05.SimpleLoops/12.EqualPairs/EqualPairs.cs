namespace _12.EqualPairs
{
    using System;

    public class EqualPairs
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int pairA = 0;
            int pairB = 0;
            int pairMaxDiff = 0;
            bool allAreEqual = true;

            pairA = int.Parse(Console.ReadLine());
            pairB = int.Parse(Console.ReadLine());
            int pairSum = pairA + pairB;
            int prevSum = 0;

            //pairMaxDiff = Math.Abs(prevSum - pairSum);

            for (int i = 2; i < 2 * N; i = i + 2)
            {
                prevSum = pairSum;
                pairA = int.Parse(Console.ReadLine());
                pairB = int.Parse(Console.ReadLine());
                pairSum = pairA + pairB;

                int nextDiff = Math.Abs(prevSum - pairSum);

                if (pairMaxDiff < nextDiff)
                {
                    pairMaxDiff = nextDiff;
                    allAreEqual = false;
                }
            }

            if (allAreEqual)
            {
                Console.WriteLine("Yes, value=" + pairSum);
            }
            else
            {
                Console.WriteLine("No, maxdiff=" + pairMaxDiff);
            }
        }
    }
}
