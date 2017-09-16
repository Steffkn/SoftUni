namespace _11.EnterEvenNumber
{
    using System;

    public class EnterEvenNumber
    {
        static void Main()
        {
            int N = 2;

            while (true)
            {
                try
                {
                    N = int.Parse(Console.ReadLine());
                    if (N % 2 == 0)
                    {
                        Console.WriteLine(N);
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number");
                }
            }
        }
    }
}
