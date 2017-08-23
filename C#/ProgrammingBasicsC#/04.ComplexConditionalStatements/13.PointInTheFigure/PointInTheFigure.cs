namespace _13.PointInTheFigure
{
    using System;

    public class PointInTheFigure
    {
        static void Main()
        {
            int h = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if (x == 0 || x == 3 * h)
            {
                if (y >= 0 && y <= h)
                {
                    Console.WriteLine("border");
                }
                else
                {
                    Console.WriteLine("outside");
                }
            }
            else if (x == h || x == 2 * h)
            {
                if (y == 0 || y == 4 * h || (y >= h && y <= 4 * h))
                {
                    Console.WriteLine("border");
                }
                else if (y > 0 && y < h)
                {
                    Console.WriteLine("inside");
                }
                else
                {
                    Console.WriteLine("outside");
                }
            }
            else if (x > h && x < 2 * h)
            {
                if (y > 0 && y < 4 * h)
                {
                    Console.WriteLine("inside");
                }
                else if (y == 0 || y == 4 * h)
                {
                    Console.WriteLine("border");
                }
                else
                {
                    Console.WriteLine("outside");
                }
            }
            else if (x > 0 && x < 3 * h)
            {
                if (y > 0 && y < h)
                {
                    Console.WriteLine("inside");
                }
                else if (y == 0 || (y == h) && (x <= h || x >= 2 * h))
                {
                    Console.WriteLine("border");
                }
                else
                {
                    Console.WriteLine("outside");
                }
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}
