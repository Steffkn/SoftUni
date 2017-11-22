namespace _11.GeometryCalculator
{
    using System;

    public class GeometryCalculator
    {
        static void Main()
        {
            string shapeType = Console.ReadLine();

            double a = 0;
            double b = 0;
            double result = 0;

            // triangle, square, rectangle and circle.

            switch (shapeType)
            {
                case "triangle":
                    a = double.Parse(Console.ReadLine());
                    b = double.Parse(Console.ReadLine());
                    result = a * b / 2;
                    break;
                case "square":
                    a = double.Parse(Console.ReadLine());
                    result = a * a;
                    break;
                case "rectangle":
                    a = double.Parse(Console.ReadLine());
                    b = double.Parse(Console.ReadLine());
                    result = a * b;
                    break;
                case "circle":
                    a = double.Parse(Console.ReadLine());
                    result = Math.PI * a * a;
                    break;
                default:
                    break;
            }

            Console.WriteLine("{0:F2}", result);
        }
    }
}
