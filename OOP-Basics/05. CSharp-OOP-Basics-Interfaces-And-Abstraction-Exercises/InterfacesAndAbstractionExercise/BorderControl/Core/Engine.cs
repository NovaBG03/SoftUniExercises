using BorderControl.Contracts;
using BorderControl.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Core
{
    public class Engine
    {
        private CreatureFactory factory;
        private ICollection<IBuyer> buyers;

        public Engine()
        {
            this.factory = new CreatureFactory();
            this.buyers = new List<IBuyer>();
        }

        public void Run()
        {
            string input;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                string[] inputArg = input.Split();

                string creatureType = inputArg[0];

                IBuyer creature = factory.CreateCreature(inputArg);
                if (creature != null)
                {
                    this.buyers.Add(creature);
                }
            }


            input = Console.ReadLine();
            while (input != "End")
            {
                IBuyer buyer = GetBuyer(input);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                input = Console.ReadLine();
            }


            int foods = this.buyers.Sum(b => b.Food);
            Console.WriteLine(foods);

            Console.ReadLine();
        }


        private IBuyer GetBuyer(string name)
        {
            return this.buyers.FirstOrDefault(b => b.Name == name);
        }
    }
}
