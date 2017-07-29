namespace _03.OnTimeForTheExam
{
    using System;

    public class OnTimeForTheExam
    {
        static void Main()
        {
            int exameHour = int.Parse(Console.ReadLine());
            int exameMin = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMin = int.Parse(Console.ReadLine());

            DateTime exameTime = new DateTime(2017, 1, 1, exameHour, exameMin, 0, 0);
            DateTime arrivalTime = new DateTime(2017, 1, 1, arrivalHour, arrivalMin, 0, 0);

            var timeDiff = (exameTime - arrivalTime);

            if (timeDiff.Hours < 0 || timeDiff.Minutes < 0)
            {
                Console.WriteLine("Late");
                timeDiff = timeDiff.Duration();

                if (timeDiff.Hours > 0)
                {
                    Console.WriteLine("{0}:{1:00} hours after the start", timeDiff.Hours, timeDiff.Minutes);
                }
                else
                {
                    Console.WriteLine("{0} minutes after the start", timeDiff.Minutes);
                }
            }
            else if (timeDiff.Hours == 0 && timeDiff.Minutes <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine("{0} minutes before the start", timeDiff.Minutes);
            }
            else if (timeDiff.Hours == 0 && timeDiff.Minutes > 30)
            {
                Console.WriteLine("Early");
                Console.WriteLine("{0} minutes before the start", timeDiff.Minutes);
            }
            else if(timeDiff.Hours > 0)
            {
                Console.WriteLine("Early");
                Console.WriteLine("{0}:{1:00} hours before the start", timeDiff.Hours, timeDiff.Minutes);
            }
        }
    }
}
