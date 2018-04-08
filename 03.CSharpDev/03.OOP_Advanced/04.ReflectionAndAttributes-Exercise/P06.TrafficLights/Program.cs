namespace P06.TrafficLights
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var lightsStrings = Console.ReadLine().Split(' ');
            var lights = new List<TraficLight>();
            foreach (string ligt in lightsStrings)
            {
                if (Enum.TryParse(ligt, out LightStates currentState))
                {
                    lights.Add(new TraficLight(currentState));
                }
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                foreach (var traficLight in lights)
                {
                    traficLight.Next();
                }

                Console.WriteLine(string.Join(" ", lights));
            }
        }
    }
}
