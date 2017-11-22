namespace _11.ConvertSpeedUnits
{
    using System;

    public class ConvertSpeedUnits
    {
        public const int METERS_TO_MILE = 1609;
        static void Main()
        {
            int distanceInMeters = int.Parse(Console.ReadLine());
            byte hours = Convert.ToByte(Console.ReadLine());
            byte minutes = Convert.ToByte(Console.ReadLine());
            byte seconds = Convert.ToByte(Console.ReadLine());

            int totalSeconds = (hours * 3600 + minutes * 60 + seconds);
            float totalHours = (hours + minutes / 60.0f + seconds / 3600.0f);

            float distanceInKm = distanceInMeters / 1000.0f;
            float distanceInMiles = distanceInMeters / (float)METERS_TO_MILE;

            float speedInMetersPerSecond = distanceInMeters / (float)totalSeconds;
            float speedInKmPerHour = distanceInKm / totalHours;
            float speedInMilePerHour = distanceInMiles / totalHours;

            Console.WriteLine(speedInMetersPerSecond);
            Console.WriteLine(speedInKmPerHour);
            Console.WriteLine(speedInMilePerHour);
        }
    }
}
