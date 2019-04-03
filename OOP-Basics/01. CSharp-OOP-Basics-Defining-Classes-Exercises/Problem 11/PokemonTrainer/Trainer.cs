using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
        //name, number of badges and a collection of pokemon
        private string name;
        private int badgesCount;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.BadgesCount = 0;
            this.Pokemons = new List<Pokemon>();
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int BadgesCount
        {
            get { return badgesCount; }
            set { badgesCount = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }





    }
}
