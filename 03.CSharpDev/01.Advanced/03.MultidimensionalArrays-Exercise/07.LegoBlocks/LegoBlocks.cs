using System.Linq;

namespace _07.LegoBlocks
{
    using System;

    class LegoBlocks
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[][] firstBlock = new int[n][];
            int[][] secondBlock = new int[n][];

            for (int i = 0; i < n; i++)
            {
                firstBlock[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            for (int i = 0; i < n; i++)
            {
                secondBlock[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
            }

            int firstRowLen = firstBlock[0].Length + secondBlock[0].Length;
            int totalSellsCount = firstRowLen;
            bool theyMatch = true;
            for (int i = 1; i < n; i++)
            {
                int currentRowLenght = firstBlock[i].Length + secondBlock[i].Length;
                totalSellsCount += currentRowLenght;
                if (currentRowLenght != firstRowLen)
                {
                    theyMatch = false;
                }
            }

            if (theyMatch)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write("[");
                    Console.Write(String.Join(", ", firstBlock[i]));
                    Console.Write(", ");
                    Console.Write(String.Join(", ", secondBlock[i]));
                    Console.WriteLine("]");
                }
            }
            else
            {
                Console.WriteLine("The total number of cells is: {0}", totalSellsCount);
            }
        }
    }
}
