namespace _05.RubiksMatrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class RubiksMatrix
    {
        static void Main()
        {
            int[] dimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] rubixsMatrix = InitMatrix(dimentions[0], dimentions[1]);

            int n = int.Parse(Console.ReadLine());

            for (int k = 0; k < n; k++)
            {
                var tockens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string cmd = tockens[1];
                int row = 0;
                int col = 0;
                int moves = 0;
                var que = new Queue<int>();
                switch (cmd)
                {
                    case "up":
                        // col
                        col = int.Parse(tockens[0]);
                        moves = int.Parse(tockens[2]) % rubixsMatrix.GetLength(0);
                        que = new Queue<int>();
                        for (int j = 0; j < rubixsMatrix.GetLength(0); j++)
                        {
                            que.Enqueue(rubixsMatrix[j, col]);
                        }

                        for (int i = 0; i < moves; i++)
                        {
                            que.Enqueue(que.Dequeue());
                        }

                        for (int j = 0; j < rubixsMatrix.GetLength(0); j++)
                        {
                            rubixsMatrix[j, col] = que.Dequeue();
                        }

                        break;
                    case "down":
                        // col
                        col = int.Parse(tockens[0]);
                        moves = int.Parse(tockens[2]) % rubixsMatrix.GetLength(0);
                        que = new Queue<int>();
                        for (int j = rubixsMatrix.GetLength(0) - 1; j >= 0; j--)
                        {
                            que.Enqueue(rubixsMatrix[j, col]);
                        }

                        for (int i = 0; i < moves; i++)
                        {
                            que.Enqueue(que.Dequeue());
                        }

                        for (int j = rubixsMatrix.GetLength(0) - 1; j >= 0; j--)
                        {
                            rubixsMatrix[j, col] = que.Dequeue();
                        }

                        break;
                    case "left":
                        // row
                        row = int.Parse(tockens[0]);
                        moves = int.Parse(tockens[2]) % rubixsMatrix.GetLength(1);
                        que = new Queue<int>();
                        for (int j = 0; j < rubixsMatrix.GetLength(1); j++)
                        {
                            que.Enqueue(rubixsMatrix[row, j]);
                        }

                        for (int i = 0; i < moves; i++)
                        {
                            que.Enqueue(que.Dequeue());
                        }

                        for (int j = 0; j < rubixsMatrix.GetLength(1); j++)
                        {
                            rubixsMatrix[row, j] = que.Dequeue();
                        }

                        break;
                    case "right":
                        // row
                        row = int.Parse(tockens[0]);
                        moves = int.Parse(tockens[2]) % rubixsMatrix.GetLength(1);
                        que = new Queue<int>();
                        for (int j = rubixsMatrix.GetLength(1) - 1; j >= 0; j--)
                        {
                            que.Enqueue(rubixsMatrix[row, j]);
                        }

                        for (int i = 0; i < moves; i++)
                        {
                            que.Enqueue(que.Dequeue());
                        }

                        for (int j = rubixsMatrix.GetLength(1) - 1; j >= 0; j--)
                        {
                            rubixsMatrix[row, j] = que.Dequeue();
                        }

                        break;
                }
            }

            ReverceRubixMatrix(rubixsMatrix);
        }

        private static void ReverceRubixMatrix(int[,] rubixsMatrix)
        {
            int count = 0;
            for (int i = 0; i < rubixsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < rubixsMatrix.GetLength(1); j++, count++)
                {
                    if (rubixsMatrix[i, j] == count)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        var found = GetValueCords(rubixsMatrix, i, j, count);
                        int temp = rubixsMatrix[i, j];
                        rubixsMatrix[i, j] = rubixsMatrix[found.Item1, found.Item2];
                        rubixsMatrix[found.Item1, found.Item2] = temp;
                        Console.WriteLine("Swap ({0}, {1}) with ({2}, {3})", i, j, found.Item1, found.Item2);
                    }
                }
            }
        }

        private static Tuple<int, int> GetValueCords(int[,] rubixsMatrix, int x, int y, int count)
        {
            for (int i = x; i < rubixsMatrix.GetLength(0); i++)
            {
                for (int j = y; j < rubixsMatrix.GetLength(1); j++)
                {
                    if (rubixsMatrix[i, j] == count)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
                y = 0;
            }

            return new Tuple<int, int>(-1, -1);
        }

        private static int[,] InitMatrix(int x, int y)
        {
            var result = new int[x, y];
            int count = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++, count++)
                {
                    result[i, j] = count;
                }
            }

            return result;
        }
    }
}
