
namespace _19.TheaThePhotographer
{
    using System;

    public class TheaThePhotographer
    {
        static void Main()
        {
            int numberOfPics = int.Parse(Console.ReadLine());
            int filterTimePerPicture = int.Parse(Console.ReadLine());
            int goodPicturesPercent = int.Parse(Console.ReadLine());
            int uploadTimePerPicture = int.Parse(Console.ReadLine());

            int pictures = Convert.ToInt32(Math.Ceiling(numberOfPics * goodPicturesPercent/100.0));

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
