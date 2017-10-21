namespace _03.CirclesIntersection
{
    using System;
    using System.Linq;

    public class CirclesIntersection
    {
        static void Main()
        {
            var circle1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var circle2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Circle c1 = new Circle(new Point(circle1[0], circle1[1]), circle1[2]);
            Circle c2 = new Circle(new Point(circle2[0], circle2[1]), circle2[2]);

            bool intersecting = Intersect(c1, c2);

            if (intersecting)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static bool Intersect(Circle c1, Circle c2)
        {
            var distance = Math.Sqrt(c1.Center.X * c1.Center.Y + c2.Center.X * c2.Center.Y);
            return distance <= c1.Radius + c2.Radius;
        }
    }

    public class Circle
    {
        public int Radius { get; set; }

        public Point Center { get; set; }

        public Circle(Point center, int radius)
        {
            this.Center = center;
            this.Radius = radius;
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}