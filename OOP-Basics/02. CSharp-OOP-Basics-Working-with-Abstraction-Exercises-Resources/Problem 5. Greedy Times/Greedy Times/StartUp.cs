using System;
using System.Linq;

namespace ConsoleApp51
{
    public class startUp
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            Bag bag = new Bag(capacity);

            string[] itemsImput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < itemsImput.Length; i += 2)
            {
                string itemName = itemsImput[i];
                long itemQuantity = long.Parse(itemsImput[i + 1]);

                string whatIs = string.Empty;

                if (itemName.Length == 3)
                {
                    whatIs = "Cash";
                }
                else if (itemName.ToLower().EndsWith("gem"))
                {
                    whatIs = "Gem";
                }
                else if (itemName.ToLower() == "gold")
                {
                    whatIs = "Gold";
                }

                if (whatIs == "")
                {
                    continue;
                }
                else if (bag.Capacity - itemQuantity < 0)
                {
                    continue;
                }

                switch (whatIs)
                {
                    case "Gold":
                        bag.AddGold(itemName, itemQuantity);
                        break;

                    case "Gem":
                        bag.AddGem(itemName, itemQuantity);
                        break;

                    case "Cash":
                        bag.AddCash(itemName, itemQuantity);
                        break;

                }
            }

            if (bag.Golds.Count != 0)
            {
                Console.WriteLine($"<Gold> ${bag.Golds.Sum(x => x.Quantity)}");

                foreach (var gold in bag.Golds.OrderByDescending(x => x.Name).ThenBy(y => y.Quantity))
                {
                    Console.WriteLine($"##{gold.Name} - {gold.Quantity}");
                }
            }

            if (bag.Gems.Count != 0)
            {
                Console.WriteLine($"<Gem> ${bag.Gems.Sum(x => x.Quantity)}");

                foreach (var gem in bag.Gems.OrderByDescending(x => x.Name).ThenBy(y => y.Quantity))
                {
                    Console.WriteLine($"##{gem.Name} - {gem.Quantity}");
                }
            }

            if (bag.Cashes.Count != 0)
            {
                Console.WriteLine($"<Cash> ${bag.Cashes.Sum(x => x.Quantity)}");

                foreach (var cash in bag.Cashes.OrderByDescending(x => x.Name).ThenBy(y => y.Quantity))
                {
                    Console.WriteLine($"##{cash.Name} - {cash.Quantity}");
                }
            }

            Console.ReadLine();
        }
    }
}

