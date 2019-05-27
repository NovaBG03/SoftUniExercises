namespace InfernoInfinity.Models.Rarities
{
    public class Epic : Rarity
    {
        private const int epicDamageIncrease = 5;

        public Epic()
            : base(epicDamageIncrease)
        {
        }
    }
}
