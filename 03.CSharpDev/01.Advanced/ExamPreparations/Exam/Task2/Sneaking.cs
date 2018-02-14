using System;
using System.Collections.Generic;
using System.Linq;

public class Sneaking
{
    static int sX = -1;
    static int sY = 0;
    static int nX = -1;
    static int nY = 0;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var matrix = new char[n][]; //
        var pawns = new Dictionary<string, Pawn>();
        string input = Console.ReadLine();
        int m = input.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] != '.')
                {
                    if (input[j] == 'b')
                    {
                        pawns.Add($"{i}{j}", new Pawn('b', i, j));
                    }
                    else if (input[j] == 'd')
                    {
                        pawns.Add($"{i}{j}", new Pawn('d', i, j));
                    }
                    else if (input[j] == 'S')
                    {
                        pawns.Add("S", new Pawn('S', i, j));
                    }
                    else if (input[j] == 'N')
                    {
                        pawns.Add("N", new Pawn('N', i, j));
                    }
                }
            }

            input = Console.ReadLine();
        }

        PrintPawns(pawns, n, m);

        Console.WriteLine(input);

        for (int i = 0; i < input.Length; i++)
        {
            pawns = MovePawns(pawns, m);
            PrintPawns(pawns, n, m);
            Console.WriteLine();
            if (IsDead(pawns))
            {
                matrix[sX][sY] = 'X';
                Console.WriteLine($"Sam died at {sX}, {sY}");
                break;
            }
            /*
            MoveSam(matrix, moves[i]);

            if (nX == sX)
            {
                matrix[nX][nY] = 'X';
                Console.WriteLine("Nikoladze killed!");
                break;
            }*/
        }
        
        PrintPawns(pawns, n, m);
    }

    private static bool IsDead(Dictionary<string, Pawn> pawns)
    {
        var sPoint = pawns["S"];
        return pawns.Any(x => (x.Value.X == sPoint.X && (&& x.Value.Y < sPoint.Y)|| ( x.Value.Y > sPoint.Y));
    }

    private static Dictionary<string, Pawn> MovePawns(Dictionary<string, Pawn> pawns, int m)
    {
        foreach (var pawn in pawns)
        {
            if (pawn.Value.Symbol == 'b')
            {
                if (pawn.Value.Y == m - 1)
                {
                    pawn.Value.Symbol = 'd';
                }
                else
                {
                    pawn.Value.Y++;
                }
            }
            else if (pawn.Value.Symbol == 'd')
            {
                if (pawn.Value.Y == 0)
                {
                    pawn.Value.Symbol = 'b';
                }
                else
                {
                    pawn.Value.Y--;
                }
            }
        }

        return pawns;
    }

    private static void PrintPawns(Dictionary<string, Pawn> pawns, int n, int m)
    {
        var matrix = new char[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = '.';
            }
        }

        foreach (var pawn in pawns)
        {
            matrix[pawn.Value.X, pawn.Value.Y] = pawn.Value.Symbol;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }

    }

    private static bool IsDead(char[][] matrix)
    {
        for (int i = 0; i < sY; i++)
        {
            if (matrix[sX][i] == 'b')
            {
                return true;
            }
        }

        for (int i = sY; i < matrix[sX].Length; i++)
        {
            if (matrix[sX][i] == 'd')
            {
                return true;
            }
        }

        return false;
    }

    private static void MoveSam(char[][] matrix, char move)
    {
        switch (move)
        {
            case 'U':
                matrix[sX - 1][sY] = 'S';
                matrix[sX][sY] = '.';
                sX--;
                break;
            case 'D':
                matrix[sX + 1][sY] = 'S';
                matrix[sX][sY] = '.';
                sX++;
                break;
            case 'L':
                matrix[sX][sY - 1] = 'S';
                matrix[sX][sY] = '.';
                sY--;
                break;
            case 'R':
                matrix[sX][sY + 1] = 'S';
                matrix[sX][sY] = '.';
                sY++;
                break;
            default:
                break;
        }
    }

    private static void MoveBadGuys(char[][] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 'b')
                {
                    if (j == matrix[i].Length - 1)
                    {
                        matrix[i][j] = 'd';
                    }
                    else
                    {
                        matrix[i][j] = '.';
                        matrix[i][j + 1] = 'b';
                    }

                    break;
                }
                else if (matrix[i][j] == 'd')
                {
                    if (j == 0)
                    {
                        matrix[i][j] = 'b';
                    }
                    else
                    {
                        matrix[i][j] = '.';
                        matrix[i][j - 1] = 'd';
                    }

                    break;
                }
            }
        }
    }

    private static void PrintMatric(char[][] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.WriteLine(String.Join("", matrix[i]));
        }
    }

    private class Pawn
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }

        public Pawn(char symbol, int x, int y)
        {
            this.Symbol = symbol;
            this.X = x;
            this.Y = y;
        }
    }
}
