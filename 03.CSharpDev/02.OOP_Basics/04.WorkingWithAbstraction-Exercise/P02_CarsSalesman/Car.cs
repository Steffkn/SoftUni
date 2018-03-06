using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }

    public Engine Engine { get; set; }

    public int? Weight { get; set; }

    public string Color { get; set; }

    public Car(string model, Engine engine, int? weight = null, string color = "n/a")
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Model}:");
        sb.AppendLine($"  {this.Engine}");
        sb.Append("  Weight: ");
        if (this.Weight == null)
        {
            sb.AppendLine("n/a");
        }
        else
        {
            sb.AppendLine(this.Weight.ToString());
        }

        sb.Append($"  Color: {this.Color}");

        return sb.ToString();
    }
}
