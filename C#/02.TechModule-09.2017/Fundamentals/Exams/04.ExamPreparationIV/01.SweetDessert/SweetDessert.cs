namespace _01.SweetDessert
{
    using System;

    public class SweetDessert
    {
        static void Main()
        {
            double money = double.Parse(Console.ReadLine());
            long guestNumber = long.Parse(Console.ReadLine());
            double bananaPrice = double.Parse(Console.ReadLine());
            double eggsPrice = double.Parse(Console.ReadLine());
            double berriesPrice = double.Parse(Console.ReadLine());

            double setOf6Price = 2 * bananaPrice + 4 * eggsPrice + 0.2 * berriesPrice;

            double numberOfPies = Math.Ceiling(guestNumber / 6.0);

            double totalPrice = numberOfPies * setOf6Price;

            if (money >= totalPrice)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                double moneyNeeded = totalPrice - money;
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {moneyNeeded:F2}lv more.");
            }
        }
    }
}
