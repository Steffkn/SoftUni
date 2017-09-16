namespace _07.GreatestCommonDivisor_CGD_
{
    using System;

    public class GreatestCommonDivisor
    {
        static void Main()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            Console.WriteLine(a);
        }
    }
}
