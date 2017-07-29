namespace _02.TransportPrice
{
    using System;

    public class TransportPrice
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();

            double taksiPrice = 0.0;
            double bussPrice = double.MaxValue;
            double trainPrice = double.MaxValue;

            if (dayOrNight.Equals("day"))
            {
                taksiPrice = 0.7 + n * 0.79;
            }
            else
            {
                taksiPrice = 0.7 + n * 0.9;
            }

            if (n >= 20)
            {
                bussPrice = n * 0.09;
            }
            if (n >= 100)
            {
                trainPrice = n * 0.06;
            }
            Console.WriteLine(taksiPrice);
            Console.WriteLine(bussPrice);
            Console.WriteLine(trainPrice);
            Console.WriteLine(Math.Min(Math.Min(taksiPrice, bussPrice), trainPrice));
        }
    }
}
