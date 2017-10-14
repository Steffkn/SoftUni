namespace _08.MostFrequentNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MostFrequentNumber
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int mostFrequentNumber = 0;
            int mostFrequentCount = 0;
            // 1 2 2 2 3 4 5 6 7 7 7 8 9
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            foreach (var number in array)
            {
                if (numbers.Keys.Contains(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }

                if (numbers[number] > mostFrequentCount)
                {
                    mostFrequentCount = numbers[number];
                    mostFrequentNumber = number;
                }
            }

            Console.WriteLine(mostFrequentNumber);
        }
    }
}