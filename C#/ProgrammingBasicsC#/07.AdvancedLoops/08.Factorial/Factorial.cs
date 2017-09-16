namespace _08.Factorial
{
    using System;

    public class Factorial
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            var nFact = 1;
            for (int i = 1; i <= N; i++)
            {
                nFact *= i;
            }

            Console.WriteLine(nFact);
        }
    }
}
