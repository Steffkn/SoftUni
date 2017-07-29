namespace _09.CelsiusToFahrenheit
{
    using System;

    public class CelsiusToFahrenheit
    {
        static void Main()
        {
            var C = double.Parse(Console.ReadLine());
            var F = C * 1.8 + 32;

            Console.WriteLine(F);
        }
    }
}