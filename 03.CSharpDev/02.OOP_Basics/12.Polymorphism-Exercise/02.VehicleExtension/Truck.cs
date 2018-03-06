using System;

public class Truck : Vehical
{
    public Truck(double fuelQuantity, double litersPerKm, double tankCapacity)
        : base(fuelQuantity, litersPerKm, tankCapacity, 1.6)
    { }

    public override void Refuel(double liters)
    {
        if (this.FuelQuantity + liters > this.TankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
        }
        else
        {
            base.Refuel(liters * 0.95);
        }
    }
}
