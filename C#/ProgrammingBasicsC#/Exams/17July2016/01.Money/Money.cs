namespace _01.Money
{
    using System;

    public class Money
    {
        const decimal BITCOIN_TO_BGN = 1168m;
        const decimal CHINESE_IOAN_TO_DOLAR = 0.15m;
        const decimal DOLAR_TO_BGN = 1.76m;
        const decimal EUR_TO_BGN = 1.95m;

        public static void Main()
        {
            var bitcoinsAmount = int.Parse(Console.ReadLine());
            var chineseIoanAmount = decimal.Parse(Console.ReadLine());
            decimal poundage = decimal.Parse(Console.ReadLine());

            decimal moneyAmountInBGN = bitcoinsAmount * BITCOIN_TO_BGN + (chineseIoanAmount * CHINESE_IOAN_TO_DOLAR) * DOLAR_TO_BGN;
            decimal moneyAmountInEUR = moneyAmountInBGN / EUR_TO_BGN;
            decimal totalAmount = moneyAmountInEUR - (moneyAmountInEUR * poundage) / 100;

            Console.WriteLine(string.Format("{0:F2}", totalAmount));
        }
    }
}
