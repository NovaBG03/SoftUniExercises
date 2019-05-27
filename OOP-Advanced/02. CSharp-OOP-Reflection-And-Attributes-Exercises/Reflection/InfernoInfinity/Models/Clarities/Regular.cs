namespace InfernoInfinity.Models.Clarities
{
    public class Regular : Clarity
    {
        private const int regularDamageIncrease = 2;

        public Regular()
            : base(regularDamageIncrease)
        {
        }
    }
}
