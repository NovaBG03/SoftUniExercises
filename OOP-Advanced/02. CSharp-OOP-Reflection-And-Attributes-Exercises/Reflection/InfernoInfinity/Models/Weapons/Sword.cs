using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        private const int swordMinDamage = 4;
        private const int swordMaxDamage = 6;
        private const int swordNmberOfSockets = 3;

        public Sword(string name, IRarity raritiy)
            : base(name, raritiy, swordMinDamage, swordMaxDamage, swordNmberOfSockets)
        {
        }
    }
}
