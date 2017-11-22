namespace _04.BackToThePast
{
    using System;

    public class BackToThePast
    {
        static void Main()
        {
            var budged = double.Parse(Console.ReadLine());
            var yearsToStay = int.Parse(Console.ReadLine()) - 1800;

            for (int i = 0; i <= yearsToStay; i++)
            {
                if (i % 2 == 0)
                {
                    budged -= 12000;
                }
                else
                {
                    budged -= (12000 + 50 * (i + 18));
                }
            }

            if (budged >= 0)
            {
                Console.WriteLine(string.Format("Yes! He will live a carefree life and will have {0:F2} dollars left.", budged));
            }
            else
            {
                Console.WriteLine(string.Format("He will need {0:F2} dollars to survive.", budged * (-1)));
            }
        }
    }
}
