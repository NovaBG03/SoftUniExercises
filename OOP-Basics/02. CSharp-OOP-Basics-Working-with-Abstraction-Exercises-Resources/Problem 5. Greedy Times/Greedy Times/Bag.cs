using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp51
{
    class Bag
    {
        private long capacity;
        private List<Gold> golds;
        private List<Gem> gems;
        private List<Cash> cashes;

        public Bag(long capacity)
        {
            this.Capacity = capacity;
            golds = new List<Gold>();
            gems = new List<Gem>();
            cashes = new List<Cash>();
        }


        public long Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public List<Gold> Golds
        {
            get { return golds; }
            set { golds = value; }
        }

        public List<Gem> Gems
        {
            get { return gems; }
            set { gems = value; }
        }

        public List<Cash> Cashes
        {
            get { return cashes; }
            set { cashes = value; }
        }

        public void AddGold(string itemName, long itemQuantity)
        {
            Gold gold = this.Golds.FirstOrDefault(x => x.Name == itemName);

            bool isEnoughSpace = this.Capacity >= itemQuantity;

            if (gold == null)
            {
                gold = new Gold(itemName, itemQuantity);

                if (isEnoughSpace)
                {
                    this.Golds.Add(gold);
                    this.Capacity -= itemQuantity;
                }
            }
            else
            {
                if (isEnoughSpace)
                {
                    gold.Quantity += itemQuantity;
                    this.Capacity -= itemQuantity;
                }
            }

        }


        public void AddGem(string itemName, long itemQuantity)
        {
            Gem gem = this.Gems.FirstOrDefault(x => x.Name == itemName);

            bool isItWorth = this.Golds.Sum(x => x.Quantity) >= this.Gems.Sum(x => x.Quantity) + itemQuantity;
            bool isEnoughSpace = this.Capacity >= itemQuantity;

            if (gem == null)
            {
                gem = new Gem(itemName, itemQuantity);

                if (isItWorth && isEnoughSpace)
                {
                    this.Gems.Add(gem);
                    this.Capacity -= itemQuantity;
                }
            }
            else
            {
                if (isItWorth && isEnoughSpace)
                {
                    gem.Quantity += itemQuantity;
                    this.Capacity -= itemQuantity;
                }
            }

        }


        public void AddCash(string itemName, long itemQuantity)
        {
            Cash cash = this.Cashes.FirstOrDefault(x => x.Name == itemName);

            bool isItWorth = this.Gems.Sum(x => x.Quantity) >= this.Cashes.Sum(x => x.Quantity) + itemQuantity;
            bool isEnoughSpace = this.Capacity >= itemQuantity;

            if (cash == null)
            {
                cash = new Cash(itemName, itemQuantity);

                if (isItWorth && isEnoughSpace)
                {
                    this.Cashes.Add(cash);
                    this.Capacity -= itemQuantity;
                }
            }
            else
            {
                if (isItWorth && isEnoughSpace)
                {
                    cash.Quantity += itemQuantity;
                    this.Capacity -= itemQuantity;
                }
            }
        }


    }
}
