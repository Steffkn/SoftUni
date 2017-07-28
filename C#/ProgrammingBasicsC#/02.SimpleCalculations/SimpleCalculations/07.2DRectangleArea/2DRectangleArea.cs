namespace _07._2DRectangleArea
{
    using System;

    public class Program
    {
        static void Main()
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            var a = Math.Abs(x1 - x2);
            var b = Math.Abs(y1 - y2);

            var area = a * b;
            var perimeter = 2 * (a + b);

            Console.WriteLine(area);
            Console.WriteLine(perimeter);
        }
    }
}
