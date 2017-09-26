namespace _19.TileRepair
{
    using System;

    public class TileRepair
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var W = double.Parse(Console.ReadLine());
            var L = double.Parse(Console.ReadLine());
            var M = int.Parse(Console.ReadLine());
            var O = int.Parse(Console.ReadLine());

            double tileSquareArea = N * N;
            double singleTileArea = W * L;
            double benchArea = M * O;

            var numberOfTiles = (tileSquareArea - benchArea) / singleTileArea;
            var totalTime = numberOfTiles * 0.2;
            Console.WriteLine(string.Format("{0:F2}", Math.Round(numberOfTiles, 2)));
            Console.WriteLine(string.Format("{0:F2}", Math.Round(totalTime, 2)));
        }
    }
}
