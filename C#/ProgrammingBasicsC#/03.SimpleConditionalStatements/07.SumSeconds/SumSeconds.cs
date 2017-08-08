namespace _07.SumSeconds
{
    using System;

    public class SumSeconds
    {
        static void Main()
        {
            var contender1 = int.Parse(Console.ReadLine());
            var contender2 = int.Parse(Console.ReadLine());
            var contender3 = int.Parse(Console.ReadLine());

            DateTime time = new DateTime();

            time = time.AddSeconds(contender1);
            time = time.AddSeconds(contender2);
            time = time.AddSeconds(contender3);

            Console.WriteLine(string.Format("{0}:{1:D2}",time.Minute, time.Second));
        }
    }
}
