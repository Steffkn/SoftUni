using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(string id, string firstName, string lastName, double salary, IEnumerable<IPrivate> privates)
        : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public IEnumerable<IPrivate> Privates { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Privates:");

        foreach (var privateUnit in Privates)
        {
            sb.AppendLine(string.Format(" {0}", privateUnit.ToString()));
        }

        return sb.ToString().TrimEnd();
    }
}
