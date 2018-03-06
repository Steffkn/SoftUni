using System;

public class Sneaking
{
    private static int sX = -1;
    private static int sY = 0;
    private static int nX = -1;
    private static int nY = 0;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var matrix = new char[n][];
        string input = string.Empty;

        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            if (sX == -1 && input.Contains("S"))
            {
                sX = i;
                sY = input.IndexOf('S'); ;
            }

            if (nX == -1 && input.Contains("N"))
            {
                nX = i;
                nY = input.IndexOf('N'); ;
            }

            matrix[i] = input.ToCharArray();
        }

        var moves = Console.ReadLine();
        foreach (char t in moves)
        {
            MoveBadGuys(matrix);
            if (IsDead(matrix))
            {
                matrix[sX][sY] = 'X';
                Console.WriteLine($"Sam died at {sX}, {sY}");
                break;
            }

            MoveSam(matrix, t);

            if (nX == sX)
            {
                matrix[nX][nY] = 'X';
                Console.WriteLine("Nikoladze killed!");
                break;
            }
        }

        PrintMatric(matrix);
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
}