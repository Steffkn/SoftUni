namespace _04.HotelTest
{
    using System;

    public class HotelTest
    {
        static void Main()
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            double studioPricePerNight = 0;
            double doublePricePerNight = 0;
            double suitePricePerNight = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studioPricePerNight = 50;
                    doublePricePerNight = 65;
                    suitePricePerNight = 75;
                    if (nightsCount > 7)
                    {
                        studioPricePerNight = studioPricePerNight * 0.95;
                    }
                    break;
                case "June":
                case "September":
                    studioPricePerNight = 60;
                    doublePricePerNight = 72;
                    suitePricePerNight = 82;
                    if (nightsCount > 14)
                    {
                        doublePricePerNight = doublePricePerNight * 0.90;
                    }
                    break;
                case "July":
                case "August":
                case "December":
                    studioPricePerNight = 68;
                    doublePricePerNight = 77;
                    suitePricePerNight = 89;

                    if (nightsCount > 14)
                    {
                        suitePricePerNight = suitePricePerNight * 0.85;
                    }
                    break;
                default:
                    throw new Exception();
            }

            double totalStudioCost = studioPricePerNight * nightsCount;
            double totalDoubleCost = doublePricePerNight * nightsCount;
            double totalSuiteCost = suitePricePerNight * nightsCount;

            if (month.ToLower() == "september" || month.ToLower() == "october")
            {
                if (nightsCount > 7)
                {
                    totalStudioCost = studioPricePerNight * (nightsCount - 1);
                }
            }

            Console.WriteLine(string.Format("Studio: {0:F2} lv.", totalStudioCost));
            Console.WriteLine(string.Format("Double: {0:F2} lv.", totalDoubleCost));
            Console.WriteLine(string.Format("Suite: {0:F2} lv.", totalSuiteCost));
        }
    }
}