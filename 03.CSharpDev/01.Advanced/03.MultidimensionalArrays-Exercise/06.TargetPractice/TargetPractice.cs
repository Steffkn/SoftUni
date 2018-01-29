using System.Linq;

namespace _06.TargetPractice
{
    using System;

    public class TargetPractice
    {
        static void Main()
        {
            int[] dimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int[] shotParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = FillMatrix(dimentions[0], dimentions[1], snake);
            Boom(matrix, shotParams[0], shotParams[1], shotParams[2]);
            MoveDownElements(matrix);
            PrintMatrix(matrix);
        }

        private static void MoveDownElements(char[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                {
                    if (matrix[i, j] == ' ')
                    {
                        for (int k = i; k >= 0; k--)
                        {
                            if (matrix[k, j] != ' ')
                            {
                                matrix[i, j] = matrix[k, j];
                                matrix[k, j] = ' ';
                                i--;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private static void Boom(char[,] matrix, int x, int y, int radius)
        {
            int c = radius * radius;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int a = Math.Abs(i - x);
                    int b = Math.Abs(j - y);
                    if (a * a + b * b <= c)
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] FillMatrix(int x, int y, string snake)
        {
            var result = new char[x, y];
            bool isLeft = true;
            int count = 0;
            for (int i = x - 1; i >= 0; i--)
            {
                if (isLeft)
                {
                    for (int j = y - 1; j >= 0; j--, count++)
                    {
                        result[i, j] = snake[count % snake.Length];
                    }
                }
                else
                {
                    for (int j = 0; j < y; j++, count++)
                    {
                        result[i, j] = snake[count % snake.Length];
                    }
                }

                isLeft = !isLeft;
            }

            return result;
        }
    }
}
