namespace _06.Profit
{
    using System;

    public class Profit
    {
        static void Main()
        {
            var oneLv = int.Parse(Console.ReadLine());
            var twoLv = int.Parse(Console.ReadLine());
            var fiveLv = int.Parse(Console.ReadLine());
            var sum = int.Parse(Console.ReadLine());

            for (int i = 0; i <= oneLv; i++)
            {
                for (int j = 0; j <= twoLv; j++)
                {
                    for (int k = 0; k <= fiveLv; k++)
                    {
                        int tempSum = i * 1 + j * 2 + k * 5;

                        if (tempSum == sum)
                        {
                            Console.WriteLine(string.Format("{0} * 1 lv. + {1} * 2 lv. + {2} * 5 lv. = {3} lv.", i, j, k, tempSum));
                        }
                    }
                }
            }
        }
    }
}
