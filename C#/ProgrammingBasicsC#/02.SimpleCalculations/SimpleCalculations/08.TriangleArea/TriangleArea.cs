namespace _08.TriangleArea
{
    using System;

    public class TriangleArea
    {
        static void Main()
        {
            var a = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());
            var area = a * h / 2;

            Console.WriteLine("Triangle area = " + Math.Round(area, 2));
        }
    }
}
