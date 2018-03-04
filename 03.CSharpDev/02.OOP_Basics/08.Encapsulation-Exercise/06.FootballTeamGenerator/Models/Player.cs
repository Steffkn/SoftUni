using System.Collections.Generic;
using System.Linq;

public class Player
{
    private readonly IReadOnlyDictionary<string, int> stats;

    private string name;

    public IReadOnlyDictionary<string, int> Stats
    {
        get { return this.stats.ToDictionary(x => x.Key, v => v.Value); }
    }

    public string Name
    {
        get => this.name;
        set
        {
            Validator.ValidateName(value);
            this.name = value;
        }
    }

    public Player(string name, int[] stats)
    {
        this.Name = name;
        this.stats = AddStatsToPlayer(stats);
    }

    private IReadOnlyDictionary<string, int> AddStatsToPlayer(int[] statsToAdd)
    {
        var dict = new Dictionary<string, int>
        {
            ["Endurance"] = statsToAdd[0],
            ["Sprint"] = statsToAdd[1],
            ["Dribble"] = statsToAdd[2],
            ["Passing"] = statsToAdd[3],
            ["Shooting"] = statsToAdd[4],
        };

        foreach (var kvp in dict)
        {
            Validator.ValidateStat(kvp.Key, kvp.Value);
        }

        return dict;
    }
}
