namespace _03.SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[dimentions[0], dimentions[1]];
            int count = 0;
            for (int i = 0; i < dimentions[0]; i++)
            {
                var row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < dimentions[1]; j++)
                {
                    matrix[i, j] = row[j][0];
                }
            }

            for (int i = 0; i < dimentions[0] - 1; i++)
            {
                for (int j = 0; j < dimentions[1] - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] &&
                        matrix[i, j] == matrix[i + 1, j] &&
                        matrix[i + 1, j] == matrix[i + 1, j + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
