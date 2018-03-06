public class Truck : Vehical
{
    public Truck(double fuelQuantity, double litersPerKm)
        : base(fuelQuantity, litersPerKm, 1.6)
    { }

    public override void Refuel(double liters)
    {
        base.Refuel(liters * 0.95);
    }
}
