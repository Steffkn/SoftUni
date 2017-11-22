namespace _01.MaxSequenceEqualElements
{
    using System;
    using System.Linq;

    public class MaxSequenceEqualElements
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int currentStart = 0;
            int currentLenght = 1;
            int bestLenght = 1;
            int bestStart = 0;

            int tempNumber = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if (tempNumber == numbers[i])
                {
                    currentLenght++;
                }
                else
                {
                    currentStart = i;
                    currentLenght = 1;
                }

                if (currentLenght > bestLenght)
                {
                    bestStart = currentStart;
                    bestLenght = currentLenght;
                }

                tempNumber = numbers[i];
            }

            string result = string.Empty;

            for (int i = bestStart; i < bestStart + bestLenght; i++)
            {
                result += (numbers[i] + " ");
            }

            Console.WriteLine(result.TrimEnd());
        }
    }
}