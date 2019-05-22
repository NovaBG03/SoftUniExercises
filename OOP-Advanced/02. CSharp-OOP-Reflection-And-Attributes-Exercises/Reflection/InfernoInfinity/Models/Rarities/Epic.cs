namespace InfernoInfinity.Models.Rarities
{
    public class Epic : Raritiy
    {
        private const int epicDamageIncrease = 5;

        public Epic()
            : base(epicDamageIncrease)
        {
        }
    }
}
