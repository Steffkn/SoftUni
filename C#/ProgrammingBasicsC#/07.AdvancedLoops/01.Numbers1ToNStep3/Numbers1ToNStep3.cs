namespace _01.Numbers1ToNStep3
{
    using System;

    public class Numbers1ToNStep3
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i += 3)
            {
                Console.WriteLine(i);
            }
        }

    }
}
