using BorderControl.Contracts;
using System;

namespace BorderControl.Models
{
    public class Citizen : IId, IBirthdate, IBuyer
    {
        public Citizen(string name, int age, string id)
        {
            this.Food = 0;
            this.Id = id;
            this.Age = age;
            this.Name = name;
        }

        public Citizen(string name, int age, string id, DateTime birthdate)
            : this(name, age, id)
        {
            this.Birthdate = birthdate;
        }


        public string Id { get; private set; }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public DateTime Birthdate { get; private set; }

        public int Food { get; private set; }


        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
