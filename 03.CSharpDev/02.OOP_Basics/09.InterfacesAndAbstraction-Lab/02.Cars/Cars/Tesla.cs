﻿public class Tesla : Car, IElectricCar
{
    public Tesla(string model, string color, int battery) : base(model, color)
    {
        this.Battery = battery;
    }

    public int Battery { get; private set; }

    protected override string GetCarInfo()
    {
        return base.GetCarInfo() + $" with {this.Battery} Batteries";
    }
}