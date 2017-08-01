namespace _20.Money
{
    using System;

    public class Program
    {
        const decimal BITCOIN_TO_BGN = 1168m;
        const decimal CHINESE_IOAN_TO_DOLAR = 0.15m;
        const decimal DOLAR_TO_BGN = 1.76m;
        const decimal EUR_TO_BGN = 1.95m;

        static void Main()
        {
            var bitcoinsAmount = int.Parse(Console.ReadLine());
            var chineseIoanAmount = decimal.Parse(Console.ReadLine());
            var poundage = int.Parse(Console.ReadLine());

            decimal moneyAmountInBGN = bitcoinsAmount * BITCOIN_TO_BGN + (chineseIoanAmount * CHINESE_IOAN_TO_DOLAR) * DOLAR_TO_BGN;
            decimal moneyAmountInEUR = moneyAmountInBGN / EUR_TO_BGN;
            decimal totalAmount = moneyAmountInEUR - (moneyAmountInEUR * 5) / 100;

            Console.WriteLine(string.Format("{0:F2}", Math.Round(totalAmount, 2)));
        }
    }
}
