namespace _03.CameraView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CameraView
    {
        static void Main()
        {
            int[] values = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int m = values[0];
            int n = values[1];

            string panorama = Console.ReadLine();
            string patter = String.Format("{0}{1}{2}{3}{4}", @"[|][<].{", m, @"}(\w{0,", n, @"})");

            Regex reg = new Regex(patter);

            var results = reg.Matches(panorama).Cast<Match>().Select(a => a.Groups[1].Value).ToArray();

            Console.WriteLine(String.Join(", ", results));
        }
    }
}