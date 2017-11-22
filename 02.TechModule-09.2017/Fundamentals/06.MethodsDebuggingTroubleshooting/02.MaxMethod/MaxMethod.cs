using System;

namespace _02.MaxMethod
{
    class MaxMethod
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int largest = GetMax(GetMax(a,b), c);

            Console.WriteLine(largest);
        }

        static int GetMax(int a, int b)
        {
            return a >= b ? a : b;
        }
    }
}
