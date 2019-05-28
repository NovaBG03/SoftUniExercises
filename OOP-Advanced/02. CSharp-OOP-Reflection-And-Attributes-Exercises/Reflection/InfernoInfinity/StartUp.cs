namespace InfernoInfinity
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core;
    using InfernoInfinity.Core.Readers;
    using InfernoInfinity.Core.Writers;
    using InfernoInfinity.Factories;
    using InfernoInfinity.Repositories;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IRarityFactory rarityFactory = new RarityFactory();
            IWeaponFactory weaponFactory = new WeaponFactory();
            IClarityFactory clarityFactory = new ClarityFactory();
            IGemFactory gemFactory = new GemFactory();
            IRepository<IWeapon> weaponRepository = new WeaponRepository();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(weaponRepository, weaponFactory, rarityFactory, gemFactory, clarityFactory, writer);

            IRunnable engine = new Engine(commandInterpreter, reader);
            engine.Run();
        }
    }
}
