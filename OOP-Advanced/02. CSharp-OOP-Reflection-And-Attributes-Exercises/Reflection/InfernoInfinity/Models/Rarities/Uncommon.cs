namespace InfernoInfinity.Models.Rarities
{
    public class Uncommon : Raritiy
    {
        private const int uncommonDamageIncrease = 2;

        public Uncommon()
            : base(uncommonDamageIncrease)
        {
        }
    }
}
