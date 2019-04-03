using MilitaryElite.SoldierHelpClasses;

namespace MilitaryElite.Model
{
    interface ICommando : ISpecialisedSoldier
    {
        void AddMission(Mission mission);

        void CompleteMission(string codeName);
    }
}
