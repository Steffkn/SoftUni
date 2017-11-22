namespace _02.InchesToCentimeters
{
    using System;

    public class InchesToCentimeters
    {
        static void Main()
        {
            Console.Write("inches = ");
            var inches = double.Parse(Console.ReadLine());
            var cm = inches * 2.54;

            Console.WriteLine(string.Format("Centimeters = {0}", cm));
        }
    }
}
