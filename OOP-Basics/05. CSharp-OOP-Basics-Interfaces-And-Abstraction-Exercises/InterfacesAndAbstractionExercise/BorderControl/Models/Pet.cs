using BorderControl.Contracts;
using System;

namespace BorderControl.Models
{
    public class Pet : IBirthdate
    {
        public Pet(string name, DateTime birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }


        public string Name { get; private set; }

        public DateTime Birthdate { get; private set; }
    }
}
