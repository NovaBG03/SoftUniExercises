using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldest_Family_Member
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string name;
            int age;
            Person familyMember;
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                name = input[0];
                age = int.Parse(input[1]);
                familyMember = new Person(name, age);
                family.AddMember(familyMember);
            }

            Person oldestMember = family.GetOldersMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");

            Console.ReadLine();
        }
    }
}
