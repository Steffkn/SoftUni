using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    // model, fuel amount, fuel consumption for 1 kilometer and distance traveled. 

    public string Model { get; set; }

    public decimal FuelAmount { get; set; }

    public decimal FuelConsumptionPerKm { get; set; }

    public decimal DistanceTraveled { get; set; }

    public Car(string model, decimal fuelAmount, decimal fuelConsumptionPerKm)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.DistanceTraveled = 0;
    }

    public bool Drive(decimal amountOfKm)
    {
        decimal fuelConsumed = amountOfKm * this.FuelConsumptionPerKm;
        if (fuelConsumed <= this.FuelAmount)
        {
            this.DistanceTraveled += amountOfKm;
            this.FuelAmount -= fuelConsumed;
            return true;
        }
        else
        {
            return false;
        }
    }
}
