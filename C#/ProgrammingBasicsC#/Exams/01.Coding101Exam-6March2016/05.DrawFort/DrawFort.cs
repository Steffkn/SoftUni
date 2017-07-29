namespace _05.DrawFort
{
    using System;

    public class DrawFort
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            var top = string.Format("{0}{1}{2}", "/", new string('^', N / 2), "\\");
            var bottom = string.Format("{0}{1}{2}", "\\", new string('_', N / 2), "/");

            if (N > 4)
            {
                Console.WriteLine(string.Format("{0}{1}{2}", top, new string('_', (2 * N) - (N / 2) * 2 - 4), top));
                for (int i = 0; i < N - 3; i++)
                {
                    Console.WriteLine(string.Format("{0}{1}{2}", "|", new string(' ', 2 * N - 2), "|"));
                }

                Console.WriteLine(string.Format("{0}{1}{2}{3}{4}", "|", new string(' ', (N / 2) + 1), new string('_', (2 * N) - (N / 2) * 2 - 4), new string(' ', (N / 2) + 1), "|"));

                Console.WriteLine(string.Format("{0}{1}{2}", bottom, new string(' ', (2 * N) - (N / 2) * 2 - 4), bottom));
            }
            else
            {
                Console.WriteLine(string.Format("{0}{1}", top, top));

                for (int i = 0; i < N - 2; i++)
                {
                    Console.WriteLine(string.Format("{0}{1}{2}", "|", new string(' ', (N * 2) - 2), "|"));
                }

                Console.WriteLine(string.Format("{0}{1}", bottom, bottom));
            }
        }
    }
}
