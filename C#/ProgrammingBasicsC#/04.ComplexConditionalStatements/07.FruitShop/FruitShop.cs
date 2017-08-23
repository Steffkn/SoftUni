namespace _07.FruitShop
{
    using System;

    public class FruitShop
    {
        static void Main()
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            var amount = double.Parse(Console.ReadLine());
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana")
                {
                    Console.WriteLine(amount * 2.50);
                }
                else if (fruit == "apple")
                {
                    Console.WriteLine(amount * 1.20);
                }
                else if (fruit == "orange")
                {
                    Console.WriteLine(amount * 0.85);
                }
                else if (fruit == "grapefruit")
                {
                    Console.WriteLine(amount * 1.45);
                }
                else if (fruit == "kiwi")
                {
                    Console.WriteLine(amount * 2.70);
                }
                else if (fruit == "pineapple")
                {
                    Console.WriteLine(amount * 5.50);
                }
                else if (fruit == "grapes")
                {
                    Console.WriteLine(amount * 3.85);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {

                if (fruit == "banana")
                {
                    Console.WriteLine(amount * 2.70);
                }
                else if (fruit == "apple")
                {
                    Console.WriteLine(amount * 1.25);
                }
                else if (fruit == "orange")
                {
                    Console.WriteLine(amount * 0.90);
                }
                else if (fruit == "grapefruit")
                {
                    Console.WriteLine(amount * 1.60);
                }
                else if (fruit == "kiwi")
                {
                    Console.WriteLine(amount * 3.00);
                }
                else if (fruit == "pineapple")
                {
                    Console.WriteLine(amount * 5.60);
                }
                else if (fruit == "grapes")
                {
                    Console.WriteLine(amount * 4.20);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
