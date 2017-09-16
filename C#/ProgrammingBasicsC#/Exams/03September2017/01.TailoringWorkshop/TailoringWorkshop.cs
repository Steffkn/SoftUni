namespace _01.TailoringWorkshop
{
    using System;
    public class TailoringWorkshop
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            double tableL = double.Parse(Console.ReadLine());
            double tableW = double.Parse(Console.ReadLine());

            double pocrivkaL = tableL + 0.6;
            double pocrivkaW = tableW + 0.6;

            double pocrivkaArea = N * pocrivkaL * pocrivkaW;
            double kareSide = tableL / 2.0;
            double kareArea = N *kareSide * kareSide;
            double costD = pocrivkaArea * 7 + kareArea * 9;
            double costBGN = costD * 1.85;

            Console.WriteLine(string.Format("{0:F2} USD", costD));
            Console.WriteLine(string.Format("{0:F2} BGN", costBGN));
        }
    }
}
