namespace _03.EvenOrOdd
{
    using System;

    public class EvenOrOdd
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
