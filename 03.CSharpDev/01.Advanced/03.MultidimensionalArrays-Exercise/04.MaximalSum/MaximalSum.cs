namespace _04.MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        static void Main()
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[dimentions[0], dimentions[1]];
            int maxSum = int.MinValue;
            int sum = 0;
            int xPos = 0;
            int yPos = 0;

            for (int i = 0; i < dimentions[0]; i++)
            {
                var row = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < dimentions[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }


            for (int i = 0; i < dimentions[0] - 2; i++)
            {
                for (int j = 0; j < dimentions[1] - 2; j++)
                {
                    sum = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            sum += matrix[i + k, j + l];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        xPos = i;
                        yPos = j;
                    }
                }
            }

            Console.WriteLine("Sum = {0}", maxSum);

            for (int i = xPos; i < xPos + 3; i++)
            {
                for (int j = yPos; j < yPos + 2; j++)
                {

                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.Write(matrix[i, yPos + 2]);
                Console.WriteLine();
            }
        }
    }
}
