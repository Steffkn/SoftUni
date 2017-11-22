namespace _07.LeftAndRightSum
{
    using System;

    public class LeftAndRightSum
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < N; i++)
            {
                int input = int.Parse(Console.ReadLine());
                leftSum += input;
            }

            for (int i = 0; i < N; i++)
            {
                int input = int.Parse(Console.ReadLine());
                rightSum += input;
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine("yes sum " + leftSum);
            }
            else
            {
                Console.WriteLine("no diff " + Math.Abs(leftSum - rightSum));
            }
        }
    }
}
