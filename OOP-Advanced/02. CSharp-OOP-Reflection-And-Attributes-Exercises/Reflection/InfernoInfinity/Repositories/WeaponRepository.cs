using InfernoInfinity.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace InfernoInfinity.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public void Add(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public IWeapon GetItem(string name)
        {
            return this.weapons.First(i => i.Name == name);
        }

        public void Remove(IWeapon weapon)
        {
            if (weapon == null)
            {
                return;
            }

            this.weapons.Remove(weapon);
        }
    }
}
