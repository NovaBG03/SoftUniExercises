namespace MortalEngines.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;


        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.GetPilot(name) != null)
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            var pilot = new Pilot(name);
            this.pilots.Add(pilot);

            return string.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var machine = this.GetTank(name);
            if (machine != null)
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            machine = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(machine);

            return string.Format(OutputMessages.TankManufactured, machine.Name, machine.AttackPoints, machine.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            var machine = this.GetFighter(name);
            if (machine != null)
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            machine = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(machine);

            return string.Format(OutputMessages.FighterManufactured, machine.Name, machine.AttackPoints, machine.DefensePoints, machine.AggressiveMode? "ON" : "OFF");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = GetPilot(selectedPilotName);
            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            var machine = GetMachine(selectedMachineName);
            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machine.Pilot = pilot;
            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = GetMachine(attackingMachineName);
            if (attackingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            var defendingMachine = GetMachine(defendingMachineName);
            if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attackingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (defendingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);

        }

        public string PilotReport(string pilotReporting)//TODO if does not work --> hange to string name
        {
            var pilot = this.GetPilot(pilotReporting);

            return pilot?.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.GetMachine(machineName);

            return machine?.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = this.GetFighter(fighterName);

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            fighter.ToggleAggressiveMode();
            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = this.GetTank(tankName);

            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            tank.ToggleDefenseMode();
            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }

        private IPilot GetPilot(string name)
        {
            return this.pilots.FirstOrDefault(p => p.Name == name);
        }

        private IMachine GetMachine(string name)
        {
            return this.machines.FirstOrDefault(m => m.Name == name);
        }
        private IFighter GetFighter(string name)
        {
            return (IFighter)this.machines.FirstOrDefault(m => m.Name == name && m is IFighter);
        }

        private ITank GetTank(string name)
        {
            return (ITank)this.machines.FirstOrDefault(m => m.Name == name && m is ITank);
        }
    }
}