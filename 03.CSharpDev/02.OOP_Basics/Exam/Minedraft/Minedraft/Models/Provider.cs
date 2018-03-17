using System;
using System.Text;

public abstract class Provider : Machine
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value >= 0 && value < 10000)
            {
                energyOutput = value;
            }
            else
            {
                throw new ArgumentException("", "EnergyOutput");
            }
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        string typeFull = this.GetType().Name;
        string type = typeFull.Substring(0, typeFull.IndexOf("Provider"));
        
        sb.AppendLine($"{type} Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.EnergyOutput}");
        return sb.ToString().TrimEnd();
    }
}