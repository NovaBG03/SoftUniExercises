using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            data = new List<Hero>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            Hero hero = this.data.FirstOrDefault(h => h.Name == name);

            if (hero != null)
            {
                this.data.Remove(hero);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.data.FirstOrDefault(h => h.Item.Strength == this.data.Max(i => i.Item.Strength));
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.data.FirstOrDefault(h => h.Item.Ability == this.data.Max(i => i.Item.Ability));
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.data.FirstOrDefault(h => h.Item.Intelligence == this.data.Max(i => i.Item.Intelligence));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var hero in this.data)
            {
                builder.AppendLine(hero.ToString());
            }

            return builder.ToString().Trim();
        }
    }
}
