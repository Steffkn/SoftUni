namespace _09.CountTheIntegers
{
    using System;

    public class CountTheIntegers
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int number = 0;
            int count = 0;
            while (int.TryParse(input, out number))
            {
                count++;
                input = Console.ReadLine();
            }

            Console.WriteLine(count);
        }
    }
}