using System.Text;

public class Spy : Soldier, ISpy
{
    public Spy(string id, string firstName, string lastName, string codeNumber)
        : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public string CodeNumber { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Code Number: {this.CodeNumber}");
        return sb.ToString().TrimEnd();
    }
}