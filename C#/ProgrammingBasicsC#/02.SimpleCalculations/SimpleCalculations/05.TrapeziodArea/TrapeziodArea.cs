namespace _05.TrapeziodArea
{
    using System;

    public class TrapeziodArea
    {
        static void Main()
        {
            var b1 = double.Parse(Console.ReadLine());
            var b2 = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());
            double area = (b1 + b2) * h / 2;
            Console.WriteLine(string.Format("Trapezoid area = {0}", area));
        }
    }
}
