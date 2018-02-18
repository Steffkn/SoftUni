using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var carDictionary = new Dictionary<string, Car>();

        for (int i = 0; i < n; i++)
        {
            var tockens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var carModel = tockens[0];
            var fuelAmoun = decimal.Parse(tockens[1]);
            var fuelConsumptionPerKm = decimal.Parse(tockens[2]);

            if (!carDictionary.ContainsKey(carModel))
            {
                carDictionary.Add(carModel, new Car(carModel, fuelAmoun, fuelConsumptionPerKm));
            }
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var commandArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = commandArgs[0];
            var carModel = commandArgs[1];
            var amountKm = decimal.Parse(commandArgs[2]);

            if (!carDictionary[carModel].Drive(amountKm))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        foreach (var car in carDictionary)
        {
            Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:f2} {car.Value.DistanceTraveled}");
        }
    }
}
