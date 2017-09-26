namespace _10.TriangleOfNumbers
{
    using System;

    public class TriangleOfNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string result = string.Empty;
                for (int j = 1; j <= i; j++)
                {
                    result = result + i + " ";
                }
                Console.WriteLine(result.Trim());
            }
        }
    }
}