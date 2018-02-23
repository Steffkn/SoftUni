using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string _name;

    public string Name
    {
        get => this._name;
        set
        {
            Validator.ValidateName(value);
            this._name = value;
        }
    }

    public double Rating => CalculateRating();

    private Dictionary<string, Player> Players { get; }

    public Team(string name)
    {
        this.Name = name;
        this.Players = new Dictionary<string, Player>();
    }

    public void AddPlayer(Player player)
    {
        this.Players.Add(player.Name, player);
    }

    public void RemovePlayer(string playerName)
    {
        this.Players.Remove(playerName);
    }
    public bool HasPlayer(string playerName)
    {
        return this.Players.ContainsKey(playerName);
    }

    private int CalculateRating()
    {
        double rating = 0;
        foreach (var player in this.Players)
        {
            rating += player.Value.Stats.Values.Sum();
        }

        rating /= 5;
        return (int)Math.Round(rating);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Rating}";
    }
}
