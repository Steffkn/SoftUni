namespace _03.EnduranceRally
{
    using System;
    using System.Linq;

    class EnduranceRally
    {
        static void Main()
        {
            var drivers = Console.ReadLine()
                .Split(' ')
                .Select(x => x.Trim())
                .ToList();

            var track = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var checkpoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            foreach (var driver in drivers)
            {
                var fuel = (double)driver[0];

                for (int i = 0; i < track.Length; i++)
                {
                    if (checkpoints.Contains(i))
                    {
                        fuel += track[i];
                    }
                    else
                    {
                        fuel -= track[i];
                    }

                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{driver} - reached {i}");
                        break;
                    }
                }

                if (fuel > 0)
                {
                    Console.WriteLine($"{driver} - fuel left {fuel:F2}");
                }
            }
        }
    }
}
