using System;

public abstract class Tyre
{
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name { get; }

    public double Hardness { get; }

    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public virtual void CompleteLap()
    {
        this.Degradation -= this.Hardness;
    }
}