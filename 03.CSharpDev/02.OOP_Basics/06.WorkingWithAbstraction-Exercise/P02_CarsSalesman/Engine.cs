using System.Text;

public class Engine
{
    public string Model { get; set; }

    public int Power { get; set; }

    public int? Displacement { get; set; }

    public string Efficiency { get; set; }

    public Engine(string model, int power, int? displacement = null, string efficiency = "n/a")
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Model}:");
        sb.AppendLine($"  Power: {this.Power}");
        sb.Append("    Displacement: ");
        if (this.Displacement == null)
        {
            sb.AppendLine("n/a");
        }
        else
        {
            sb.AppendLine($"{this.Displacement}");
        }

        sb.Append($"    Efficiency: {this.Efficiency}");

        return sb.ToString();
    }
}
