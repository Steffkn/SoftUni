namespace _02.Scholarship
{
    using System;

    public class Scholarship
    {
        static void Main()
        {
            var income = double.Parse(Console.ReadLine());
            var grade = double.Parse(Console.ReadLine());
            var minLev = double.Parse(Console.ReadLine());

            var socialScolarship = minLev * 0.35;
            double excelentScolarship = 0;

            if (grade >= 5.50)
            {
                excelentScolarship = grade * 25;
                if (income < minLev && socialScolarship > excelentScolarship)
                {
                    Console.WriteLine(string.Format("You get a Social scholarship {0} BGN", (int)socialScolarship));
                    return;
                }
                Console.WriteLine(string.Format("You get a scholarship for excellent results {0} BGN", (int)excelentScolarship));
            }
            else if (grade >= 4.5 && income < minLev)
            {
                Console.WriteLine(string.Format("You get a Social scholarship {0} BGN", (int)socialScolarship));
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
