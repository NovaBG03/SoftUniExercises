namespace MortalEngines.Entities
{
    using MortalEngines.Entities.Contracts;

    public class Fighter : BaseMachine, IFighter
    {
        private const int InitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            this.AggressiveMode = !this.AggressiveMode;

            if (this.AggressiveMode)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            if (this.AggressiveMode)
            {
                return base.ToString() + "\n" + " *Aggressive: ON";
            }
            else
            {
                return base.ToString() + "\n" + " *Aggressive: OFF";
            }
        }
    }
}
