namespace FirstSteps
{
    using System;

    class SquareOfStars
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            string stars = string.Empty;

            for (int i = 1; i <= N; i++)
            {
                if (i == 1 || i == N)
                {
                    stars = new string('*', N);
                }
                else
                {
                    stars = string.Format("{0}{1}{2}", "*", new string(' ', N - 2), "*");
                }

                Console.WriteLine(stars);
            }
        }
    }
}