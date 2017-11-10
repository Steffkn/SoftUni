namespace _01.SinoTheWalker
{
    using System;
    using System.Globalization;
    using System.Numerics;

    public class SinoTheWalker
    {
        static void Main()
        {
            string str = Console.ReadLine();
            var startTime = TimeSpan.ParseExact(str, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            int numberOfSteps =  int.Parse(Console.ReadLine());
            int timeForStep =  int.Parse(Console.ReadLine());

            long inputSeconds = startTime.Hours * 3600 + startTime.Minutes * 60 + startTime.Seconds;
            long totalSeconds = (long)numberOfSteps * timeForStep + inputSeconds;

            int seconds = (int)(totalSeconds % (60));
            totalSeconds /= 60;
            int minutes = (int)(totalSeconds % (60));
            totalSeconds /= 60;
            int hours = (int)(totalSeconds % (24));

            Console.WriteLine($"Time Arrival: {hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
