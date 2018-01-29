namespace _04.PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[][] pascalTrienagle = GeneratePascalTriangle(n);

            for (int i = 0; i < pascalTrienagle.GetLength(0); i++)
            {
                for (int j = 1; j < pascalTrienagle[i].Length - 2; j++)
                {
                    Console.Write(pascalTrienagle[i][j] + " ");
                }
                Console.Write(pascalTrienagle[i][pascalTrienagle[i].Length - 2]);
                Console.WriteLine();
            }
        }

        private static long[][] GeneratePascalTriangle(int n)
        {
            long[][] pascalTrienagle = new long[n][];
            pascalTrienagle[0] = new long[] { 0, 1, 0 };

            for (int i = 0; i < n - 1; i++)
            {
                long[] nextRow = new long[pascalTrienagle[i].Length + 1];
                nextRow[0] = 0;
                for (int j = 1; j < nextRow.Length - 1; j++)
                {
                    nextRow[j] = pascalTrienagle[i][j - 1] + pascalTrienagle[i][j];
                }
                nextRow[nextRow.Length - 1] = 0;
                pascalTrienagle[i + 1] = nextRow;
            }

            return pascalTrienagle;
        }
    }
}
