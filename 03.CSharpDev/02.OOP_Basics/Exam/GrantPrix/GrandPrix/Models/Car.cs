using System;

public class Car
{
    private const double maxFuel = 160;
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get => fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            this.fuelAmount = Math.Min(value, maxFuel);
        }
    }

    public Tyre Tyre { get; private set; }

    public void SetTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void Refuel(double amount)
    {
        this.FuelAmount += amount;
    }

    public void BurnFuel(double amount)
    {
        this.FuelAmount -= amount;
    }
}
