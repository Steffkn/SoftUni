using System.Collections.Generic;

public class Car
{
    public string Model { get; set; }

    public Engine Engine { get; set; }

    public Cargo Cargo { get; set; }

    public ICollection<Tire> Tires { get; set; }

    public Car(string model, Engine engine, Cargo cargo, ICollection<Tire> tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = tires;
    }

    public bool HasSoftTire()
    {
        foreach (var tire in Tires)
        {
            if (tire.Pressure < 1)
            {
                return true;
            }
        }

        return false;
    }
}
