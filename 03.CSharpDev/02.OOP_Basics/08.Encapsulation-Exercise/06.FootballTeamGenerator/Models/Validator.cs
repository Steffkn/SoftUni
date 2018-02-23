using System;
using System.Collections.Generic;

public static class Validator
{
    private const int MIN_STAT_VALUE = 0;
    private const int MAX_STAT_VALUE = 100;

    public static void ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name.Trim()))
        {
            throw new ArgumentException("A name should not be empty");
        }
    }

    public static void ValidateStat(string name, int stat)
    {
        if (stat < MIN_STAT_VALUE || stat > MAX_STAT_VALUE)
        {
            throw new ArgumentException($"{name} should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
        }
    }

    public static void ValidateTeamNameExists(string teamName, Dictionary<string, Team> teams)
    {
        if (!teams.ContainsKey(teamName))
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }
    }
    public static void ValidatePlayerExists(string teamName, string playerName, Team team)
    {
        if (!team.HasPlayer(playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
        }
    }
}

