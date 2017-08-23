namespace _02.SmallShop
{
    using System;

    public class SmallShop
    {
        static void Main()
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            var amount = double.Parse(Console.ReadLine());

            if (city == "Sofia")
            {
                if (product == "coffee")
                {
                    Console.WriteLine(amount * 0.5);
                }
                else if (product == "water")
                {
                    Console.WriteLine(amount * 0.8);
                }
                else if (product == "beer")
                {
                    Console.WriteLine(amount * 1.2);
                }
                else if (product == "sweets")
                {
                    Console.WriteLine(amount * 1.45);
                }
                else if (product == "peanuts")
                {
                    Console.WriteLine(amount * 1.60);
                }
            }
            else if (city == "Plovdiv")
            {
                if (product == "coffee")
                {
                    Console.WriteLine(amount * 0.4);
                }
                else if (product == "water")
                {
                    Console.WriteLine(amount * 0.7);
                }
                else if (product == "beer")
                {
                    Console.WriteLine(amount * 1.15);
                }
                else if (product == "sweets")
                {
                    Console.WriteLine(amount * 1.30);
                }
                else if (product == "peanuts")
                {
                    Console.WriteLine(amount * 1.5);
                }
            }
            else if (city == "Varna")
            {
                if (product == "coffee")
                {
                    Console.WriteLine(amount * 0.45);
                }
                else if (product == "water")
                {
                    Console.WriteLine(amount * 0.7);
                }
                else if (product == "beer")
                {
                    Console.WriteLine(amount * 1.10);
                }
                else if (product == "sweets")
                {
                    Console.WriteLine(amount * 1.35);
                }
                else if (product == "peanuts")
                {
                    Console.WriteLine(amount * 1.55);
                }
            }
        }
    }
}
