namespace _11.ParkingSystem
{
    using System;
    using System.Linq;

    public class ParkingSystem
    {
        static void Main()
        {
            var dimentions = Console.ReadLine()
                .Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] parkingLot = new int[dimentions[0]][];

            // init the jagged array with low number of lements
            for (int i = 0; i < parkingLot.GetLength(0); i++)
            {
                parkingLot[i] = new int[1];
            }

            string input = Console.ReadLine();

            while (!input.Equals("stop"))
            {
                var tockens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int entryRow = int.Parse(tockens[0]);
                int cellRow = int.Parse(tockens[1]);
                int cellCol = int.Parse(tockens[2]);

                // expand the jagged array only if needed
                if (parkingLot[cellRow].Length < dimentions[1])
                {
                    parkingLot[cellRow] = new int[dimentions[1]];
                }
                int newCellCol = SearchForFreeSpot(parkingLot, cellRow, cellCol);
                if (newCellCol > 0)
                {
                    int stepsToSpot = MoveCarToSpot(entryRow, cellRow, newCellCol);
                    parkingLot[cellRow][newCellCol] = 1;
                    Console.WriteLine(stepsToSpot);
                }
                else
                {
                    Console.WriteLine("Row {0} full", cellRow);
                }

                input = Console.ReadLine();
            }
        }

        private static int SearchForFreeSpot(int[][] parkingLot, int cellRow, int cellCol)
        {
            for (int i = 0; i < parkingLot[cellRow].Length; i++)
            {
                if (cellCol - i > 0)
                {
                    if (parkingLot[cellRow][cellCol - i] == 0)
                    {
                        return cellCol - i;
                    }
                }
                if (cellCol + i < parkingLot[cellRow].Length)
                {
                    if (parkingLot[cellRow][cellCol + i] == 0)
                    {
                        return cellCol + i;
                    }
                }
            }

            return -1;
        }

        private static int MoveCarToSpot(int entryRow, int cellRow, int cellCol)
        {
            return Math.Abs(entryRow - cellRow) + cellCol + 1;
        }
    }
}
