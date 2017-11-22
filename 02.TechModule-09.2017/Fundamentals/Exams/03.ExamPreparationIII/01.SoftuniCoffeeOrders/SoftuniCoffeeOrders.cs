namespace _01.SoftuniCoffeeOrders
{
    using System;
    using System.Globalization;

    public class SoftuniCoffeeOrders
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            decimal totalPrice = 0;

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                decimal capsulesCount = decimal.Parse(Console.ReadLine());
                var price = DateTime.DaysInMonth(date.Year, date.Month) * capsulesCount * pricePerCapsule;
                totalPrice += price;
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
