namespace _03.PowersOfTwo
{
    using System;

    public class PowersOfTwo
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            int num = 1;
            Console.WriteLine(num);
            for (int i = 1; i <= N; i++)
            {
                num = num * (2);
                Console.WriteLine(num);
            }
        }
    }
}
