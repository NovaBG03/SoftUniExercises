using MilitaryElite.Enumerations;
using MilitaryElite.Model;
using MilitaryElite.SoldierHelpClasses;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Soldiers
{
    class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<Mission>();
        }


        private List<Mission> missions;


        public void AddMission(Mission mission)
        {
            missions.Add(mission);
        }

        public void CompleteMission(string codeName)
        {
            Mission mission = missions.First(m => m.CodeName == codeName);
            mission.State = State.Finished;
        }


        public override string ToString()
        {
            return base.ToString() + "\nMissions:\n " + string.Join("\n ", this.missions);
        }
    }
}
