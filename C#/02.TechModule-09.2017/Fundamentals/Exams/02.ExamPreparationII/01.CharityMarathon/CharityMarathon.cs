namespace _01.CharityMarathon
{
    using System;

    class CharityMarathon
    {
        static void Main()
        {
            int maratonDays = int.Parse(Console.ReadLine());
            int numberOfRunners = int.Parse(Console.ReadLine());
            int avgNumberOfLapsPerRunner = int.Parse(Console.ReadLine());

            int trackLenght = int.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            decimal moneyPerKM = decimal.Parse(Console.ReadLine());

            int runnersThatWillRun = numberOfRunners;
            int maxCapacity = trackCapacity * maratonDays;
            if (maxCapacity < numberOfRunners)
            {
                runnersThatWillRun = maxCapacity;
            }

            decimal km = (long)runnersThatWillRun * trackLenght * avgNumberOfLapsPerRunner / 1000.0M;
            decimal money = km * moneyPerKM;

            Console.WriteLine($"Money raised: {money:F2}");
        }
    }
}
