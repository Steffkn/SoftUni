namespace _02.ChooseADrink2._0
{
    using System;

    public class ChooseADrink2
    {
        static void Main()
        {
            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;
            double totalPrice = 0;

            switch (profession)
            {
                case "Athlete":
                    price = 0.7;
                    break;
                case "Businessman":
                case "Businesswoman":
                    price = 1.0;
                    break;
                case "SoftUni Student":
                    price = 1.7;
                    break;
                default:
                    price = 1.2;
                    break;
            }

            totalPrice = quantity * price;
            Console.WriteLine($"The {profession} has to pay {totalPrice:F2}.");
        }
    }
}