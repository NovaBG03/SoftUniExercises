namespace InfernoInfinity.Models.Clarities
{
    public class Perfect : Clarity
    {
        private const int perfectDamageIncrease = 5;

        public Perfect()
            : base(perfectDamageIncrease)
        {
        }
    }
}
