namespace _12.CurrencyConverter
{
    using System;

    public class CurrencyConverter
    {
        static void Main()
        {
            double amount = double.Parse(Console.ReadLine());
            string from = Console.ReadLine();
            string to = Console.ReadLine();

            switch (from)
            {
                case "USD":
                    amount *= 1.79549;
                    break;
                case "EUR":
                    amount *= 1.95583;
                    break;
                case "GBP":
                    amount *= 2.53405;
                    break;
                default:
                    break;
            }

            switch (to)
            {
                case "USD":
                    amount /= 1.79549;
                    break;
                case "EUR":
                    amount /= 1.95583;
                    break;
                case "GBP":
                    amount /= 2.53405;
                    break;
                default:
                    break;
            }

            Console.WriteLine(Math.Round(amount,2));
        }
    }
}
