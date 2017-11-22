namespace _05.MaxSequenceEqualElements
{
    using System;
    using System.IO;
    using System.Linq;

    public class MaxSequenceEqualElements
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
                    var numbers = line
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

                    writer.WriteLine(result.TrimEnd());
                }
            }
        }
    }
}