using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        private const int amethystStrength = 2;
        private const int amethystAgility = 8;
        private const int amethystVitality = 4;

        public Amethyst(IClarity clarity)
            : base(amethystStrength, amethystAgility, amethystVitality, clarity)
        {
        }
    }
}
