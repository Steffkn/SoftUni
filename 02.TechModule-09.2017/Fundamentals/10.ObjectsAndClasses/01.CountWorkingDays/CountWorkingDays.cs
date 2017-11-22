namespace _01.CountWorkingDays
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class CountWorkingDays
    {
        static void Main()
        {
            string format = "dd-MM-yyyy";

            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture);
            int workDays = 0;

            List<DateTime> holidays = new List<DateTime>()
            {
                new DateTime(1970, 1, 1),
                new DateTime(1970, 3, 3),
                new DateTime(1970, 5, 1),
                new DateTime(1970, 5, 6),
                new DateTime(1970, 5, 24),
                new DateTime(1970, 9, 6),
                new DateTime(1970, 9, 22),
                new DateTime(1970, 10, 1),
                new DateTime(1970, 12, 24),
                new DateTime(1970, 12, 25),
                new DateTime(1970, 12, 26),
            };

            bool isHoliday = false;
            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    isHoliday = false;
                    foreach (var date in holidays)
                    {
                        if (date.Month == currentDate.Month && date.Day == currentDate.Day)
                        {
                            isHoliday = true;
                            break;
                        }
                    }

                    if (!isHoliday)
                    {
                        workDays++;
                    }
                }
            }

            Console.WriteLine(workDays);
        }
    }
}