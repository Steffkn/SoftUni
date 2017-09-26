namespace _06.IntervalOfNumbers
{
    using System;

    public class IntervalOfNumbers
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                // for fun
                a = a + b;
                b = a - b;
                a = a - b;
            }

            for (int i = a; i <= b; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}