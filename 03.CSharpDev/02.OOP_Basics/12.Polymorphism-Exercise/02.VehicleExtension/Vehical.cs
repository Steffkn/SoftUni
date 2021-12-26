using System;

public class Vehical : IVehical
{
    private double _fuelQuantity;

    public double FuelQuantity
    {
        get => this._fuelQuantity;
        set
        {
            if (value <= this.TankCapacity)
            {
                this._fuelQuantity = value;
            }
            else
            {
                this._fuelQuantity = 0;
            }
        }
    }

    public double LitersPerKm { get; set; }

    public double AirConditionersFuelConsumption { get; }

    public double MaxDistance => this.FuelQuantity / (this.LitersPerKm + this.AirConditionersFuelConsumption);

    public double TankCapacity { get; }

    public Vehical(double fuelQuantity, double litersPerKm, double tankCapacity, double airConditionersFuelConsumption = 0.9)
    {
        this.TankCapacity = tankCapacity;
        this.LitersPerKm = litersPerKm;
        this.AirConditionersFuelConsumption = airConditionersFuelConsumption;
        this.FuelQuantity = fuelQuantity;
    }

    public virtual string Drive(double km, bool isEmpty = false)
    {
        if (!isEmpty && this.FuelQuantity / (this.LitersPerKm + this.AirConditionersFuelConsumption) >= km)
        {
            this.FuelQuantity -= (km * (this.LitersPerKm + this.AirConditionersFuelConsumption));
            return $"{this.GetType()} travelled {km} km";
        }
        else if (isEmpty && this.FuelQuantity / (this.LitersPerKm) >= km)
        {
            this.FuelQuantity -= (km * this.LitersPerKm);
            return $"{this.GetType()} travelled {km} km";
        }

        return $"{this.GetType()} needs refueling";
    }

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if (this.FuelQuantity + liters > this.TankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
        }
        else
        {
            this.FuelQuantity += liters;
        }
    }
}
