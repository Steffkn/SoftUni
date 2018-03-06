using System;

public class Program
{
    static void Main()
    {
        var carArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var truckArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Car car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]));
        Truck truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]));

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var commandArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (commandArgs[1])
            {
                case "Car":
                    ExecuteCommand(commandArgs, car);
                    break;
                case "Truck":
                    ExecuteCommand(commandArgs, truck);
                    break;
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
    }

    private static void ExecuteCommand(string[] commandArgs, Vehical vehicle)
    {

        switch (commandArgs[0])
        {
            case "Drive":
                Console.WriteLine(vehicle.Drive(double.Parse(commandArgs[2])));
                break;
            case "Refuel":
                vehicle.Refuel(double.Parse(commandArgs[2]));
                break;
        }
    }
}
