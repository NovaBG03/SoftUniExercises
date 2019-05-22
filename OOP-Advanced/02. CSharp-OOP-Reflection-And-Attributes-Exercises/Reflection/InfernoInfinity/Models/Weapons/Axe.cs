using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int axeMinDamage = 5;
        private const int axeMaxDamage = 10;
        private const int axeNmberOfSockets = 4;

        public Axe(string name, IRaritiy raritiy) 
            : base(name, raritiy, axeMinDamage, axeMaxDamage, axeNmberOfSockets)
        {
        }
    }
}
