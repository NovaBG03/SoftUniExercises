using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        private static List<Person> people;

        public static void Main(string[] args)
        {
            people = new List<Person>();

            FillPeople();

            var selectedPersonIndex = int.Parse(Console.ReadLine()) - 1;
            Person selectedPerson = people[selectedPersonIndex];

            int matchCounter = GetMatchCount(selectedPerson);

            PrintInfo(matchCounter);
        }

        private static void PrintInfo(int matchCounter)
        {
            if (matchCounter - 1 == 0)
            {
                Console.WriteLine("No matches");
                return;
            }

            Console.WriteLine($"{people.Count - matchCounter} {matchCounter} {people.Count}");
        }

        private static int GetMatchCount(Person selectedPerson)
        {
            int matchCounter = 0;

            foreach (var person in people)
            {
                if (selectedPerson.CompareTo(person) == 0)
                {
                    matchCounter++;
                }
            }

            return matchCounter;
        }

        private static void FillPeople()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var personInput = input.Split();

                var name = personInput[0];
                var age = int.Parse(personInput[1]);
                var town = personInput[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }
        }
    }
}
