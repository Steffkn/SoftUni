using System;
using System.Text;

public abstract class Harvester : Machine
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("", "OreOutput");
            }
            else
            {
                this.oreOutput = value;
            }
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("", "EnergyRequirement");
            }
            else
            {
                this.energyRequirement = value;
            }
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        string typeFull = this.GetType().Name;
        string type = typeFull.Substring(0, typeFull.IndexOf("Harvester"));

        sb.AppendLine($"{type} Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
        return sb.ToString().TrimEnd();
    }
}