using InfernoInfinity.Contracts;
using System.Linq;

namespace InfernoInfinity.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private readonly int minDamage;
        private readonly int maxDamage;
        private IGem[] sockets;

        protected Weapon(string name, IRaritiy raritiy, int minDamage, int maxDamage, int numberOfSockets)
        {
            this.Name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.sockets = new IGem[numberOfSockets];
            this.Raritiy = raritiy;
        }

        public string Name { get; }

        public int MinDamage => minDamage * this.Raritiy.DamageIncrease + this.MagicalStatsMinDamageBonus;

        public int MaxDamage => maxDamage * this.Raritiy.DamageIncrease + this.MagicalStatsMaxDamageBonus;

        public int NumberOfSockets => this.sockets.Length;

        public IRaritiy Raritiy { get; }

        public int Strength => this.CalculateGemStrengthBonus();

        public int Agility => this.CalculateGemAgilityBonus();

        public int Vitality => this.CalculateGemVitalityBonus();

        private int MagicalStatsMinDamageBonus => this.CalculateMagicalStatsMinDamageBonus();

        private int MagicalStatsMaxDamageBonus => this.CalculateMagicalStatsMaxDamageBonus();

        private int CalculateGemStrengthBonus()
        {
            return this.sockets
                .Where(g => g != null)
                .Sum(g => g.Strength);
        }

        private int CalculateGemAgilityBonus()
        {
            return this.sockets
                .Where(g => g != null)
                .Sum(g => g.Agility);
        }

        private int CalculateGemVitalityBonus()
        {
            return this.sockets
                .Where(g => g != null)
                .Sum(g => g.Vitality);
        }

        private int CalculateMagicalStatsMinDamageBonus()
        {
            int gemBonus = 0;

            gemBonus += this.Strength * 2;
            gemBonus += this.Agility * 1;
            gemBonus += this.Vitality * 0;

            return gemBonus;
        }

        private int CalculateMagicalStatsMaxDamageBonus()
        {
            int gemBonus = 0;

            gemBonus += this.Strength * 3;
            gemBonus += this.Agility * 4;
            gemBonus += this.Vitality * 0;

            return gemBonus;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage" +
                $", +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }
    }
}
