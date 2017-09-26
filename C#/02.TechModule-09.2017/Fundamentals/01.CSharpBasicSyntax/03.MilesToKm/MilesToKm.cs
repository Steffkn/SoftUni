namespace _03.MilesToKm
{
    using System;

    public class MilesToKm
    {
        const double MILE_TO_KM = 1.60934;

        static void Main()
        {
            double miles = double.Parse(Console.ReadLine());
            double km = miles * MILE_TO_KM;

            Console.WriteLine($"{km:F2}");
        }
    }
}