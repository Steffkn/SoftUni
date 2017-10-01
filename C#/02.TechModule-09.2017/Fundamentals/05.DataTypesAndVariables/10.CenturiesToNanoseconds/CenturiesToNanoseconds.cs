namespace _10.CenturiesToNanoseconds
{
    using System;
    using System.Numerics;

    public class CenturiesToNanoseconds
    {
        static void Main()
        {
            uint centuries = uint.Parse(Console.ReadLine());
            ulong years = centuries * 100;
            double days = Math.Floor(years * 365.2422);
            double hours = days * 24;
            double minutes = hours * 60;
            double seconds = minutes * 60;
            BigInteger milliseconds = (BigInteger)seconds * 1000;
            BigInteger microseconds = milliseconds * 1000;
            BigInteger nanoseconds = microseconds * 1000;

            Console.Write($"{centuries} centuries = ");
            Console.Write($"{years} years = ");
            Console.Write($"{days} days = ");
            Console.Write($"{hours} hours = ");
            Console.Write($"{minutes} minutes = ");
            Console.Write($"{seconds} seconds = ");
            Console.Write($"{milliseconds} milliseconds = ");
            Console.Write($"{microseconds} microseconds = ");
            Console.Write($"{nanoseconds} nanoseconds");
        }
    }
}
