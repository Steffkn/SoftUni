using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(string id, string firstName, string lastName, double salary, string corps, IEnumerable<Mission> missions)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public IEnumerable<Mission> Missions { get; }

    public void CompleteMission(string missionName)
    {
        foreach (var mission in Missions)
        {
            if (mission.Name.Equals(missionName))
            {
                mission.State = "Finished";
                break;
            }
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Missions:");
        foreach (var part in Missions)
        {
            sb.AppendLine(part.ToString());
        }

        return sb.ToString().TrimEnd();
    }

}
