namespace MortalEngines.Core
{
    using System;

    using MortalEngines.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly IMachinesManager machinesManager;

        public Engine(IMachinesManager machinesManager)
        {
            this.machinesManager = machinesManager;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                string command = input[0];

                try
                {
                    string result = string.Empty;

                    switch (command)
                    {
                        case "HirePilot":
                            result = machinesManager.HirePilot(input[1]);
                            break;
                        case "PilotReport":
                            result = machinesManager.PilotReport(input[1]);
                            break;
                        case "ManufactureTank":
                            result = machinesManager.ManufactureTank(input[1], double.Parse(input[2]), double.Parse(input[3]));
                            break;
                        case "ManufactureFighter":
                            result = machinesManager.ManufactureFighter(input[1], double.Parse(input[2]), double.Parse(input[3]));
                            break;
                        case "MachineReport":
                            result = machinesManager.MachineReport(input[1]);
                            break;
                        case "AggressiveMode":
                            result = machinesManager.ToggleFighterAggressiveMode(input[1]);
                            break;
                        case "DefenseMode":
                            result = machinesManager.ToggleTankDefenseMode(input[1]);
                            break;
                        case "Engage":
                            result = machinesManager.EngageMachine(input[1], input[2]);
                            break;
                        case "Attack":
                            result = machinesManager.AttackMachines(input[1], input[2]);
                            break;
                        case "Quit":
                            return;
                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

    }
}
