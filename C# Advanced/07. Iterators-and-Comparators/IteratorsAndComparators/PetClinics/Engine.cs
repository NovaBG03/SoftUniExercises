using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinics
{
    public class Engine
    {
        private List<Pet> pets;
        private List<Clinic> clinics;

        public Engine()
        {
            this.pets = new List<Pet>();
            this.clinics = new List<Clinic>();
        }

        public void Run()
        {
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var input = Console.ReadLine();
                var inputArg = input.Split();

                if (input.StartsWith("Create Pet"))
                {
                    string name = inputArg[2];
                    int age = int.Parse(inputArg[3]);
                    string kind = inputArg[4];

                    this.CreatePet(name, age, kind);
                }
                else if (input.StartsWith("Create Clinic"))
                {
                    string name = inputArg[2];
                    int rooms = int.Parse(inputArg[3]);

                    this.CreateClinic(name, rooms);
                }
                else if (input.StartsWith("Add"))
                {
                    string petName = inputArg[1];
                    string clinicName = inputArg[2];

                    this.AddPetToClinic(petName, clinicName);
                }
                else if (input.StartsWith("Release"))
                {
                    string clinicName = inputArg[1];

                    this.Release(clinicName);
                }
                else if (input.StartsWith("HasEmptyRooms"))
                {
                    string clinicName = inputArg[1];

                    this.HasEmptyRooms(clinicName);
                }
                else if (input.StartsWith("Print"))
                {
                    string clinicName = inputArg[1];

                    if (inputArg.Length == 2)
                    {
                        this.Print(clinicName);
                    }
                    else if (inputArg.Length == 3)
                    {
                        int roomNumber = int.Parse(inputArg[2]);

                        this.Print(clinicName, roomNumber);
                    }
                }
            }
        }

        private void Print(string clinicName, int roomNumber)
        {
            Clinic clinic = GetClinic(clinicName);

            Console.WriteLine(clinic[roomNumber - 1]);
        }

        private void Print(string clinicName)
        {
            Clinic clinic = GetClinic(clinicName);

            Console.WriteLine(clinic);
        }

        private void HasEmptyRooms(string clinicName)
        {
            Clinic clinic = GetClinic(clinicName);
            var restult = clinic.HasEmptyRooms();

            Console.WriteLine(restult);
        }

        private void Release(string clinicName)
        {
            Clinic clinic = GetClinic(clinicName);
            var restult = clinic.Release();

            Console.WriteLine(restult);
        }

        private void AddPetToClinic(string petName, string clinicName)
        {
            Pet pet = GetPet(petName);
            Clinic clinic = GetClinic(clinicName);

            if (pet == null)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }

            var result = clinic.Add(pet);

            Console.WriteLine(result);
        }

        private Clinic GetClinic(string clinicName)
        {
            return this.clinics.FirstOrDefault(c => c.Name == clinicName);
        }

        private Pet GetPet(string petName)
        {
            return this.pets.FirstOrDefault(p => p.Name == petName);
        }

        private void CreateClinic(string name, int rooms)
        {
            try
            {
                Clinic clinic = new Clinic(name, rooms);
                this.clinics.Add(clinic);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        private void CreatePet(string name, int age, string kind)
        {
            Pet pet = new Pet(name, age, kind);

            this.pets.Add(pet);
        }
    }
}
