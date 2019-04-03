using MilitaryElite.Model;
using System.Collections.Generic;

namespace MilitaryElite.Soldiers
{
    class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }


        private List<Private> privates;


        public void AddPrivate(Private @private)
        {
            this.privates.Add(@private);
        }


        public override string ToString()
        {
            return base.ToString() + $" \nPrivates:\n {string.Join("\n ", this.privates)}";
        }
    }
}
