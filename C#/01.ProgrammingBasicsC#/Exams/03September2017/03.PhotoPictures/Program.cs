namespace _03.PhotoPictures
{
    using System;

    public class Program
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            string picType = Console.ReadLine();
            string orderType = Console.ReadLine();

            double price = 0.0;

            switch (picType)
            {
                case "9X13":
                    price = N * 0.16;
                    if (N >= 50)
                    {
                        price = price * 0.95;
                    }
                    break;
                case "10X15":
                    price = N * 0.16;
                    if (N >= 80)
                    {
                        price = price * 0.97;
                    }
                    break;
                case "13X18":
                    price = N * 0.38;
                    if (N > 100)
                    {
                        price = price * 0.95;
                    }
                    else if (N >= 50)
                    {
                        price = price * 0.97;
                    }
                    break;
                case "20X30":
                    price = N * 2.90;
                    if (N > 50)
                    {
                        price = price * 0.91;
                    }
                    else if (N >= 10)
                    {
                        price = price * 0.93;
                    }
                    break;
                default:
                    break;
            }


            if (orderType.Equals("online"))
            {
                price = price * 0.98;
            }
            Console.WriteLine(string.Format("{0:F2}BGN", price));
        }
    }
}
