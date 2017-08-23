namespace _12.Volleyball
{
    using System;

    public class Volleyball
    {
        static void Main()
        {
            string isLeapYear = Console.ReadLine();
            var p = int.Parse(Console.ReadLine());
            var h = int.Parse(Console.ReadLine());

            double playedTimes = 0.0;
            playedTimes += (48 - h) * 3 / 4.0;
            playedTimes += h;
            playedTimes += p * 2 / 3.0;

            if (isLeapYear == "leap")
            {
                playedTimes = playedTimes * 1.15;
            }

            Console.WriteLine((int)playedTimes);
        }
    }
}
