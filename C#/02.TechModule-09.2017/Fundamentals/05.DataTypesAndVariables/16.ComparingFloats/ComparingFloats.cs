namespace _16.ComparingFloats
{
    using System;

    public class ComparingFloats
    {
        static void Main()
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());
            double eps = 0.000001;

            if (Math.Abs(numberB - numberA) <= eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
