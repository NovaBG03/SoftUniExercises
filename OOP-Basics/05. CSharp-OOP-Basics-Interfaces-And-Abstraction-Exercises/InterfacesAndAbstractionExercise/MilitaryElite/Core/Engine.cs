using MilitaryElite.Enumerations;
using MilitaryElite.SoldierHelpClasses;
using MilitaryElite.Soldiers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    class Engine
    {
        private List<Soldier> soldiers;
        private List<Private> privates;

        public Engine()
        {
            this.soldiers = new List<Soldier>();
            this.privates = new List<Private>();
        }


        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string rank = input[0].ToLower();
                if (rank == "end")
                {
                    break;
                }
                string id = input[1];
                string firstName = input[2];
                string lastName = input[3];
                decimal salary = decimal.Parse(input[4]);

                switch (rank)
                {
                    case "private":
                        Private @private = new Private(id, firstName, lastName, salary);
                        this.soldiers.Add(@private);
                        this.privates.Add(@private);
                        break;

                    case "lieutenantgeneral":
                        LieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);
                        for (int i = 5; i < input.Length; i++)
                        {
                            Private findedPrivate = this.privates.FirstOrDefault(p => p.Id == input[i]);
                            lieutenant.AddPrivate(findedPrivate);
                        }
                        this.soldiers.Add(lieutenant);
                        break;

                    case "engineer":
                        if (!Enum.TryParse(input[5], out Corps engineerCorps))
                        {
                            continue;
                        }
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, engineerCorps);
                        for (int i = 6; i < input.Length; i += 2)
                        {
                            string partName = input[i];
                            int workedHours = int.Parse(input[i + 1]);
                            Repair repair = new Repair(partName, workedHours);
                            engineer.AddRepair(repair);
                        }
                        this.soldiers.Add(engineer);
                        break;

                    case "commando":
                        if (!Enum.TryParse(input[5], out Corps commandoCorps))
                        {
                            continue;
                        }
                        Commando commando = new Commando(id, firstName, lastName, salary, commandoCorps);
                        for (int i = 6; i < input.Length; i += 2)
                        {
                            string codeName = input[i];
                            if (!Enum.TryParse(input[i + 1], out State state))
                            {
                                continue;
                            }
                            Mission mission = new Mission(codeName, state);
                            commando.AddMission(mission);
                        }
                        this.soldiers.Add(commando);
                        break;

                    case "spy":
                        int codeNumber = int.Parse(input[4]);
                        Spy spy = new Spy(id, firstName, lastName, codeNumber);
                        this.soldiers.Add(spy);
                        break;

                    default:
                        break;
                }
            }

            Print();
        }

        private void Print()
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
