namespace _01.SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        static void Main()
        {
            int[] dimentions = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[dimentions[0], dimentions[1]];
            long sum = 0;
            for (int i = 0; i < dimentions[0]; i++)
            {
                var row = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < dimentions[1]; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                    sum += matrix[i, j];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
