using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] info = input.Split();
                string name = info[0];
                string type = info[1];

                if (!people.Exists(x => x.Name == name))
                {
                    Person person = new Person(name);
                    people.Add(person);
                }

                switch (type)
                {
                    case "company":
                        string companyName = info[2];
                        string companyDepartment = info[3];
                        decimal companySalary = decimal.Parse(info[4]);
                        Company company = new Company(companyName, companyDepartment, companySalary);
                        people.Find(x => x.Name == name).Company = company;
                        break;

                    case "pokemon":
                        string pokemonName = info[2];
                        string pokemonType = info[3];
                        Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                        people.Find(x => x.Name == name).Pokemons.Add(pokemon);
                        break;

                    case "parents":
                        string parentName = info[2];
                        DateTime parentBirthday = DateTime.Parse(info[3]);
                        Parent parent = new Parent(parentName, parentBirthday);
                        people.Find(x => x.Name == name).Parents.Add(parent);
                        break;

                    case "children":
                        string childrentName = info[2];
                        DateTime childrenBirthday = DateTime.Parse(info[3]);
                        Children children = new Children(childrentName, childrenBirthday);
                        people.Find(x => x.Name == name).Childrens.Add(children);
                        break;

                    case "car":
                        string carModel = info[2];
                        int carSpeed = int.Parse(info[3]);
                        Car car = new Car(carModel, carSpeed);
                        people.Find(x => x.Name == name).Car = car;
                        break;

                }
            }

            string personName = Console.ReadLine();
            Person specialPerson = people.Find(x => x.Name == personName);

            Console.WriteLine();

            string personalInformation = specialPerson.ToString();
            Console.WriteLine(personalInformation);

            Console.ReadLine();
        }
    }
}
