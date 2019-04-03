﻿namespace MilitaryElite.SoldierHelpClasses
{
    class Repair
    {
        public Repair(string partName, int workedHours)
        {
            this.PartName = partName;
            this.WorkedHours = workedHours;
        }


        public string PartName { get; private set; }

        public int WorkedHours { get; private set; }


        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.WorkedHours}";
        }
    }
}
