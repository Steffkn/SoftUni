namespace _07.MinNumber
{
    using System;

    public class MinNumber
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int smallest = int.MaxValue;

            for (int i = 0; i < N; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (input < smallest)
                {
                    smallest = input;
                }
            }

            Console.WriteLine(smallest);
        }
    }
}
