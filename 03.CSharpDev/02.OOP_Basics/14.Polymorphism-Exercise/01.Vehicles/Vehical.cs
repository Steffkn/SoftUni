public class Vehical : IVehical
{
    public double FuelQuantity { get; set; }

    public double LitersPerKm { get; set; }

    public double AirConditionersFuelConsumption { get; }

    public double MaxDistance => this.FuelQuantity / (this.LitersPerKm + this.AirConditionersFuelConsumption);

    public Vehical(double fuelQuantity, double litersPerKm, double airConditionersFuelConsumption = 0.9)
    {
        this.FuelQuantity = fuelQuantity;
        this.LitersPerKm = litersPerKm;
        this.AirConditionersFuelConsumption = airConditionersFuelConsumption;
    }

    public virtual string Drive(double km)
    {
        if (this.MaxDistance >= km)
        {
            this.FuelQuantity -= (km * (this.LitersPerKm + this.AirConditionersFuelConsumption));
            return $"{this.GetType()} travelled {km} km";
        }

        return $"{this.GetType()} needs refueling";
    }

    public virtual void Refuel(double liters)
    {
        this.FuelQuantity += liters;
    }
}
