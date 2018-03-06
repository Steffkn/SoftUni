using System.Collections.Generic;

public interface ICommando
{
    IEnumerable<Mission> Missions { get; }

    void CompleteMission(string missionName);
}