using InfernoInfinity.Contracts;

namespace InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int rubyStrength = 7;
        private const int rubyAgility = 2;
        private const int rubyVitality = 5;

        public Ruby(IClarity clarity) 
            : base(rubyStrength, rubyAgility, rubyVitality, clarity)
        {
        }
    }
}
