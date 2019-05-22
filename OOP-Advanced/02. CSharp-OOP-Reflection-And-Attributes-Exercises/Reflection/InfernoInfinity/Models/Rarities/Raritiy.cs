using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Rarities
{
    public abstract class Raritiy : IRaritiy
    {
        protected Raritiy(int damageIncrease)
        {
            this.DamageIncrease = damageIncrease;
        }

        public int DamageIncrease { get; }
    }
}
