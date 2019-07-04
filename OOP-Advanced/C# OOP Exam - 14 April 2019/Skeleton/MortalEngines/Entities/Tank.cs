namespace MortalEngines.Entities
{
    using MortalEngines.Entities.Contracts;

    public class Tank : BaseMachine, ITank
    {
        private const int InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;

            if (this.DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            if (this.DefenseMode)
            {
                return base.ToString() + "\n" + " *Defense: ON";
            }
            else
            {
                return base.ToString() + "\n" + " *Defense: OFF";
            }
        }
    }
}
