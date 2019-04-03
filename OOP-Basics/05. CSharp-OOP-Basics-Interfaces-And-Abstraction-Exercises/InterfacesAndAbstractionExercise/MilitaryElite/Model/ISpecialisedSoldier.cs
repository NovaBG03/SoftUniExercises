using MilitaryElite.Enumerations;

namespace MilitaryElite.Model
{
    interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
