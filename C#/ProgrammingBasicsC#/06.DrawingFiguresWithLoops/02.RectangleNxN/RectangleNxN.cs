namespace _02.RectangleNxN
{
    using System;

    public class RectangleNxN
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(new string('*', N));
            }
        }
    }
}
