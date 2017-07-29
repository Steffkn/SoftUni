namespace _04.Histogram
{
    using System;

    public class Histogram
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            double[] p = new double[5];

            for (int i = 0; i < N; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    p[0] += 1;
                }
                else if (number < 400)
                {
                    p[1] += 1;
                }
                else if (number < 600)
                {
                    p[2] += 1;
                }
                else if (number < 800)
                {
                    p[3] += 1;
                }
                else
                {
                    p[4] += 1;
                }
            }

            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine(string.Format("{0}%", Math.Round((p[i] / N) * 100, 2)));
            }

        }
    }
}
