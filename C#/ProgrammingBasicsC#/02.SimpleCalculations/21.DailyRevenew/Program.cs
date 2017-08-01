namespace _21.DailyRevenew
{
    using System;

    public class Program
    {
        static void Main()
        {
            var workingDaysPerMonth = byte.Parse(Console.ReadLine());
            var moneyRevenewPerDay = decimal.Parse(Console.ReadLine());
            var DolarToBGN = decimal.Parse(Console.ReadLine());

            var moneyRevenewPerMonth = moneyRevenewPerDay * workingDaysPerMonth;
            var moneyRevenewPerYearInDolar = moneyRevenewPerMonth * 12 + moneyRevenewPerMonth * 2.5m;

            var pureMoneyRevenewPerYearInDolar = moneyRevenewPerYearInDolar - (moneyRevenewPerYearInDolar * 25) / 100;
            var pureMoneyRevenewPerYearInBGN = pureMoneyRevenewPerYearInDolar * DolarToBGN;

            var pureMoneyRevenewPerDay = pureMoneyRevenewPerYearInBGN / 365;

            Console.WriteLine(string.Format("{0:F2}", Math.Round(pureMoneyRevenewPerDay, 2)));
        }
    }
}
