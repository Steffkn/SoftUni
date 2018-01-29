
using System.Collections.Generic;
using System.Linq;

namespace _08.RadioactiveBunnies
{
    using System;

    public class RadioactiveBunnies
    {
        static void Main()
        {
            int[] dimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[dimentions[0], dimentions[1]];
            int playerX = 0;
            int playerY = 0;
            var que = new Queue<Tuple<int, int>>();
            bool isAlive = true;
            bool isPlayerOut = false;
            for (int i = 0; i < dimentions[0]; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < dimentions[1]; j++)
                {
                    matrix[i, j] = row[j];
                    if (row[j] == 'P')
                    {
                        playerX = j;
                        playerY = i;
                    }
                    else if (row[j] == 'B')
                    {
                        que.Enqueue(new Tuple<int, int>(i, j));
                    }
                }
            }

            string moves = Console.ReadLine();

            for (int m = 0; m < moves.Length && isAlive; m++)
            {
                switch (moves[m])
                {
                    case 'L':
                        if (playerX - 1 > -1)
                        {
                            matrix[playerY, playerX] = '.';
                            playerX -= 1;

                            if (matrix[playerY, playerX] == 'B')
                            {
                                isAlive = false;
                            }
                            else
                            {
                                matrix[playerY, playerX] = 'P';
                            }
                        }
                        else
                        {
                            isPlayerOut = true;
                        }
                        break;
                    case 'R':
                        if (playerX + 1 < matrix.GetLength(1))
                        {
                            matrix[playerY, playerX] = '.';
                            playerX += 1;

                            if (matrix[playerY, playerX] == 'B')
                            {
                                isAlive = false;
                            }
                            else
                            {
                                matrix[playerY, playerX] = 'P';
                            }
                        }
                        else
                        {
                            isPlayerOut = true;
                        }
                        break;
                    case 'U':
                        if (playerY - 1 > -1)
                        {
                            matrix[playerY, playerX] = '.';
                            playerY -= 1;

                            if (matrix[playerY, playerX] == 'B')
                            {
                                isAlive = false;
                            }
                            else
                            {
                                matrix[playerY, playerX] = 'P';
                            }
                        }
                        else
                        {
                            isPlayerOut = true;
                        }
                        break;
                    case 'D':
                        if (playerY + 1 < matrix.GetLength(0))
                        {
                            matrix[playerY, playerX] = '.';
                            playerY += 1;

                            if (matrix[playerY, playerX] == 'B')
                            {
                                isAlive = false;
                            }
                            else
                            {
                                matrix[playerY, playerX] = 'P';
                            }
                        }
                        else
                        {
                            isPlayerOut = true;
                        }
                        break;
                }

                if (matrix[playerY, playerX] == 'B')
                {
                    isAlive = false;
                }

                int count = que.Count;
                for (int i = 0; i < count; i++)
                {
                    var current = que.Dequeue();
                    int math = current.Item1 - 1;
                    if (math > -1)
                    {
                        if (matrix[math, current.Item2] == 'P')
                        {
                            isAlive = false;
                            matrix[math, current.Item2] = 'B';
                        }
                        if (matrix[math, current.Item2] == '.')
                        {
                            que.Enqueue(new Tuple<int, int>(math, current.Item2));
                            matrix[math, current.Item2] = 'B';
                        }
                    }

                    math = current.Item1 + 1;
                    if (math < matrix.GetLength(0))
                    {
                        if (matrix[math, current.Item2] == 'P')
                        {
                            isAlive = false;
                            matrix[math, current.Item2] = 'B';
                        }
                        if (matrix[math, current.Item2] == '.')
                        {
                            que.Enqueue(new Tuple<int, int>(math, current.Item2));
                            matrix[math, current.Item2] = 'B';
                        }
                    }

                    math = current.Item2 - 1;
                    if (math > -1)
                    {
                        if (matrix[current.Item1, math] == 'P')
                        {
                            isAlive = false;
                            matrix[current.Item1, math] = 'B';
                        }
                        if (matrix[current.Item1, math] == '.')
                        {
                            que.Enqueue(new Tuple<int, int>(current.Item1, math));
                            matrix[current.Item1, math] = 'B';
                        }
                    }

                    math = current.Item2 + 1;
                    if (math < matrix.GetLength(1))
                    {
                        if (matrix[current.Item1, math] == 'P')
                        {
                            isAlive = false;
                            matrix[current.Item1, math] = 'B';
                        }
                        if (matrix[current.Item1, math] == '.')
                        {
                            que.Enqueue(new Tuple<int, int>(current.Item1, math));
                            matrix[current.Item1, math] = 'B';
                        }
                    }

                }
            }

            if (isPlayerOut)
            {
                matrix[playerY, playerX] = '.';
                PrintMatrix(matrix);
                Console.WriteLine("won: {0} {1}", playerY, playerX);
            }
            else
            {
                PrintMatrix(matrix);
                Console.WriteLine("dead: {0} {1}", playerY, playerX);
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
    }
}
