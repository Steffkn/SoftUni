namespace _09.TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TeamworkProjects
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var teams = new Dictionary<string, Team>();

            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine().Split('-');
                var creatorName = inputs[0];
                var teamName = inputs[1];

                if (teams.Values.FirstOrDefault(x => x.Name == teamName) != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else
                {
                    if (!teams.ContainsKey(creatorName))
                    {
                        teams.Add(creatorName, new Team(teamName));
                        Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                    }
                    else
                    {
                        Console.WriteLine($"{creatorName} cannot create another team!");
                    }
                }
            }

            var input = Console.ReadLine();

            while (input != "end of assignment")
            {
                var args = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var user = args[0];
                var teamName = args[1];

                var team = teams.Values.FirstOrDefault(t => t.Name == teamName);

                if (team != null)
                {
                    if (!teams.ContainsKey(user))
                    {
                        bool canJoin = true;
                        foreach (var item in teams.Values)
                        {
                            if (item.Users.Contains(user))
                            {
                                canJoin = false;
                            }
                        }

                        if (canJoin)
                        {
                            team.Users.Add(user);
                        }
                        else
                        {
                            Console.WriteLine($"Member {user} cannot join team {teamName}!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }

                input = Console.ReadLine();
            }

            foreach (var validTeam in teams
                .Where(t => t.Value.Users.Count > 0)
                .OrderByDescending(x => x.Value.Users.Count)
                .ThenBy(x => x.Value.Name))
            {
                Console.WriteLine($"{validTeam.Value.Name}");
                Console.WriteLine($"- {validTeam.Key}");
                foreach (var member in validTeam.Value.Users.OrderBy(u => u))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var invalidTeams in teams.Where(t => t.Value.Users.Count == 0).OrderBy(x => x.Value.Name))
            {
                Console.WriteLine($"{invalidTeams.Value.Name}");
            }

        }

    }

    public class Team
    {
        private string name;
        private List<string> users = new List<string>();

        public Team(string name)
        {
            this.Name = name;
        }

        public string Name { get => name; set => name = value; }
        public List<string> Users { get => users; set => users = value; }
    }
}