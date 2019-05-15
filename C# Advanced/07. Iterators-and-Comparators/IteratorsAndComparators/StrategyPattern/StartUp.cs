using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> NameSortedPeople = new SortedSet<Person>(new PersonNameComparer());
            SortedSet<Person> AgeSortedPeople = new SortedSet<Person>(new PersonAgeComparer());

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                var input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                NameSortedPeople.Add(person);
                AgeSortedPeople.Add(person);
            }

            foreach (var person in NameSortedPeople)
            {
                Console.WriteLine(person);
            }

            foreach (var person in AgeSortedPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}