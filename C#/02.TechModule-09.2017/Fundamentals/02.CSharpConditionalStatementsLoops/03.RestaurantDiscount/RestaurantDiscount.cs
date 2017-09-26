namespace _03.RestaurantDiscount
{
    using System;

    public class RestaurantDiscount
    {
        static void Main()
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            string hallName = string.Empty;
            double price = 0.0;

            if (groupSize <= 50)
            {
                price = 2500;
                hallName = "Small Hall";
            }
            else if (groupSize <= 100)
            {
                price = 5000;
                hallName = "Terrace";
            }
            else if (groupSize <= 120)
            {
                price = 7500;
                hallName = "Great Hall";
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            switch (package)
            {
                case "Normal":
                    price += 500;
                    price = price * 0.95;
                    break;
                case "Gold":
                    price += 750;
                    price = price * 0.90;
                    break;
                case "Platinum":
                    price += 1000;
                    price = price * 0.85;
                    break;
                default:
                    break;
            }

            double pricePerPerson = price / groupSize;
            Console.WriteLine($"We can offer you the {hallName}");
            Console.WriteLine($"The price per person is {pricePerPerson:F2}$");
        }
    }
}