namespace InfernoInfinity.Models.Rarities
{
    public class Rare : Raritiy
    {
        private const int rareDamageIncrease = 3;

        public Rare()
            : base(rareDamageIncrease)
        {
        }
    }
}
