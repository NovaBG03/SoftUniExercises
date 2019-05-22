using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        private readonly int strength;
        private readonly int agility;
        private readonly int vitality;

        protected Gem(int strength, int agility, int vitality, IClarity clarity)
        {
            this.strength = strength;
            this.agility = agility;
            this.vitality = vitality;
            this.Clarity = clarity;
        }

        public int Strength => strength + this.Clarity.DamageIncrease;

        public int Agility => agility + this.Clarity.DamageIncrease;

        public int Vitality => vitality + this.Clarity.DamageIncrease;

        public IClarity Clarity { get; }
    }
}
