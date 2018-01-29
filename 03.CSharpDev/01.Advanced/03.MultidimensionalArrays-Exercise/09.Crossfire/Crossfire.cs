
using System.Linq;
using System.Text;

namespace _09.Crossfire
{
    using System;

    public class Crossfire
    {
        static void Main()
        {
            int[] dimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = InitMatrix(dimentions[0], dimentions[1]);
            string input = Console.ReadLine();
            while (!input.Equals("Nuke it from orbit"))
            {
                int[] shotParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                CleanMatrix(matrix, shotParams[0], shotParams[1], shotParams[2]);
                input = Console.ReadLine();
            }
            PrintMatrix(matrix);
        }

        private static void CleanMatrix(int[,] matrix, int row, int col, int radius)
        {
            for (int i = col + 1; i < matrix.GetLength(1); i++)
            {
                matrix[row, i] = 0;
                if (col + radius == i)
                {
                    break;
                }
            }
            for (int i = col; i >= 0; i--)
            {
                matrix[row, i] = 0;
                if (col - radius == i)
                {
                    break;
                }
            }
            for (int i = row + 1; i < matrix.GetLength(0); i++)
            {
                matrix[i, col] = 0;
                if (row + radius == i)
                {
                    break;
                }
            }
            for (int i = row; i >= 0; i--)
            {
                matrix[i, col] = 0;
                if (row - radius == i)
                {
                    break;
                }
            }
        }

        private static int[,] InitMatrix(int x, int y)
        {
            var result = new int[x, y];
            int count = 1;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++, count++)
                {
                    result[i, j] = count;
                }
            }

            return result;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        sb.AppendFormat("{0} ", matrix[i, j]);
                    }
                }
                if (matrix[i, matrix.GetLength(1) - 1] != 0)
                {
                    sb.AppendLine(matrix[i, matrix.GetLength(1) - 1].ToString());
                }
            }

            Console.WriteLine(sb);
        }
    }
}
