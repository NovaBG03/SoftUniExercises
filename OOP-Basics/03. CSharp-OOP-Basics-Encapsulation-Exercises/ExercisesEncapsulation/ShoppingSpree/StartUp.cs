using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        public static List<Person> people = new List<Person>();
        public static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleInput.Length; i += 2)
            {
                string name = peopleInput[i];
                decimal money = decimal.Parse(peopleInput[i + 1]);
                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productsInput = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsInput.Length; i += 2)
            {
                string name = productsInput[i];
                decimal cost = decimal.Parse(productsInput[i + 1]);
                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] purchasInput = input.Split();
                string personName = purchasInput[0];
                string productName = purchasInput[1];

                Person person = GetPerson(personName);
                Product product = GetProduct(productName);

                try
                {
                    person.BuyProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (System.ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

        }

        private static Product GetProduct(string productName)
        {
            return products.FirstOrDefault(x => x.Name == productName);
        }

        private static Person GetPerson(string personName)
        {
            return people.FirstOrDefault(x => x.Name == personName);
        }
    }
}
