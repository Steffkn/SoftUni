using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName, double salary, string corps, IEnumerable<Part> parts)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Parts = parts;
    }

    public IEnumerable<Part> Parts { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Repairs:");
        foreach (var part in Parts)
        {
            sb.AppendLine(part.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}
