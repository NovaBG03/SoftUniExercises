using MilitaryElite.Enumerations;
using MilitaryElite.Model;
using MilitaryElite.SoldierHelpClasses;
using System.Collections.Generic;

namespace MilitaryElite.Soldiers
{
    class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<Repair>();
        }


        private List<Repair> repairs;


        public void AddRepair(Repair repair)
        {
            repairs.Add(repair);
        }


        public override string ToString()
        {
            return base.ToString() + "\nRepairs:\n " + string.Join("\n ", this.repairs);
        }
    }
}
