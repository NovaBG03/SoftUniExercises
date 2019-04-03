using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }
                string[] info = input.Split();
                //< TrainerName > < PokemonName > < PokemonElement > < PokemonHealth >
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Exists(x => x.Name == trainerName))
                {
                    trainers.Find(x => x.Name == trainerName).Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);

                    trainers.Add(trainer);
                }
            }

            while (true)
            {
                string element = Console.ReadLine();

                if (element == "End")
                {
                    break;
                }

                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Exists(x => x.Element == element))
                    {
                        trainer.BadgesCount += 1;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
            }

            foreach (Trainer trainer in trainers.OrderByDescending(x => x.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }

            Console.ReadLine();
        }
    }
}
