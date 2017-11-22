namespace _11.EqualSums
{
    using System;
    using System.Linq;

    public class EqualSums
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int possition = 0;

            int leftIndex = 0;
            int rightIndex = array.Length - 1;

            long leftSum = array[leftIndex];
            long rightSum = array[rightIndex];
           
            while (leftIndex != rightIndex)
            {
                if (leftSum <= rightSum)
                {
                    leftIndex++;
                    leftSum += array[leftIndex];
                    possition = leftIndex;
                }
                else if (leftSum >= rightSum)
                {
                    rightIndex--;
                    rightSum += array[rightIndex];
                }
            }


            if (leftSum == rightSum)
            {
                Console.WriteLine(possition);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}