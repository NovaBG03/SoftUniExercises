using MilitaryElite.Soldiers;

namespace MilitaryElite.Model
{
    interface ILieutenantGeneral : IPrivate
    {
        void AddPrivate(Private @private);
    }
}
