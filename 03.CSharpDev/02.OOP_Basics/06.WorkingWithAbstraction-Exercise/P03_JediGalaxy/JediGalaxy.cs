using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class JediGalaxy
    {
        static void Main()
        {
            var dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = GetMatrix(dimestions[0], dimestions[1]);
            long sum = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                string[] possitionInput = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int playerX = int.Parse(possitionInput[0]);
                int playerY = int.Parse(possitionInput[1]);
                possitionInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int evilX = int.Parse(possitionInput[0]);
                int evilY = int.Parse(possitionInput[1]);
                DestroyCells(evilX, evilY, matrix);
                sum += GetSumOfDiagonal(playerX, playerY, matrix);
            }

            Console.WriteLine(sum);
        }

        private static long GetSumOfDiagonal(int x, int y, int[,] matrix)
        {
            long sum = 0;
            while (x >= 0 && y < matrix.GetLength(1))
            {
                if (IsInMatrix(x, y, matrix))
                {
                    sum += matrix[x, y];
                }
                y++;
                x--;
            }

            return sum;
        }

        private static void DestroyCells(int x, int y, int[,] matrix)
        {
            while (x >= 0 && y >= 0)
            {
                if (IsInMatrix(x, y, matrix))
                {
                    matrix[x, y] = 0;
                }
                x--;
                y--;
            }
        }

        private static bool IsInMatrix(int x, int y, int[,] matrix)
        {
            return x >= 0 && x < matrix.GetLength(0) &&
                   y >= 0 && y < matrix.GetLength(1);
        }

        private static int[,] GetMatrix(int x, int y)
        {
            int[,] matrix = new int[x, y];
            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            return matrix;
        }
    }
}
