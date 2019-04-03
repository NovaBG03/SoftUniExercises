using MilitaryElite.SoldierHelpClasses;

namespace MilitaryElite.Model
{
    interface IEngineer : ISpecialisedSoldier
    {
        void AddRepair(Repair repair);
    }
}
