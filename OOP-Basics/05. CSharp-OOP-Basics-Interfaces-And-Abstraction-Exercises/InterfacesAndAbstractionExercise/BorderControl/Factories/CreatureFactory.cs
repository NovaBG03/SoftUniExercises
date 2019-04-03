using BorderControl.Contracts;
using BorderControl.Models;
using System;

namespace BorderControl.Factories
{
    class CreatureFactory
    {
        public IBuyer CreateCreature(string[] data)
        {
            switch (data.Length)
            {
                case 4:
                    string citizenName = data[0];
                    int citizenAge = int.Parse(data[1]);
                    string citizenId = data[2];
                    DateTime CitizenBirthday = DateTime.Parse(data[3]);
                    return new Citizen(citizenName, citizenAge, citizenId, CitizenBirthday);
                case 3:
                    string rebelName = data[0];
                    int rebelAge = int.Parse(data[1]);
                    string rebelGroup = data[2];
                    return new Rebel(rebelName, rebelAge, rebelGroup);
                default:
                    return null;
            }
        }
    }
}
