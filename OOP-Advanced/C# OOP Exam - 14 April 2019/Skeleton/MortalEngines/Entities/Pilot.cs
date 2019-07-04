namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MortalEngines.Entities.Contracts;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.machines = new List<IMachine>();

            this.Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (var machine in machines)
            {
                builder.AppendLine(machine.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
