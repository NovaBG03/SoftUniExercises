using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        private const int emeraldStrength = 1;
        private const int emeraldAgility = 4;
        private const int emeraldVitality = 9;

        public Emerald(IClarity clarity)
            : base(emeraldStrength, emeraldAgility, emeraldVitality, clarity)
        {
        }
    }
}
