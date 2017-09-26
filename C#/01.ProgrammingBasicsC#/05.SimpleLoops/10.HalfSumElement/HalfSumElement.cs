namespace _10.HalfSumElement
{
    using System;

    public class HalfSumElement
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int biggest = int.MinValue;
            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (input > biggest)
                {
                    biggest = input;
                }
                sum += input;
            }

            sum -= biggest;

            if (sum == biggest)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + sum);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + Math.Abs(sum - biggest));
            }
        }
    }
}
