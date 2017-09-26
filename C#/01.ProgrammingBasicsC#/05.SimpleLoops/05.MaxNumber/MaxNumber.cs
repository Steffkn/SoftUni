namespace _05.MaxNumber
{
    using System;

    public class MaxNumber
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int biggest = int.MinValue;

            for (int i = 0; i < N; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (input > biggest)
                {
                    biggest = input;
                }
            }

            Console.WriteLine(biggest);
        }
    }
}
