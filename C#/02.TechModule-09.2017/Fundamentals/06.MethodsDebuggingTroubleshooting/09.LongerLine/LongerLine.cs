namespace _09.LongerLine
{
    using System;

    public class LongerLine
    {
        static void Main()
        {
            var a1 = double.Parse(Console.ReadLine());
            var b1 = double.Parse(Console.ReadLine());
            var a2 = double.Parse(Console.ReadLine());
            var b2 = double.Parse(Console.ReadLine());
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            double ab = GetLineLenght(a1, b1, a2, b2);
            double xy = GetLineLenght(x1, y1, x2, y2);

            if (ab >= xy)
            {
                PrintCenterPoint(a1, b1, a2, b2);
            }
            else
            {
                PrintCenterPoint(x1, y1, x2, y2);
            }
        }

        private static double GetLineLenght(double a1, double b1, double a2, double b2)
        {
            double a = Math.Abs(a1 - a2);
            double b = Math.Abs(b1 - b2);
            double v = Math.Sqrt(a * a + b * b);

            return v;
        }

        private static void PrintCenterPoint(double x1, double y1, double x2, double y2)
        {
            double v1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double v2 = Math.Sqrt(x2 * x2 + y2 * y2);

            if (v1 <= v2)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }
    }
}
