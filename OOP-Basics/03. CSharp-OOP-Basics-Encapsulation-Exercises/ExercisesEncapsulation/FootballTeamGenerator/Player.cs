using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Stat[] stats;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            stats = new Stat[5];
            this.Stats[0] = new Stat("Endurance", endurance);
            this.Stats[1] = new Stat("Sprint", sprint);
            this.Stats[2] = new Stat("Dribble", dribble);
            this.Stats[3] = new Stat("Passing", passing);
            this.Stats[4] = new Stat("Shooting", shooting);
        }


        public string Name
        {
            get { return name; }
            private set
            { name = value; }
        }

        private Stat[] Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        public int Endurance { get => this.Stats[0].Size; }

        public int Sprint { get => this.Stats[1].Size; }

        public int Dribble { get => this.Stats[2].Size; }

        public int Passing { get => this.Stats[3].Size; }

        public int Shooting { get => this.Stats[4].Size; }

        public int SkillLevel
        {
            get { return this.CalculateSkillLevel(); }
        }


        private int CalculateSkillLevel()
        {
            return (int)Math.Round(this.Stats.Average(s => s.Size));
        }

    }
}


