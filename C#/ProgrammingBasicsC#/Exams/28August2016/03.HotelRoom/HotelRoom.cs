namespace _03.HotelRoom
{
    using System;

    public class HotelRoom
    {
        static void Main()
        {
            string month = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());


            decimal studioCost = 0m;
            decimal apartmentCost = 0m;

            switch (month)
            {
                case "May":
                case "October":

                    studioCost = days * 50m;
                    apartmentCost = days * 65m;
                    if (days > 14)
                    {
                        studioCost = studioCost - (studioCost * 30) / 100;
                    }
                    else if (days > 7)
                    {
                        studioCost = studioCost - (studioCost * 5) / 100;
                    }
                    break;
                case "June":
                case "September":
                    studioCost = days * 75.20m;
                    apartmentCost = days * 68.70m;

                    if (days > 14)
                    {
                        studioCost = studioCost - (studioCost * 20) / 100;
                    }
                    break;
                case "July":
                case "August":
                    studioCost = days * 76m;
                    apartmentCost = days * 77m;
                    break;
                default:
                    break;
            }

            if (days > 14)
            {
                apartmentCost = apartmentCost * 0.9m;
            }

            Console.WriteLine(string.Format("Apartment: {0:F2} lv.", apartmentCost));
            Console.WriteLine(string.Format("Studio: {0:F2} lv.", studioCost));
        }
    }
}