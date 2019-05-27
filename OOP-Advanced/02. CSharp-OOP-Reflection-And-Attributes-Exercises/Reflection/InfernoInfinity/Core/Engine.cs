using InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfernoInfinity.Core
{
    public class Engine : IRunnable
    {
        private IRarityFactory rarityFactory;
        private IWeaponFactory weaponFactory;
        private IClarityFactory clarityFactory;
        private IGemFactory gemFactory;
        private List<IWeapon> weapons;

        public Engine(IRarityFactory rarityFactory, IWeaponFactory weaponFactory, IClarityFactory clarityFactory, IGemFactory gemFactory)
        {
            this.rarityFactory = rarityFactory;
            this.weaponFactory = weaponFactory;
            this.clarityFactory = clarityFactory;
            this.gemFactory = gemFactory;
            this.weapons = new List<IWeapon>();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split(";");

                var command = input[0];

                switch (command)
                {
                    case "Create":
                        this.Create(input);
                        break;
                    case "Add":
                        this.AddGem(input);
                        break;
                    case "Remove":
                        this.Remove(input);
                        break;
                    case "Print":
                        this.Print(input);
                        break;
                    case "END":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Print(string[] input)
        {
            var weaponName = input[1];
            var weapon = GetWeapon(weaponName);

            if (weapon == null)
            {
                return;
            }

            Console.WriteLine(weapon);
        }

        private void Remove(string[] input)
        {
            var weaponName = input[1];
            var weapon = GetWeapon(weaponName);

            if (weapon == null)
            {
                return;
            }

            var socketIndex = int.Parse(input[2]);

            weapon.ClearSocket(socketIndex);
        }

        private void AddGem(string[] input)
        {
            var weaponName = input[1];
            var weapon = GetWeapon(weaponName);

            if (weapon == null)
            {
                return;
            }

            var socketIndex = int.Parse(input[2]);

            var gemInfo = input[3].Split();

            var gemClarityAsString = gemInfo[0];
            var gemClarity = this.clarityFactory.CreateClarity(gemClarityAsString);

            var gemTypeAsString = gemInfo[1];
            var gem = this.gemFactory.CreateGem(gemTypeAsString, gemClarity);

            weapon.AddGem(socketIndex, gem);
        }

        private IWeapon GetWeapon(string weaponName)
        {
            return this.weapons.FirstOrDefault(w => w.Name == weaponName);
        }

        private void Create(string[] input)
        {
            var weaponInfo = input[1].Split();

            var weaponRarityAsString = weaponInfo[0];
            IRarity weaponRarity = this.rarityFactory.CreateRarity(weaponInfo[0]);

            var weaponTypeAsString = weaponInfo[1];
            var weaponName = input[2];

            var weapon = this.weaponFactory.CreateWeapon(weaponTypeAsString, weaponName, weaponRarity);

            this.weapons.Add(weapon);
        }
    }
}
