namespace _01.MostFrequentNumber
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MostFrequentNumber
    {
        public const string inputFilePath = "input.txt";
        public const string outputFilePath = "output.txt";

        static void Main()
        {
            string[] input;
            using (StreamWriter writer = File.CreateText(outputFilePath))
            {
                input = File.ReadAllLines(inputFilePath);

                foreach (var line in input)
                {
                    int[] array = line
                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray();

                    int mostFrequentNumber = 0;
                    int mostFrequentCount = 0;

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

                    writer.WriteLine(mostFrequentNumber);
                }
            }

        }
    }
}