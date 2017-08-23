namespace _11.Cinema
{
    using System;

    public class Cinema
    {
        static void Main()
        {
            string projType = Console.ReadLine();
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var amountOfSeats = rows * cols;

            switch (projType)
            {
                case "Premiere":
                    Console.WriteLine(string.Format("{0:F2}", amountOfSeats * 12.00));
                    break;
                case "Normal":
                    Console.WriteLine(string.Format("{0:F2}", amountOfSeats * 7.50));
                    break;
                case "Discount":
                    Console.WriteLine(string.Format("{0:F2}", amountOfSeats * 5.00));
                    break;
                default:
                    break;
            }
        }
    }
}
