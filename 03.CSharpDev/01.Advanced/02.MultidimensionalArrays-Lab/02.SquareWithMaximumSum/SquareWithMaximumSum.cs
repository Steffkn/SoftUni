namespace _02.SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        static void Main()
        {
            var dimentions = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = ReadMatrix(dimentions[0], dimentions[1]);
            int[] result = FindSquareWithMaxSum(matrix);

            Console.WriteLine("{0} {1}", matrix[result[0], result[1]], matrix[result[0], result[1] + 1]);
            Console.WriteLine("{0} {1}", matrix[result[0] + 1, result[1]], matrix[result[0] + 1, result[1] + 1]);
            Console.WriteLine(result[2]);
        }

        private static int[] FindSquareWithMaxSum(int[,] matrix)
        {
            int[] result = new int[3];
            int sum = 0;
            int maxSum = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    sum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (maxSum < sum)
                    {
                        result[0] = i;
                        result[1] = j;
                        maxSum = sum;
                        result[2] = sum;
                    }
                }
            }

            return result;
        }


        static int[,] ReadMatrix(int n, int m)
        {
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }

            return matrix;
        }
    }
}
