namespace _04.EvenPowersOf2
{
    using System;

    public class EvenPowersOf2
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var powerOf2 = 1;
            Console.WriteLine(powerOf2);
            for (int i = 1; i < N; i += 2)
            {
                powerOf2 *= 4;
                Console.WriteLine(powerOf2);
            }
        }
    }
}
