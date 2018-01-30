namespace _09.Crossfire
{
    using System;
    using System.Linq;

    public class Crossfire
    {
        static void Main()
        {
            int[] dimentions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = InitMatrix(dimentions[0], dimentions[1]);
            string input = Console.ReadLine();

            while (!input.Equals("Nuke it from orbit"))
            {
                var shotParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int hitRow = int.Parse(shotParams[0]);
                int hitCol = int.Parse(shotParams[1]);
                int hitWave = int.Parse(shotParams[2]);
                matrix = HitMatrix(matrix, hitRow, hitCol, hitWave);
                input = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        private static int[][] HitMatrix(int[][] matrix, int hitRow, int hitCol, int hitWave)
        {
            //Destroy part of the column
            for (int row = hitRow - hitWave; row <= hitRow + hitWave; row++)
            {
                if (IsInMatrix(matrix, row, hitCol))
                {
                    matrix[row][hitCol] = -1;
                }
            }

            //Destroy part of the row
            for (int col = hitCol - hitWave; col <= hitCol + hitWave; col++)
            {
                if (IsInMatrix(matrix, hitRow, col))
                {
                    matrix[hitRow][col] = -1;
                }
            }

            return Clear(matrix);
        }

        private static bool IsInMatrix(int[][] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }

        private static int[][] Clear(int[][] matrix)
        {
            //Remove destroyed cells
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                //Remove destroyed cells if they is ones
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    if (matrix[rows][cols] < 0)
                    {
                        matrix[rows] = matrix[rows].Where(n => n > 0).ToArray();
                    }
                }

                //Remove empty rows
                if (matrix[rows].Length < 1)
                {
                    matrix = matrix.Take(rows).Concat(matrix.Skip(rows + 1)).ToArray();
                    rows--;
                }
            }
            return matrix;
        }

        private static int[][] InitMatrix(int x, int y)
        {
            var result = new int[x][];
            int count = 1;
            for (int i = 0; i < x; i++)
            {
                result[i] = new int[y];
                for (int j = 0; j < y; j++, count++)
                {
                    result[i][j] = count;
                }
            }

            return result;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i].Where(c => c != -1)));
            }
        }
    }
}
