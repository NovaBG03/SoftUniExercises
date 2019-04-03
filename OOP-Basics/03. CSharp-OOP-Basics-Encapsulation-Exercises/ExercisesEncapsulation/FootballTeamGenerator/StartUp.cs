using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    class StartUp
    {
        static List<Team> teams = new List<Team>();

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "END")
            {
                string teamName = input[1];

                if (input[0] == "Team")
                {
                    Team team = new Team(teamName);
                    teams.Add(team);
                }
                else if (input[0] == "Add")
                {
                    string playerName = input[2];
                    int endurance = int.Parse(input[3]);
                    int sprint = int.Parse(input[4]);
                    int dribble = int.Parse(input[5]);
                    int passing = int.Parse(input[6]);
                    int shooting = int.Parse(input[7]);
                    try
                    {
                        Team team = GetTeam(teamName);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        team.AddPlayer(player);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input[0] == "Remove")
                {
                    string playerName = input[2];
                    try
                    {
                        Team team = GetTeam(teamName);
                        team.RemovePlayer(playerName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input[0] == "Rating")
                {
                    try
                    {
                        Team team = GetTeam(teamName);
                        Console.WriteLine(team);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                    input = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }


            Console.ReadLine();
        }

        private static Team GetTeam(string name)
        {
            Team team = teams.FirstOrDefault(t => t.Name == name);
            if (team == null)
            {
                throw new Exception($"Team {name} does not exist.");
            }

            return team;
        }
    }
}
