using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opinion_Poll
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }


            foreach (Person person in people.OrderBy(x => x.Name[0]))
            {
                if (person.Age >= 30)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }

            Console.ReadLine();
        }
    }
}
