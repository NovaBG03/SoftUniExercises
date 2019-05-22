using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Clarities
{
    public class Clarity : IClarity
    {
        protected Clarity(int damageIncrease)
        {
            this.DamageIncrease = damageIncrease;
        }

        public int DamageIncrease { get; }
    }
}
