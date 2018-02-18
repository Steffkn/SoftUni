using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    private const int MinimumEnginePower = 250;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var carDictionary = new Dictionary<string, Car>();
        // <Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> 
        // <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>
        for (int i = 0; i < n; i++)
        {
            var carArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var carModel = carArgs[0];
            var engine = new Engine(uint.Parse(carArgs[1]), uint.Parse(carArgs[2]));
            var cargo = new Cargo(uint.Parse(carArgs[3]), carArgs[4]);

            ICollection<Tire> tires = new List<Tire>(4)
            {
                new Tire(double.Parse(carArgs[5]), sbyte.Parse(carArgs[6])),
                new Tire(double.Parse(carArgs[7]), sbyte.Parse(carArgs[8])),
                new Tire(double.Parse(carArgs[9]), sbyte.Parse(carArgs[10])),
                new Tire(double.Parse(carArgs[11]), sbyte.Parse(carArgs[12])),
            };

            if (!carDictionary.ContainsKey(carModel))
            {
                carDictionary.Add(carModel, new Car(carModel, engine, cargo, tires));
            }
        }

        string command = Console.ReadLine();

        switch (command)
        {
            case "fragile":
                foreach (var car in carDictionary
                    .Where(c => c.Value.Cargo.CargoType == command)
                    .Where(c => c.Value.HasSoftTire()))
                {
                    Console.WriteLine(car.Value.Model);
                }
                break;
            case "flamable":
                foreach (var car in carDictionary
                    .Where(c => c.Value.Cargo.CargoType == command)
                    .Where(c => c.Value.Engine.EnginePower > MinimumEnginePower))
                {
                    Console.WriteLine(car.Value.Model);
                }
                break;
            default:
                break;
        }
    }
}
