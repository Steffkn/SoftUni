namespace _14.IntToHexAndBin
{
    using System;

    public class IntToHexAndBin
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            string hexNumber = Convert.ToString(number, 16)
                .ToUpper();
            string binNumber = Convert.ToString(number, 2);

            Console.WriteLine($"{hexNumber}");
            Console.WriteLine($"{binNumber}");
        }
    }
}
