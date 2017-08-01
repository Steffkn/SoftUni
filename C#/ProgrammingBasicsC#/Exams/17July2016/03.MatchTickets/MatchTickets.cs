namespace _03.MatchTickets
{
    using System;

    public class MatchTickets
    {
        static void Main()
        {
            var budged = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            var numberOfPeople = int.Parse(Console.ReadLine());

            if (numberOfPeople < 5)
            {
                budged -= budged * 0.75;
            }
            else if (numberOfPeople < 10)
            {
                budged -= budged * 0.6;
            }
            else if (numberOfPeople < 25)
            {
                budged -= budged * 0.5;
            }
            else if (numberOfPeople < 50)
            {
                budged -= budged * 0.4;
            }
            else
            {
                budged -= budged * 0.25;
            }

            switch (category)
            {
                case "VIP":
                    budged -= 499.99 * numberOfPeople;
                    break;
                case "Normal":
                    budged -= 249.99 * numberOfPeople;
                    break;
                default:
                    break;
            }

            if (budged >= 0)
            {
                Console.WriteLine(string.Format("Yes! You have {0:F2} leva left.", budged));
            }
            else
            {
                Console.WriteLine(string.Format("Not enough money! You need {0:F2} leva.", budged * (-1)));
            }
        }
    }
}
