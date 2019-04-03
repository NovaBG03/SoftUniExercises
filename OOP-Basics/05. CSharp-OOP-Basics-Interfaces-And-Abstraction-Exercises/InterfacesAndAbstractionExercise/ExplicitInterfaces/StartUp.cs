using ExplicitInterfaces.Contracts;
using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArg = input.Split();

                string name = inputArg[0];
                string country = inputArg[1];
                int age = int.Parse(inputArg[2]);

                Citizen citizen = new Citizen(name, country, age);
                citizens.Add(citizen);

                input = Console.ReadLine();
            }


            foreach (Citizen citizen in citizens)
            {
                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }

            Console.ReadKey();
        }
    }
}
