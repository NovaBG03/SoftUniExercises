namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MortalEngines.Entities.Contracts;

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Targets = new List<string>();

            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                name = value;
            }
        }

        public IPilot Pilot
        {
            get => pilot;
            set => pilot = value ?? throw new ArgumentNullException("Pilot cannot be null.");
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            this.Targets.Add(target.Name);

            var damage = this.AttackPoints - target.DefensePoints;
            if (damage < 0)
            {
                return;
            }

            target.HealthPoints -= damage;
            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints:F2}")
                .AppendLine($" *Attack: {this.AttackPoints:F2}")
                .AppendLine($" *Defense: {this.DefensePoints:F2}");

            if (this.Targets.Count == 0)
            {
                builder.AppendLine(" *Targets: None");
            }
            else
            {
                builder.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return builder.ToString().TrimEnd();
        }
    }
}
