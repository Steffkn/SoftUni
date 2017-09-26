namespace _14.TimePlus15Minutes
{
    using System;

    public class TimePlus15Minutes
    {
        static void Main()
        {
            var hour = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());

            DateTime time = new DateTime();
            time = time.AddHours(hour);
            time = time.AddMinutes(minutes + 15);

            Console.WriteLine(string.Format("{0}:{1:D2}",time.Hour, time.Minute));
        }
    }
}
