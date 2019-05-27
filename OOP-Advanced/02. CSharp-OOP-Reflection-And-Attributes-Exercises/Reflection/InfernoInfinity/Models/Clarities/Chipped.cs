namespace InfernoInfinity.Models.Clarities
{
    public class Chipped : Clarity
    {
        private const int chippedDamageIncrease = 1;

        public Chipped() 
            : base(chippedDamageIncrease)
        {
        }
    }
}
