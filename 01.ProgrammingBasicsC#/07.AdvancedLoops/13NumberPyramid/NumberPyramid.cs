namespace _13.NumberPyramid
{
    using System;

    public class NumberPyramid
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 1, row = 1, count = 0; i <= N; i++)
            {
                Console.Write(string.Format("{0} ", i));
                count++;
                if (row == count)
                {
                    row += 1;
                    count = 0;
                    Console.WriteLine();
                }
            }
        }
    }
}
