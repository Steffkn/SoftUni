namespace _06.CircleAreaAndPerimeter
{
    using System;

    public class CircleAreaAndPerimeter
    {
        static void Main()
        {
            var r = double.Parse(Console.ReadLine());

            var area = Math.PI * r * r;
            var perimeter = 2 * Math.PI * r;

            Console.WriteLine("Area = " + area);
            Console.WriteLine("Perimeter = " + perimeter);
        }
    }
}
