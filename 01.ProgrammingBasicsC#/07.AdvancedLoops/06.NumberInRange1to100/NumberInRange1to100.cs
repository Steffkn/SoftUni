namespace _06.NumberInRange1to100
{
    using System;

    public class NumberInRange1to100
    {
        static void Main()
        {
            int N = 0;
            while (true)
            {
                N = int.Parse(Console.ReadLine());
                if (N > 0 && N <= 100)
                {
                    break;
                }
            }

            Console.WriteLine(N);
        }
    }
}
