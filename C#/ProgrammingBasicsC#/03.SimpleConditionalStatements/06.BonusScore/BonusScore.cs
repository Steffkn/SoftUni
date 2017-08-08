namespace _06.BonusScore
{
    using System;

    public class BonusScore
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            double bonusPoints = 0;

            if (number <= 100)
            {
                bonusPoints += 5;
            }
            else if (number < 1000)
            {
                bonusPoints = number * 0.2;
            }
            else
            {
                bonusPoints = number * 0.1;
            }

            if (number % 2 == 0)
            {
                bonusPoints += 1;
            }
            else if (number % 5 == 0)
            {
                bonusPoints += 2;
            }

            Console.WriteLine(bonusPoints);
            Console.WriteLine(number + bonusPoints);
        }
    }
}
