using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int knifeMinDamage = 3;
        private const int knifeMaxDamage = 4;
        private const int knifeNmberOfSockets = 2;

        public Knife(string name, IRaritiy raritiy)
            : base(name, raritiy, knifeMinDamage, knifeMaxDamage, knifeNmberOfSockets)
        {
        }
    }
}
