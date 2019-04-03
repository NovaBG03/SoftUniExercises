using MilitaryElite.Model;

namespace MilitaryElite.Soldiers
{
    class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }


        public int CodeNumber { get; private set; }


        public override string ToString()
        {
            return base.ToString() + $"\n Code Number: {this.CodeNumber}";
        }
    }
}
