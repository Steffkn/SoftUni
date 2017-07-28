namespace _11.USDToBGN
{
    using System;

    public class USDToBGN
    {
        const double change = 1.79549;

        static void Main()
        {
            var USD = double.Parse(Console.ReadLine());
            var BGN = USD * change;

            Console.WriteLine(Math.Round(BGN, 2));
        }
    }
}
