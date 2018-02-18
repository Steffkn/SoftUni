using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        int engensCount = int.Parse(Console.ReadLine());
        var engines = new Dictionary<string, Engine>();
        var cars = new List<Car>();

        for (int i = 0; i < engensCount; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var engine = new Engine(input[0], int.Parse(input[1]));

            if (input.Length == 4)
            {
                engine.Displacement = int.Parse(input[2]);
                engine.Efficiency = input[3];
            }
            else if (input.Length == 3)
            {
                int displacement;
                if (int.TryParse(input[2], out displacement))
                {
                    engine.Displacement = int.Parse(input[2]);
                }
                else
                {
                    engine.Efficiency = input[2];
                }
            }

            if (!engines.ContainsKey(input[0]))
            {
                engines.Add(input[0], engine);
            }
        }

        int carsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsCount; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var carEngine = engines[input[1]];
            var newCar = new Car(input[0], new Engine(carEngine.Model, carEngine.Power, carEngine.Displacement, carEngine.Efficiency));

            if (input.Length == 4)
            {
                newCar.Weight = int.Parse(input[2]);
                newCar.Color = input[3];
            }
            else if (input.Length == 3)
            {
                int weight;
                if (int.TryParse(input[2], out weight))
                {
                    newCar.Weight = int.Parse(input[2]);
                }
                else
                {
                    newCar.Color = input[2];
                }
            }

            cars.Add(newCar);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}
