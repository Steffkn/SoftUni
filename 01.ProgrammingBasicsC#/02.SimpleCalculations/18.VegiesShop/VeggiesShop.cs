namespace _18.VegiesShop
{
    using System;

    public class VeggiesShop
    {
        static void Main()
        {
            const decimal BGNtoEUR = 1.94m;

            var veggiesPrice = decimal.Parse(Console.ReadLine());
            var fruitPrice = decimal.Parse(Console.ReadLine());

            var veggiesAmount = int.Parse(Console.ReadLine());
            var fruitAmount = int.Parse(Console.ReadLine());

            decimal totalPrice = veggiesPrice * veggiesAmount + fruitPrice * fruitAmount;

            Console.WriteLine(string.Format("{0:F2}", Math.Round(totalPrice / BGNtoEUR, 3)));
        }
    }
}
