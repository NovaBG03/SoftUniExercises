namespace InfernoInfinity.Models.Rarities
{
    public class Common : Rarity
    {
        private const int commonDamageIncrease = 1;

        public Common() 
            : base(commonDamageIncrease)
        {
        }
    }
}
