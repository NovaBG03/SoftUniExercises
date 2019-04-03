using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players = new List<Player>();
        private string name;

        public Team(string name)
        {
            this.Name = name;
        }

        private List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Rating
        {
            get { return CalculateRating(); }
        }


        private int CalculateRating()
        {
            if (Players.Count == 0)
            {
                return 0;
            }

            return (int)Math.Round(this.Players.Average(p => p.SkillLevel));
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = GetPlayer(playerName);
            if (player == null)
            {
                NoPlayerException(playerName);
            }

            this.Players.Remove(player);
        }

        private Player GetPlayer(string playerName)
        {
            return this.Players.FirstOrDefault(p => p.Name == playerName);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }

        private void NoPlayerException(string playerName)
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
    }
}
