namespace _03.EqualSums
{
    using System;
    using System.IO;
    using System.Linq;

    public class EqualSums
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
                        writer.WriteLine(possition);
                    }
                    else
                    {
                        writer.WriteLine("no");
                    }
                }
            }
        }
    }
}