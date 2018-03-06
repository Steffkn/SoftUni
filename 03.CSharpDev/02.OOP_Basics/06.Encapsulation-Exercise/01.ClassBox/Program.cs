using System;

class Program
{
    static void Main()
    {
        var lenght = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        try
        {
            var box = new Box(lenght, width, height);

            // Task 1
            Console.WriteLine("Surface Area - {0:f2}", box.SurfaceArea());
            Console.WriteLine("Lateral Surface Area - {0:f2}", box.LateralSurfaceArea());
            Console.WriteLine("Volume - {0:f2}", box.Volume());
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

    }
}
