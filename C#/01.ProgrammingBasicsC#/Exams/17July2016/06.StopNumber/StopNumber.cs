namespace _06.StopNumber
{
    using System;

    public class StopNumber
    {
        static void Main()
        {

            var N = int.Parse(Console.ReadLine());
            var M = int.Parse(Console.ReadLine());
            var S = int.Parse(Console.ReadLine());

            var index = 1;

            for (int i = M; i >= N; i = i - index)
            {
                if (i == S)
                {
                    break;
                }
                if (i % 6 == 0)
                {
                    Console.Write(i + " ");
                    index = 6;
                }
            }
        }
    }
}
