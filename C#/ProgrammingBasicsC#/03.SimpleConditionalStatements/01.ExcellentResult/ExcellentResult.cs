namespace _01.ExcellentResult
{
    using System;

    public class ExcellentResult
    {
        static void Main()
        {
            var grade = double.Parse(Console.ReadLine());
            if (grade >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
