namespace _07.MaxSequenceIncreasingElements
{
    using System;
    using System.Linq;
    using System.Text;

    public class MaxSequenceIncreasingElements
    {
        static void Main()
        {
            long[] array = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            int possition = 0;
            int bestStart = 0;
            int bestLenght = 1;
            int counter = 1;

            long prevNumber = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                // 3 2 3 4 2 2 4
                if (prevNumber < array[i])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                    possition = i;
                }

                if (counter > bestLenght)
                {
                    bestLenght = counter;
                    bestStart = possition;
                }

                prevNumber = array[i];
            }


            StringBuilder sb = new StringBuilder();

            for (int i = bestStart; i < bestStart + bestLenght; i++)
            {
                sb.AppendFormat($"{array[i]} ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}