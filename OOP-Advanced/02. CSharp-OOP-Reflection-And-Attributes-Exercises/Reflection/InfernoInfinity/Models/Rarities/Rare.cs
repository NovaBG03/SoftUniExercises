namespace InfernoInfinity.Models.Rarities
{
    public class Rare : Rarity
    {
        private const int rareDamageIncrease = 3;

        public Rare()
            : base(rareDamageIncrease)
        {
        }
    }
}
