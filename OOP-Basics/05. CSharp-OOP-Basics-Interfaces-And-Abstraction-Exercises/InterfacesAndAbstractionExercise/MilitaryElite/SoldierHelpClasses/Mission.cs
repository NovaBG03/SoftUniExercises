using MilitaryElite.Enumerations;

namespace MilitaryElite.SoldierHelpClasses
{
    class Mission
    {
        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }


        public string CodeName { get; private set; }

        public State State { get; set; }


        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
