using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google
{
    class Person
    {
        private string name;
        private Company company;
        private List<Pokemon> pokemons;
        private List<Parent> parents;
        private List<Children> childrens;
        private Car car;

        public Person(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.Parents = new List<Parent>();
            this.Childrens = new List<Children>();
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Company Company
        {
            get { return company; }
            set { company = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public List<Parent> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public List<Children> Childrens
        {
            get { return childrens; }
            set { childrens = value; }
        }

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public override string ToString()
        {
            string result = this.Name;

            if (this.Company != null)
            {
                result += "\nCompany:";
                result += $"\n{this.Company.Name} {this.Company.Department} {this.Company.Salary:f2}";
            }

            if (this.Car != null)
            {
                result += "\nCar:";
                result += $"\n{this.Car.Model} {this.Car.Speed}";
            }
            
            result += "\nPokemon:";
            foreach (Pokemon pokemon in this.Pokemons)
            {
                result += $"\n{pokemon.Name} {pokemon.Type}";
            }

            result += "\nParemts:";
            foreach (Parent parent in this.Parents)
            {
                result += $"\n{parent.Name} {parent.Birthday:dd/mm/yyyy}";
            }

            result += $"\nChildren:";
            foreach (Children children in this.Childrens)
            {
                result += $"\n{children.Name} {children.Birthday:dd/mm/yyyy}";
            }

            return result;
        }
    }
}
