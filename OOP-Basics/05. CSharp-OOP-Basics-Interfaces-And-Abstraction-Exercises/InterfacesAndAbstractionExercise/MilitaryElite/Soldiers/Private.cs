using MilitaryElite.Model;

namespace MilitaryElite.Soldiers
{
    class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }


        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:f2}";
        }
    }
}
