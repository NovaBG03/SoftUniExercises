using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Rarities
{
    public abstract class Rarity : IRarity
    {
        protected Rarity(int damageIncrease)
        {
            this.DamageIncrease = damageIncrease;
        }

        public int DamageIncrease { get; }
    }
}
