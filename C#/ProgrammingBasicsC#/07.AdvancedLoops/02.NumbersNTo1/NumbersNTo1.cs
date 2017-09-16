namespace _02.NumbersNTo1
{
    using System;

    public class NumbersNTo1
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = N; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}