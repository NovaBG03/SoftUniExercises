using InfernoInfinity.Contracts;
using InfernoInfinity.Core;
using InfernoInfinity.Factories;

namespace InfernoInfinity
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IRarityFactory rarityFactory = new RarityFactory();
            IWeaponFactory weaponFactory = new WeaponFactory();
            IClarityFactory clarityFactory = new ClarityFactory();
            IGemFactory gemFactory = new GemFactory();

            IRunnable engine = new Engine(rarityFactory, weaponFactory, clarityFactory, gemFactory);
            engine.Run();
        }
    }
}
