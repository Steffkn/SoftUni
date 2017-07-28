namespace _10.RadiansToDegrees
{
    using System;

    public class RadiansToDegrees
    {
        static void Main()
        {
            var rad = double.Parse(Console.ReadLine());
            var gradus = (180 / Math.PI) * rad;
            Console.WriteLine(Math.Round(gradus));
        }
    }
}
