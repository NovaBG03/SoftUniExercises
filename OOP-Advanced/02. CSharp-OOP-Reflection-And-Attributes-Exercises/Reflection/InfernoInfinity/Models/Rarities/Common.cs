namespace InfernoInfinity.Models.Rarities
{
    public class Common : Raritiy
    {
        private const int commonDamageIncrease = 1;

        public Common() 
            : base(commonDamageIncrease)
        {
        }
    }
}
