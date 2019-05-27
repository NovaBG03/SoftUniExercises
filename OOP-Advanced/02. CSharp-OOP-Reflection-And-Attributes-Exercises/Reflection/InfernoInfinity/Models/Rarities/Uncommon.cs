namespace InfernoInfinity.Models.Rarities
{
    public class Uncommon : Rarity
    {
        private const int uncommonDamageIncrease = 2;

        public Uncommon()
            : base(uncommonDamageIncrease)
        {
        }
    }
}
