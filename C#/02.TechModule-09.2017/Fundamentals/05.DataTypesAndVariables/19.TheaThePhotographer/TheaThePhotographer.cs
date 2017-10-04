
namespace _19.TheaThePhotographer
{
    using System;

    public class TheaThePhotographer
    {
        static void Main()
        {
            long numberOfPics = long.Parse(Console.ReadLine());
            long filterTimePerPicture = long.Parse(Console.ReadLine());
            long goodPicturesPercent = long.Parse(Console.ReadLine());
            long uploadTimePerPicture = long.Parse(Console.ReadLine());

             
            long pictures = Convert.ToInt64(Math.Ceiling(numberOfPics * goodPicturesPercent/100.0));

            long totalSeconds = filterTimePerPicture * numberOfPics;
            totalSeconds += uploadTimePerPicture * pictures;

            long seconds = totalSeconds % 60;
            totalSeconds /= 60;
            long minuts = totalSeconds % 60;
            totalSeconds /= 60;
            long hours = totalSeconds % 24;
            totalSeconds /= 24;
            long days = totalSeconds;

            Console.WriteLine($"{days}:{hours:D2}:{minuts:D2}:{seconds:D2}");
        }
    }
}
