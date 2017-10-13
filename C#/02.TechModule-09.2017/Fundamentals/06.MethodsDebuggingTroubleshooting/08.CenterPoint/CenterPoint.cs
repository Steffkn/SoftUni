namespace _08.CenterPoint
{
    using System;

    public class CenterPoint
    {
        static void Main()
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            PrintCenterPoint(x1, y1, x2, y2);
        }

        private static void PrintCenterPoint(double x1, double y1, double x2, double y2)
        {
            double v1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double v2 = Math.Sqrt(x2 * x2 + y2 * y2);

            if (v1 <= v2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}