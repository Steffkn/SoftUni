namespace _06.PointOnRectangleBorder
{
    using System;

    public class PointOnRectangleBorder
    {
        static void Main()
        {
            var x1 = decimal.Parse(Console.ReadLine());
            var y1 = decimal.Parse(Console.ReadLine());
            var x2 = decimal.Parse(Console.ReadLine());
            var y2 = decimal.Parse(Console.ReadLine());
            var x = decimal.Parse(Console.ReadLine());
            var y = decimal.Parse(Console.ReadLine());

            if (x1 == x || x2 == x)
            {
                if (y >= y1 && y <= y2)
                {
                    Console.WriteLine("Border");
                }
                else
                {
                    Console.WriteLine("Inside / Outside");
                }
            }
            else if (y1 == y || y2 == y)
            {
                if (x >= x1 && x <= x2)
                {
                    Console.WriteLine("Border");
                }
                else
                {
                    Console.WriteLine("Inside / Outside");
                }
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}
